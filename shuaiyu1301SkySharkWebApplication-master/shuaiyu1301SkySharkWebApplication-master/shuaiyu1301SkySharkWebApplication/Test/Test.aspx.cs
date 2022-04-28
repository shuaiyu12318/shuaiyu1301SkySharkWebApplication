using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //connet 
           // String connectionString = "Data Source=DESKTOP-SR1MKQK;Initial Catalog=ARPDatabase;Persist Security Info=True;User ID=sa;Password=admin123456789";
            string constr = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(constr);

            String sql = "INSERT INTO [dtUsers] ([Username], [Password], [Role]) VALUES (@Username, @Password, @Role)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@Username", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Password", TextBox2.Text);

            cmd.Parameters.AddWithValue("@Role", ListBox1.SelectedValue);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
               Label1.Text="Records Inserted Successfully";
                connection.Close();

                //update grid
                connection.Open();
                String sql2 = "SELECT [Username], [Password], [Role], [PasswordChanged] FROM [dtUsers]";
                SqlCommand cmd2 = new SqlCommand(sql2, connection);

                SqlDataAdapter sda = new SqlDataAdapter();

                sda.SelectCommand = cmd2;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                connection.Close();
              //  cmd2.ExecuteReader();
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }

        }
    }
}