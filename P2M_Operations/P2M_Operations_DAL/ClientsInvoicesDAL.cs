using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MySql.Data.MySqlClient;
using P2M_Operations_Entities;

namespace P2M_Operations_DAL
{

    public class ClientsInvoicesDAL
    {
        public string ConnectionString { get; set; }
        public void InsertClientsInvoices(Clients_Invoices clients_Invoices)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertClientsInvoices", con);
            //Procedure Parameters.

            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.Add(new MySqlParameter("VarOrderNo", clients_Invoices.OrderNo));
            com.Parameters.Add(new MySqlParameter("VarEmployeeID", clients_Invoices.EmployeeID));
            com.Parameters.Add(new MySqlParameter("VarFirstName", clients_Invoices.FirstName));
            com.Parameters.Add(new MySqlParameter("VarLastName", clients_Invoices.LastName));
            com.Parameters.Add(new MySqlParameter("VarCatalogName", clients_Invoices.CatalogName));
            com.Parameters.Add(new MySqlParameter("VarQuantity", clients_Invoices.Quantity));
            com.Parameters.Add(new MySqlParameter("VarOrderDate", clients_Invoices.OrderDate));
            com.Parameters.Add(new MySqlParameter("VarRedemptionPoints", clients_Invoices.RedemptionPoints));
            com.Parameters.Add(new MySqlParameter("VarLocalCost", clients_Invoices.LocalCost));
            if (clients_Invoices.ReasonofReturen == "0")
            {
                com.Parameters.Add(new MySqlParameter("VarReasonofReturen", "Not Available"));
            }
            else if (clients_Invoices.ReasonofReturen == "1")
            {
                com.Parameters.Add(new MySqlParameter("VarReasonofReturen", "By Customer"));
            }
            else { com.Parameters.Add(new MySqlParameter("VarReasonofReturen", "None")); }
            
            com.Parameters.Add(new MySqlParameter("VarCountry", clients_Invoices.Country));

            //
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //public void UpdateClientsInvoices(Clients_Invoices clients_Invoices)
        //{
        //    //Connection and Command objects.
        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    MySqlCommand com = new MySqlCommand("UpsertClientsInvoices", con);
        //    //Procedure Parameters.

        //    com.Parameters.AddWithValue("VarOrderNo", clients_Invoices.OrderNo);
        //    com.Parameters.AddWithValue("VarEmployeeID", clients_Invoices.EmployeeID);
        //    com.Parameters.AddWithValue("VarFirstName", clients_Invoices.FirstName);
        //    com.Parameters.AddWithValue("VarLastName", clients_Invoices.LastName);
        //    com.Parameters.AddWithValue("VarCatalogName", clients_Invoices.CatalogName);
        //    com.Parameters.AddWithValue("VarQuantity", clients_Invoices.Quantity);
        //    com.Parameters.AddWithValue("VarOrderDate", clients_Invoices.OrderDate);
        //    com.Parameters.AddWithValue("VarRedemptionPoints", clients_Invoices.RedemptionPoints);
        //    com.Parameters.AddWithValue("VarLocalCost", clients_Invoices.LocalCost);
        //    com.Parameters.AddWithValue("VarReasonofReturen", clients_Invoices.ReasonofReturen);
        //    com.Parameters.AddWithValue("VarCountry", clients_Invoices.Country);

        //    //
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();
        //}

        public void DeleteClientsInvoices(string orderNO)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteClientsInvoice", con);
            //Procedure Parameters.
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarOrderNO", orderNO));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }

        public List<Clients_Invoices> GetClientsInvoices(string OrderNo, string EmployeeID, DateTime StartDate, DateTime EndDate, int Company)
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {

                MySqlCommand com = new MySqlCommand("GetClientsInvoices", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                if (string.IsNullOrEmpty(OrderNo))
                {
                    com.Parameters.Add(new MySqlParameter("VarOrderNo", null));
                }
                else
                {
                    com.Parameters.Add(new MySqlParameter("VarOrderNo", OrderNo));
                }

                if (string.IsNullOrEmpty(OrderNo))
                {
                    com.Parameters.Add(new MySqlParameter("VarEmployeeID", null));
                }
                else
                {
                    com.Parameters.Add(new MySqlParameter("VarEmployeeID", EmployeeID));
                }
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
                com.Parameters.Add(new MySqlParameter("VarCompany", Company));
                List<Clients_Invoices> ClientsInvoicesList = new List<Clients_Invoices>();
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Clients_Invoices clientsInvoices = new Clients_Invoices();


                    clientsInvoices.OrderNo = reader["OrderNo"].ToString();
                    clientsInvoices.EmployeeID = reader["EmployeeID"].ToString();
                    clientsInvoices.FirstName = reader["FirstName"].ToString();
                    clientsInvoices.LastName = reader["LastName"].ToString();
                    clientsInvoices.CatalogName = reader["CatalogName"].ToString();
                    clientsInvoices.Quantity = Convert.ToInt32(reader["Quantity"]);
                    DateTime? OrderDate = (reader["OrderDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["OrderDate"]).Date;
                    clientsInvoices.OrderDate = OrderDate;
                    clientsInvoices.RedemptionPoints = reader["RedemptionPoints"].ToString();
                    
                    clientsInvoices.ReasonofReturen = reader["ReasonofReturen"].ToString();
                    clientsInvoices.USDCost = Convert.ToDouble(reader["USDCost"]);
                    clientsInvoices.Country = reader["Country"].ToString();
                    clientsInvoices.LocalCost = Convert.ToDouble(reader["LocalCost"]);




                    ClientsInvoicesList.Add(clientsInvoices);
                }
                con.Close();
                return ClientsInvoicesList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
        public List<Clients_Invoices> GetInvoiceTotal(string OrderNo, string EmployeeID, DateTime StartDate, DateTime EndDate, int Company)
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {

                MySqlCommand com = new MySqlCommand("GetInvoiceTotal", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.Add(new MySqlParameter("VarOrderNo", OrderNo));
                com.Parameters.Add(new MySqlParameter("VarEmployeeID", EmployeeID));
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
                com.Parameters.Add(new MySqlParameter("VarCompany", Company));
                List<Clients_Invoices> TotalInvoicesList = new List<Clients_Invoices>();
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Clients_Invoices clientsInvoices = new Clients_Invoices();


                    
                    clientsInvoices.TotalLocalCost = Convert.ToDouble(reader["TotalLocalCost"]);
                    clientsInvoices.TotalUSDCost = Convert.ToDouble(reader["TotalUSDCost"]);
                    clientsInvoices.Country = reader["Country"].ToString();




                    TotalInvoicesList.Add(clientsInvoices);
                }
                con.Close();
                return TotalInvoicesList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }

    }
}
