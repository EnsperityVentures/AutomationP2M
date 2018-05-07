using System;
using P2M_Operations_Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace P2M_Operations_DAL
{
    public class OmanFloatDAL
    {
        public string ConnectionString { get; set; }
        public void InsertOmanFloat(OmanFloat omanFloat)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertOman", con);

            //Procedure Parameters .
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarOrderNo", omanFloat.OrderNo));
            com.Parameters.Add(new MySqlParameter("VarOrderDate", omanFloat.OrderDate));
            com.Parameters.Add(new MySqlParameter("VarMemberName", omanFloat.MemberName));
            com.Parameters.Add(new MySqlParameter("VarTotalcost", omanFloat.Totalcost));
            com.Parameters.Add(new MySqlParameter("VarDeliveryfees", omanFloat.Deliveryfees));
            com.Parameters.Add(new MySqlParameter("VarTotalCostwithDelivery", omanFloat.TotalCostwithDelivery));
            com.Parameters.Add(new MySqlParameter("VarStatus", omanFloat.Status));
            com.Parameters.Add(new MySqlParameter("VarDeliveryDate", omanFloat.DeliveryDate));
            com.Parameters.Add(new MySqlParameter("VarCardTypeandAmount", omanFloat.CardTypeandAmount));
            com.Parameters.Add(new MySqlParameter("VarQuantity", omanFloat.Quantity));
            //

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        //public void UpdateOmanFloat(OmanFloat omanFloat)
        //{
        //    //Connection and Command objects.
        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    MySqlCommand com = new MySqlCommand("UpsertOman", con);

        //    //Procedure Parameters .
        //    com.Parameters.AddWithValue("VarOrderNo", omanFloat.OrderNo);
        //    com.Parameters.AddWithValue("VarOrderDate", omanFloat.OrderDate);
        //    com.Parameters.AddWithValue("VarMemberName", omanFloat.MemberName);
        //    com.Parameters.AddWithValue("VarDeliveryfees", omanFloat.Deliveryfees);
        //    com.Parameters.AddWithValue("VarTotalCostwithDelivery", omanFloat.TotalCostwithDelivery);
        //    com.Parameters.AddWithValue("VarTotalRemainingAmount", omanFloat.TotalRemainingAmount);
        //    com.Parameters.AddWithValue("VarStatus", omanFloat.Status);
        //    com.Parameters.AddWithValue("VarDeliveryDate", omanFloat.DeliveryDate);
        //    com.Parameters.AddWithValue("VarCardTypeandAmount", omanFloat.CardTypeandAmount);
        //    com.Parameters.AddWithValue("VarQuantity", omanFloat.Quantity);

        //    // open and close the seesion.
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();
        //}
        public void DeleteOmanFloat(string orderno)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteOman", con);

            //Procedure Parameters .
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarOrderNo", orderno));

            // open and close the seesion.
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public List<OmanFloat> GetOmanFloat(string orderno)
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                MySqlCommand com = new MySqlCommand("GetOmanInformaion", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add(new MySqlParameter("VarOrderNo", orderno));
                List<OmanFloat> OmanFloatList = new List<OmanFloat>();
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    OmanFloat OmnFloat = new OmanFloat();


                    OmnFloat.OrderNo = reader["OrderNo"].ToString();
                    DateTime? dt2 = (reader["OrderDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["OrderDate"]);
                    OmnFloat.OrderDate = dt2;
                    //OmnFloat.OrderDate = Convert.ToDateTime(reader["OrderDate"]);
                    OmnFloat.MemberName = reader["MemberName"].ToString();
                    //OmnFloat.PaymentstoOman = Convert.ToDouble(reader["PaymentstoOman"]);
                    OmnFloat.Totalcost = Convert.ToDouble(reader["Totalcost"]);
                    OmnFloat.Deliveryfees = Convert.ToDouble(reader["Deliveryfees"]);
                    OmnFloat.TotalCostwithDelivery = Convert.ToDouble(reader["TotalCostwithDelivery"]);
                    //OmnFloat.TotalRemainingAmount = Convert.ToDouble(reader["TotalRemainingAmount"]);
                    OmnFloat.Status = reader["Status"].ToString();
                    DateTime? dt = (reader["DeliveryDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["DeliveryDate"]);
                    OmnFloat.DeliveryDate = dt;
                    OmnFloat.CardTypeandAmount = reader["CardTypeandAmount"].ToString();
                    OmnFloat.Quantity = Convert.ToInt32(reader["Quantity"]);
                    // DateTime? dt1 = (reader["Dateofpayment"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["Dateofpayment"]);
                    //OmnFloat.Dateofpayment = dt1;
                    OmanFloatList.Add(OmnFloat);

                }
                //lblTotalAmount.Text = Convert.ToDouble(reader["TotalRemainingAmount"]);
                con.Close();
                return OmanFloatList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
        public void OmanAddAmount(double amount, DateTime damount)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("OmanAddAmount", con);
            //Procedure Parameters .
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("varID", 0));
            com.Parameters.Add(new MySqlParameter("VarPaymentstoOman", amount));
            com.Parameters.Add(new MySqlParameter("VarDateofpayment", damount.Date));

            //

            // open and close the seesion.
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public string GetAmount()

        {
            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {//Connection and Command objects.

                MySqlCommand com = new MySqlCommand("GetAmount", con);
                //Procedure Parameters .
                com.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                string Total = null;
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Total = reader["TotalRemainingAmount"].ToString();
                    //lblTotalAmount.Text = t;
                }
                con.Close();
                return Total;
            }
            catch
            {
                
                con.Close();
                return null;

            }
        }
        public List<OmanAmount> GetOmanAmount()
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                MySqlCommand com = new MySqlCommand("getOmanAmount", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                List<OmanAmount> OmanAmountList = new List<OmanAmount>();
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    OmanAmount OmnAmount = new OmanAmount();

                    OmnAmount.ID= Convert.ToInt32(reader["ID"]);
                    OmnAmount.PaymentstoOman = Convert.ToDouble(reader["PaymentstoOman"]);
                    OmnAmount.TotalRemainingAmount = Convert.ToDouble(reader["TotalRemainingAmount"]);
                    DateTime? dt1 = (reader["Dateofpayment"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["Dateofpayment"]);
                    OmnAmount.Dateofpayment = dt1;
                    OmanAmountList.Add(OmnAmount);

                }
                //lblTotalAmount.Text = Convert.ToDouble(reader["TotalRemainingAmount"]);
                con.Close();
                return OmanAmountList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
        public void InsertOmanAmount(OmanAmount omanAmount)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("OmanAddAmount", con);

            //Procedure Parameters .
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarID", omanAmount.ID));
            com.Parameters.Add(new MySqlParameter("VarPaymentstoOman", omanAmount.PaymentstoOman));
            com.Parameters.Add(new MySqlParameter("VarDateofpayment", omanAmount.Dateofpayment));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteOmanAmount(string ID)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteOmanAmount", con);

            //Procedure Parameters .
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarID", ID));

            // open and close the seesion.
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}

