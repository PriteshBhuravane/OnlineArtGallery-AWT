using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineArtGallery
{
    public partial class EditArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string artistID = Request.QueryString["ArtistID"];
                if (!string.IsNullOrEmpty(artistID))
                {
                    LoadArtistDetails(artistID);
                }
            }
        }

        private void LoadArtistDetails(string artistID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ArtGalleryDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, Email, ArtCategory, ArtworkFileName FROM Artists WHERE ArtistID = @ArtistID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArtistID", artistID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                        ddlArtCategory.SelectedValue = reader["ArtCategory"].ToString();
                        // Note: The ArtworkFileName is not displayed in the form but can be used for reference
                    }
                    reader.Close();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string artistID = Request.QueryString["ArtistID"];
            string name = txtName.Text;
            string email = txtEmail.Text;
            string artCategory = ddlArtCategory.SelectedValue;
            string artworkFileName = fileArtwork.PostedFile.FileName;

            string connectionString = ConfigurationManager.ConnectionStrings["ArtGalleryDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Artists SET Name = @Name, Email = @Email, ArtCategory = @ArtCategory WHERE ArtistID = @ArtistID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@ArtCategory", artCategory);
                    command.Parameters.AddWithValue("@ArtistID", artistID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Redirect("Gallery.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Gallery.aspx");
        }
    }
}