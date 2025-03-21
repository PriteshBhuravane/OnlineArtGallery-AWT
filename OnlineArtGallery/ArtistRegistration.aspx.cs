using System;
using System.Collections.Generic;
using System.Configuration;
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
                    Directory.CreateDirectory(uploadFolderPath); // Create the Uploads folder if it doesn't exist
                }
                string filePath = Path.Combine(uploadFolderPath, artworkFileName);
                fileArtwork.PostedFile.SaveAs(filePath);

                // Save data to the database
                string connectionString = ConfigurationManager.ConnectionStrings["ArtGalleryDB"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Artists (Name, Email, ArtCategory, ArtworkFileName) VALUES (@Name, @Email, @ArtCategory, @ArtworkFileName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@ArtCategory", artCategory);
                        command.Parameters.AddWithValue("@ArtworkFileName", artworkFileName);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                lblMessage.Text = "Registration Successful! Thank you for registering.";
                                lblMessage.ForeColor = System.Drawing.Color.Green;
                            }
                            else
                            {
                                lblMessage.Text = "Registration failed. No rows were affected.";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
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