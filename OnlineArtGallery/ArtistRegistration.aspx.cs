using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineArtGallery
{
    public partial class ArtistRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string name = txtName.Text;
                string email = txtEmail.Text;
                string artCategory = ddlArtCategory.SelectedValue;
                string artworkFileName = Path.GetFileName(fileArtwork.PostedFile.FileName);

                // Save the uploaded file to the server
                string uploadFolderPath = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }
                string filePath = Path.Combine(uploadFolderPath, artworkFileName);
                fileArtwork.PostedFile.SaveAs(filePath);

                // Save data to the database using the stored procedure
                string connectionString = ConfigurationManager.ConnectionStrings["ArtGalleryDB"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_InsertArtist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure; // Specify that this is a stored procedure
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@ArtCategory", artCategory);
                        command.Parameters.AddWithValue("@ArtworkFileName", artworkFileName);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            lblMessage.Text = "Registration Successful! Thank you for registering.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = "Error: " + ex.Message;
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
        }
    }
}