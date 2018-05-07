using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using P2M_Operations_Entities;

namespace P2M_Operations_DAL
{
    public class GiftCardsInvoiceDAL
    {
        public string ConnectionString { get; set; }
        public void InsertGiftCardsInvoice(Gift_Cards_Invoice GC_Invoice)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertGiftCardsInvoice", con);
            //Procedure Parameters.
            com.CommandType = System.Data.CommandType.StoredProcedure;
            string RName = GC_Invoice.RewardName;
            string sp = "/";
            if (RName.Contains(sp))
            {
                com.Parameters.Add(new MySqlParameter("VarRewardName", RName.Split('/')[1])); }
            else { { com.Parameters.Add(new MySqlParameter("VarRewardName", RName)); } }

            com.Parameters.Add(new MySqlParameter("VarOrderId", GC_Invoice.OrderId));
            com.Parameters.Add(new MySqlParameter("VarEmployeeID", GC_Invoice.EmployeeID));
            com.Parameters.Add(new MySqlParameter("VarLineNumber", GC_Invoice.LineNumber));

            com.Parameters.Add(new MySqlParameter("VarOrderDate", GC_Invoice.OrderDate));
            com.Parameters.Add(new MySqlParameter("VarLocalCost", GC_Invoice.LocalCost));
            com.Parameters.Add(new MySqlParameter("VarQuantity", GC_Invoice.Quantity));
            if (GC_Invoice.ReasonofReturen == "0")
            {
                com.Parameters.Add(new MySqlParameter("VarReasonofReturen", "Not Available"));
            }
            else if (GC_Invoice.ReasonofReturen == "1")
            {
                com.Parameters.Add(new MySqlParameter("VarReasonofReturen", "By Customer"));
            }
            else { com.Parameters.Add(new MySqlParameter("VarReasonofReturen", "None")); }
            com.Parameters.Add(new MySqlParameter("VarCountry", GC_Invoice.Country));
            com.Parameters.Add(new MySqlParameter("VarSKU", GC_Invoice.SKU));

            //
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        //public void UpdateGiftCardsInvoice(Gift_Cards_Invoice GC_Invoice)
        //{
        //    //Connection and Command objects.
        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    MySqlCommand com = new MySqlCommand("UpsertGiftCardsInvoice", con);
        //    //Procedure Parameters.

        //    com.Parameters.AddWithValue("VarOrderId", GC_Invoice.OrderId);
        //    com.Parameters.AddWithValue("VarEmployeeID", GC_Invoice.EmployeeID);
        //    com.Parameters.AddWithValue("VarLineNumber", GC_Invoice.LineNumber);
        //    com.Parameters.AddWithValue("VarRewardName", GC_Invoice.RewardName);
        //    com.Parameters.AddWithValue("VarOrderDate", GC_Invoice.OrderDate);
        //    com.Parameters.AddWithValue("VarLocalCost", GC_Invoice.LocalCost);
        //    com.Parameters.AddWithValue("VarQuantity", GC_Invoice.Quantity);
        //    com.Parameters.AddWithValue("VarReasonofReturen", GC_Invoice.ReasonofReturen);
        //    com.Parameters.AddWithValue("VarCountry", GC_Invoice.Country);

        //    //
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();
        //}
        public void DeleteGiftCardsInvoice(string OrderID)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteGiftCardsInvoice", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            //Procedure Parameters.
            com.Parameters.Add(new MySqlParameter("VarOrderId", OrderID));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<Gift_Cards_Invoice> GetGiftCardsInvoice(string OrderId, string EmployeeID, DateTime StartDate, DateTime EndDate)
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                MySqlCommand com = new MySqlCommand("GetGiftCardsInvoice", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                List<Gift_Cards_Invoice> GC_InvoiceList = new List<Gift_Cards_Invoice>();
                com.Parameters.Add(new MySqlParameter("VarOrderId", OrderId));
                com.Parameters.Add(new MySqlParameter("VarEMPID", EmployeeID));
                //com.Parameters.Add(new MySqlParameter("VarQuantity", Quantity));
                if (StartDate != DateTime.MinValue)
                {
                    com.Parameters.Add(new MySqlParameter("VarStartDate", StartDate.Date));
                }
                else
                {
                    com.Parameters.Add(new MySqlParameter("VarStartDate", null));
                }
                if (EndDate != DateTime.MinValue)
                {
                    com.Parameters.Add(new MySqlParameter("VarEndDate", EndDate.Date));
                }
                else
                {
                    com.Parameters.Add(new MySqlParameter("VarEndDate", null));
                }
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Gift_Cards_Invoice GC_Invoice = new Gift_Cards_Invoice();


                    GC_Invoice.OrderId = reader["OrderID"].ToString();
                    GC_Invoice.EmployeeID = reader["EmployeeID"].ToString();
                    GC_Invoice.LineNumber = (reader["OrderID"].ToString()).Split('-')[0];
                    GC_Invoice.RewardName = reader["RewardName"].ToString();
                    GC_Invoice.Quantity = Convert.ToInt32(reader["Quantity"]);
                    DateTime? OrderDate = (reader["OrderDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["OrderDate"]).Date;
                    GC_Invoice.OrderDate = OrderDate;
                    GC_Invoice.LocalCost = (reader["LocalCost"].ToString());
                    GC_Invoice.ReasonofReturen = reader["ReasonofReturen"].ToString();
                    GC_Invoice.USDCost = Convert.ToDouble(reader["USDCost"]);
                    GC_Invoice.Country = reader["Country"].ToString(); ;
                    GC_Invoice.SKU = reader["SKU"].ToString(); ;



                    GC_InvoiceList.Add(GC_Invoice);
                }
                con.Close();
                return GC_InvoiceList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
        public List<Gift_Cards_Invoice> GetGCTotal(DateTime StartDate, DateTime EndDate)
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                MySqlCommand com = new MySqlCommand("GetGCTotal", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                List<Gift_Cards_Invoice> GCTList = new List<Gift_Cards_Invoice>();
                com.Parameters.Add(new MySqlParameter("VarStartDate", StartDate));
                com.Parameters.Add(new MySqlParameter("VarEndDate", EndDate));
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Gift_Cards_Invoice GC_Invoice = new Gift_Cards_Invoice();


                    GC_Invoice.TotalLocalCost = Convert.ToDouble(reader["TotalLocalCost"]);
                    GC_Invoice.TotalUSDCost = Convert.ToDouble(reader["TotalUSDCost"]);




                    GCTList.Add(GC_Invoice);
                }
                con.Close();
                return GCTList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
    }
}
