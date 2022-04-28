using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shuaiyu1301SkySharkWebApplication
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usrRole"] == null)
            {
                Response.Redirect("~\\default.aspx");
            }
            if (!(Session["usrRole"].ToString() == "Admin")){
                Response.Redirect("~\\default.aspx");
            }
            else
            {
                Label2.Text="Changing password for "+Session["userName"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                String updateSql = "UPDATE dtUsers SET Password = @Password,PasswordChanged ='1' WHERE (Username =@original_username )";
                SqlCommand cmd = conn.CreateCommand();
                cmd.Parameters.AddWithValue("@Password",txtPassword.Text);
                cmd.Parameters.AddWithValue("@original_username", Session["username"]);
                
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("~/NA/ManageUsers.aspx");
            }
            catch (Exception ex)
            {
                Label2.Text = ex.Message;
            }
        }
    }
}