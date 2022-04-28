using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shuaiyu1301SkySharkWebApplication
{
    public partial class _default : System.Web.UI.Page
    {

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                String username;
                String password;
                username = txtUserName.Text;
                password = txtPassword.Text;
                //get connection
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
                conn.Open();
                //create dataadapter
                string querystring = "Select Username,Password,role from dtUsers where Username='" + username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter();

                //create command
                adapter.SelectCommand = new SqlCommand(querystring, conn);

                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "dtUsers");

                if(ds1.Tables["dtUsers"].Rows.Count == 0)
                {
                    lblMessage.Text = "Invalid Username";
                }
                else
                {
                    if (ds1.Tables["dtUsers"].Rows[0][1].ToString().Trim() == txtPassword.Text.Trim())
                    {
                        lblMessage.Text = "Welcome," + username;
                        String Role;
                        Role=ds1.Tables["dtUsers"].Rows[0][2].ToString().Trim();
                        Session["usrName"] = username;
                        Session["usrRole"] = Role;
                        if(Role=="Disabled")
                        {
                            lblMessage.Text = "Your account has been disabled.Please contact the network Administrator";
                            return;
                        }
                        switch (Role)
                        {
                            case "Admin":
                                Response.Redirect(".\\NA\\ManageUsers.aspx");
                                    break;
                            case "BM":
                                Response.Redirect(".\\BM\\AddFI.aspx");
                                break;
                            case "LOB":
                                Response.Redirect(".\\LOB\\CreateRes.aspx");
                                break;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "Invalid password";
                    }
                }
                conn.Close();
            }//end
        }
    }
}