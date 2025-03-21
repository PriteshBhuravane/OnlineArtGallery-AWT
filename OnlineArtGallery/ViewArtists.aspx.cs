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
    public partial class ViewArtists : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindArtistsData();
            }
        }

        private void BindArtistsData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ArtGalleryDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, Email, ArtCategory, ArtworkFileName FROM Artists";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        gvArtists.DataSource = dt;
                        gvArtists.DataBind();
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception (e.g., log it or display an error message)
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}