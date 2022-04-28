﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace shuaiyu1301SkySharkWebApplication.LOB
{
    public partial class CancelRes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            lblMessage.Text = ""; 
            String ConnectionString = ConfigurationManager.ConnectionStrings["ARPDatabaseConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string SelectSql = "SELECT dtReservations.TicketNo, dtReservations.FltNo, dtReservations.DateOfJourney, dtReservations.ClassOfRes, dtReservations.TicketConfirmed," +
                " dtReservations.DateOfRes, dtReservations.Fare FROM dtReservations LEFT OUTER JOIN dtCancellations ON dtReservations.TicketNo = dtCancellations.TicketNo " +
                "WHERE(dtReservations.TicketNo = @TicketNo) ";
            //"and Deptime='"+Calendar1.SelectedDate.ToShortDateString()+ "'";
            SqlCommand cmd = new SqlCommand(SelectSql, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("TicketNo", txtTNo.Text.Trim());
            DataSet ticketNodataSet = new DataSet();
            adapter.Fill(ticketNodataSet,"TicketDetails");
            conn.Close();

            if (ticketNodataSet.Tables["TicketDetails"].Rows.Count == 0)
            {
                lblMessage.Text = "Invalid Ticket Number";
                return;
            }
            else
            {
                String ticketNo, user, cancDate, journeuDate;
                int refund, fare;
                ticketNo=txtTNo.Text.Trim();
                journeuDate=ticketNodataSet.Tables["TicketDetails"].Rows[0][2].ToString(); 
                fare=Convert.ToInt32(ticketNodataSet.Tables["TicketDetails"].Rows[0][6].ToString());
                if (Convert.ToDateTime(journeuDate) <= DateTime.Today)
                {
                    refund = fare - 10;
                }
                else
                {
                    refund = Convert.ToInt32(fare * 0.8);
                }
                try
                {
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("DeleteReservation", conn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@ticketno", ticketNo);
                    cmd2.Parameters.AddWithValue("@user", "Admin");//Session["usrName].
                    cmd2.Parameters.AddWithValue("@cancdate", DateTime.Today.Date.ToShortDateString());
                    cmd2.Parameters.AddWithValue("@refund", refund);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    lblMessage.Text = "Ticket Cancellation Done!!!";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }
    }
}