using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineArtGallery
{
    public partial class Gallery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArtworksData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim();
            BindArtworksData(searchTerm);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BindArtworksData();
        }
        private void BindArtworksData(string searchTerm = "")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ArtGalleryDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetAllArtists", connection))
                {
                    command.CommandType = CommandType.StoredProcedure; // Specify that this is a stored procedure

                    // Add the @SearchTerm parameter
                    command.Parameters.AddWithValue("@SearchTerm", string.IsNullOrEmpty(searchTerm) ? (object)DBNull.Value : searchTerm);

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            rptArtworks.DataSource = dt;
                            rptArtworks.DataBind();
                            lblNoResults.Visible = false;
                        }
                        else
                        {
                            lblNoResults.Visible = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btnEdit = (Button)sender;
            string artistID = btnEdit.CommandArgument;

            // Redirect to the Edit page with the ArtistID as a query parameter
            Response.Redirect("EditArtist.aspx?ArtistID=" + artistID);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            string artistID = btnDelete.CommandArgument;

            string connectionString = ConfigurationManager.ConnectionStrings["ArtGalleryDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Artists WHERE ArtistID = @ArtistID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ArtistID", artistID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Refresh the gallery page
            BindArtworksData();
        }
    }
}