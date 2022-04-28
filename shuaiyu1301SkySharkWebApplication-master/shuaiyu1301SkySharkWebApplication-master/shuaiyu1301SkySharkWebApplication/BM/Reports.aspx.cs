using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shuaiyu1301SkySharkWebApplication.BM
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Button3_Click(object sender, EventArgs e)
        {
            String month, date, year;
            month = lstMonth.SelectedItem.Text.Trim();
            year = lstYear.SelectedItem.Text.Trim();
            date = month + "/01/" + year;

            //get connection -use your connection string name -ARPDatabaseConnectionString
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            //create dataadapter
            string queryString = "SELECT FltNo, SUM(Fare) AS fare from dtDepartedFlights  where (DateOfJourney>@date) group by FltNo";
            SqlDataAdapter adapter = new SqlDataAdapter();

            //create command
            SqlCommand cmd = new SqlCommand(queryString, conn);
            cmd.Parameters.AddWithValue("@date", date);

            adapter.SelectCommand = cmd;

            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "fare");
            conn.Close();
            DataView source = new DataView(dataset.Tables["fare"]);
            //bind grid
            DataGrid1.DataSource = source;
            DataGrid1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //get connection -use your connection string name -ARPDatabaseConnectionString
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            //create dataadapter
            string queryString = "SELECT FltNo, DateOfJourney, SUM(Fare) AS Revenue from dtDepartedFlights GROUP BY DateOfJourney, FltNo";
            SqlDataAdapter adapter = new SqlDataAdapter();

            //create command
            SqlCommand cmd = new SqlCommand(queryString, conn);

            adapter.SelectCommand = cmd;

            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "Usges");
            conn.Close();
            DataView source = new DataView(dataset.Tables["Usges"]);
            //bind grid
            DataGrid1.DataSource = source;
            DataGrid1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //get connection -use your connection string name -ARPDatabaseConnectionString
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString);
            conn.Open();
            //create dataadapter
            string queryString = "SELECT Top 100 Email, FareCollected, TotalTimesFlown from dtPassengerDetails order by TotalTimesFlown";
            SqlDataAdapter adapter = new SqlDataAdapter();

            //create command
            SqlCommand cmd = new SqlCommand(queryString, conn);

            adapter.SelectCommand = cmd;

            DataSet dataset = new DataSet();
            adapter.Fill(dataset, "FreFI");
            conn.Close();
            DataView source = new DataView(dataset.Tables["FreFI"]);
            DataGrid1.DataSource = source;
            DataGrid1.DataSourceID = null;
            DataGrid1.DataBind();
        }
    }
}