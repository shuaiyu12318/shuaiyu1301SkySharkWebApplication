﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shuaiyu1301SkySharkWebApplication.NA
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddSubmit_Click(object sender, EventArgs e)
        {
            string username, password, role;
            int selection;
            role = lstAddRole.SelectedValue;
            username = txtAddUserName.Text;
            password = txtAddPassword.Text;
            selection = lstAddRole.SelectedIndex;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            string querystring = "Select Username,Password,role from dtUsers where UserName='" + username + "'";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(querystring, conn);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "dtUsers");
            if (ds1.Tables["dtUsers"].Rows.Count == 0)
            {
                //insert
                string insertQueryString = "INSERT INTO [dtUsers] ([Username],[Password],[Role]) VALUES ('" + username + "','" + password + "','" + role + "')";
                SqlCommand insertCommand = new SqlCommand(insertQueryString, conn);
                insertCommand.ExecuteNonQuery();
            }
            else
            {
                lblMessage.Text = "The user name already exists.Please try another user name";
                return;
            }
        }//end btnAddSubmit_Click

        protected void btnDelDelete_Click(object sender, EventArgs e)
        {
            string username=txtAddUserName.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            if (username == " " || username == null)
            {
                lblMessage.Text = "Please specify a valid user name";
            }
            else
            {
                string queryString ="Select UserName,Password,role from dtUsers where UserName='" +username + "'";
                SqlDataAdapter adapter=new SqlDataAdapter();
                adapter.SelectCommand=new SqlCommand(queryString, conn);
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "dtUsers");
                if (ds1.Tables["dtUsers"].Rows.Count == 0)
                {
                    lblMessage.Text = "User does not exists";
                    return;
                }
                else
                {
                    string queryString2="delete from dtUsers where UserName='" +username + "'";
                    SqlCommand insertCommand =new SqlCommand(queryString2, conn);
                    insertCommand.ExecuteNonQuery();
                    conn.Close();
                    lblMessage.Text = "User deleted successfully";
                    txtDelUserName.Text = "";

                }
            }//end else

        }//end btnDelete_Click
    }
}