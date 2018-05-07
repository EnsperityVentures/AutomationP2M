using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using P2M_Operations_Entities;

namespace P2M_Operations_DAL
{
    public class DailyOrdersDAL
    {
        public string ConnectionString { get; set; }
        public void UpsertDailyOrders(DailyOrders dailyOrders)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertDailyOrders", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            //Procedure Parameters.
            com.Parameters.Add(new MySqlParameter("VarPIN", dailyOrders.ID));
            com.Parameters.Add(new MySqlParameter("VarPIN", dailyOrders.PIN));
            com.Parameters.Add(new MySqlParameter("VarEmployeeID", dailyOrders.EmployeeID));
            com.Parameters.Add(new MySqlParameter("VarFirstName", dailyOrders.FirstName));
            com.Parameters.Add(new MySqlParameter("VarLastName", dailyOrders.LastName));
            com.Parameters.Add(new MySqlParameter("VarDeptName", dailyOrders.DeptName));
            com.Parameters.Add(new MySqlParameter("VarDeptCode", dailyOrders.DeptCode));
            com.Parameters.Add(new MySqlParameter("VarJobTitle", dailyOrders.JobTitle));
            com.Parameters.Add(new MySqlParameter("VarPhoneNumber", dailyOrders.PhoneNumber));
            com.Parameters.Add(new MySqlParameter("VarCatalogName", dailyOrders.CatalogName));
            com.Parameters.Add(new MySqlParameter("VarRewardName", dailyOrders.RewardName));
            com.Parameters.Add(new MySqlParameter("VarQuantity", dailyOrders.Quantity));
            com.Parameters.Add(new MySqlParameter("VarDetails", dailyOrders.Details));
            com.Parameters.Add(new MySqlParameter("VarHighestLevelCategory", dailyOrders.HighestLevelCategory));
            com.Parameters.Add(new MySqlParameter("VarLowestLevelCategory", dailyOrders.LowestLevelCategory));
            com.Parameters.Add(new MySqlParameter("VarCompany", dailyOrders.Company));
            com.Parameters.Add(new MySqlParameter("VarName", dailyOrders.Name));
            com.Parameters.Add(new MySqlParameter("VarAddress1", dailyOrders.Address1));
            com.Parameters.Add(new MySqlParameter("VarAddress2", dailyOrders.Address2));
            com.Parameters.Add(new MySqlParameter("VarCity", dailyOrders.City));
            com.Parameters.Add(new MySqlParameter("VarState", dailyOrders.State));
            com.Parameters.Add(new MySqlParameter("VarZipCode", dailyOrders.ZipCode));
            com.Parameters.Add(new MySqlParameter("VarCountry", dailyOrders.Country));
            com.Parameters.Add(new MySqlParameter("VarP2MOrderNumber", dailyOrders.P2MOrderNumber));
            com.Parameters.Add(new MySqlParameter("VarStatus", dailyOrders.OrderStatus));
            com.Parameters.Add(new MySqlParameter("VarCStatus", dailyOrders.OrderCStatus));
            com.Parameters.Add(new MySqlParameter("VarDiscountCoupon", dailyOrders.DiscountCoupon));
            com.Parameters.Add(new MySqlParameter("VarRedemptionAmount", dailyOrders.RedemptionAmount));
            com.Parameters.Add(new MySqlParameter("VarDiscountApplied", dailyOrders.DiscountApplied));
            com.Parameters.Add(new MySqlParameter("VarMemberPaid", dailyOrders.MemberPaid));
            com.Parameters.Add(new MySqlParameter("VarPointBillingRate", dailyOrders.PointBillingRate));
            com.Parameters.Add(new MySqlParameter("VarordarDate", dailyOrders.OrderDate));
            com.Parameters.Add(new MySqlParameter("VarGRSOrderNum", dailyOrders.GRSOrderNum));
            com.Parameters.Add(new MySqlParameter("VarItemNumber", dailyOrders.ItemNumber));
            com.Parameters.Add(new MySqlParameter("VarItemDescription", dailyOrders.ItemDescription));
            com.Parameters.Add(new MySqlParameter("VarItemOption", dailyOrders.ItemOption));
            com.Parameters.Add(new MySqlParameter("VarEmail", dailyOrders.Email));
            com.Parameters.Add(new MySqlParameter("VarProductCost", dailyOrders.ProductCost));
            com.Parameters.Add(new MySqlParameter("VarCatalogCode", dailyOrders.CatalogCode));
            com.Parameters.Add(new MySqlParameter("VarDateProcessed", dailyOrders.DateProcessed));
            com.Parameters.Add(new MySqlParameter("VarQuantityShipped", dailyOrders.QuantityShipped));
            com.Parameters.Add(new MySqlParameter("VarTrackingNumber", dailyOrders.TrackingNumber));
            com.Parameters.Add(new MySqlParameter("VarCourierName", dailyOrders.CourierName));
            com.Parameters.Add(new MySqlParameter("VarMemo", dailyOrders.Memo));
            com.Parameters.Add(new MySqlParameter("VarNote", dailyOrders.Note));

            //
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void InsertDGC(GRSDailyOrders DGC)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertGCDailyOrders", con);
            //Procedure Parameters.
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("VarID", DGC.GRSOrder);
            com.Parameters.AddWithValue("VarGRSOrderNum", DGC.GRSOrder);
            com.Parameters.AddWithValue("VarPartnerSystemOrderNum", DGC.PartnerSystemOrder);
            com.Parameters.AddWithValue("VarEmployeeID", DGC.UserId);
            com.Parameters.AddWithValue("VarFirstName", DGC.FirstName);
            com.Parameters.AddWithValue("VarLastName", DGC.LastName);
            com.Parameters.AddWithValue("VarOrderDate", DGC.OrderDate);
            com.Parameters.AddWithValue("VarCompanyName", DGC.CompanyName);
            com.Parameters.AddWithValue("VarAddress1", DGC.Address1);
            com.Parameters.AddWithValue("VarAddress2", DGC.Address2);
            com.Parameters.AddWithValue("VarCity", DGC.City);
            com.Parameters.AddWithValue("VarState", DGC.StateProvince);
            com.Parameters.AddWithValue("VarCountry", DGC.Country);
            com.Parameters.AddWithValue("VarZipCode", DGC.ZipPostalCode);
            com.Parameters.AddWithValue("VarPhoneNumber", DGC.PhoneNumber);
            com.Parameters.AddWithValue("VarItemNumber", DGC.ItemNumber);
            com.Parameters.AddWithValue("VarItemDescription", DGC.ItemDescription);
            com.Parameters.AddWithValue("VarItemOption", DGC.ItemOption);
            com.Parameters.AddWithValue("VarEmail", DGC.Email);

            if (string.IsNullOrEmpty(Convert.ToString(DGC.Quantity)))
            {
                com.Parameters.AddWithValue("VarQuantity", "0");
            }
            else { com.Parameters.AddWithValue("VarQuantity", DGC.Quantity); }
            com.Parameters.AddWithValue("VarCatalogName", DGC.CatalogName);
            if (string.IsNullOrEmpty(Convert.ToString(DGC.ProductCost)))
            {
                com.Parameters.AddWithValue("VarProductCost", "0");
            }
            else { com.Parameters.AddWithValue("VarProductCost", DGC.ProductCost); }
            com.Parameters.AddWithValue("VarCatalogCode", DGC.CatalogCode);
            com.Parameters.AddWithValue("VarDateProcessed", DGC.DateProcessed);
            com.Parameters.AddWithValue("VarStatus", DGC.Status);
            if (string.IsNullOrEmpty(Convert.ToString(DGC.QuantityShipped)))
            {
                com.Parameters.AddWithValue("VarQuantityShipped", "0");
            }
            else { com.Parameters.AddWithValue("VarQuantityShipped", DGC.QuantityShipped); }
            com.Parameters.AddWithValue("VarTrackingNumber", DGC.TrackingNumber);
            com.Parameters.AddWithValue("VarCourierName", DGC.CourierName);
            com.Parameters.AddWithValue("VarMemo", DGC.Memo);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteOldOrders(string P2MON)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteOldNOtShippedOrders", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            //Procedure Parameters.
            com.Parameters.Add(new MySqlParameter("VarOrderNO", P2MON));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public void DeleteDGC(string GRSNUM)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteGCOrder", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            //Procedure Parameters.
            com.Parameters.Add(new MySqlParameter("VarOrderID", GRSNUM));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<DailyOrders> GetOrders(string ID)
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                MySqlCommand com = new MySqlCommand("GetDailyOrders", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                List<DailyOrders> DailyOrdersList = new List<DailyOrders>();
                com.Parameters.Add(new MySqlParameter("VarID", ID));

                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DailyOrders dailyOrders = new DailyOrders();

                    dailyOrders.ID = reader["ID"].ToString();
                    dailyOrders.PIN = reader["PIN"].ToString();
                    dailyOrders.EmployeeID = reader["EmployeeID"].ToString();
                    dailyOrders.FirstName =reader["FirstName"].ToString()+" "+ reader["LastName"].ToString();
                    dailyOrders.LastName = reader["FirstName"].ToString() + " " + reader["LastName"].ToString();
                    dailyOrders.DeptName = reader["DeptName"].ToString();
                    dailyOrders.DeptCode = reader["DeptCode"].ToString();
                    dailyOrders.JobTitle = reader["JobTitle"].ToString();
                    dailyOrders.PhoneNumber = reader["PhoneNumber"].ToString();
                    dailyOrders.CatalogName = reader["CatalogName"].ToString();
                    dailyOrders.RewardName = string.IsNullOrEmpty(reader["RewardName"].ToString()) ? reader["ItemDescription"].ToString() : reader["RewardName"].ToString();
                    dailyOrders.Quantity = Convert.ToInt32(reader["Quantity"]);
                    dailyOrders.Details = reader["Details"].ToString();
                    dailyOrders.HighestLevelCategory = reader["HighestLevelCategory"].ToString();
                    dailyOrders.LowestLevelCategory = reader["LowestLevelCategory"].ToString();
                    dailyOrders.Company = reader["Company"].ToString();
                    dailyOrders.Name = reader["Name"].ToString();
                    dailyOrders.Address1 = reader["Address1"].ToString();
                    dailyOrders.Address2 = reader["Address2"].ToString();
                    dailyOrders.City = reader["City"].ToString();
                    dailyOrders.State = reader["State"].ToString();
                    dailyOrders.ZipCode = reader["ZipCode"].ToString();
                    dailyOrders.Country = reader["Country"].ToString();
                    dailyOrders.P2MOrderNumber = string.IsNullOrEmpty(reader["P2MOrderNumber"].ToString()) ? reader["GRSOrderNum"].ToString() : reader["P2MOrderNumber"].ToString();
                    if (!(string.IsNullOrEmpty(reader["GRSOrderNum"].ToString())) && ((reader["Status"].ToString()).ToLower() == "po_received"))
                    {
                        dailyOrders.OrderStatus = "shipped";
                    }
                    else
                    {
                        dailyOrders.OrderStatus = reader["Status"].ToString();
                    }
                    dailyOrders.OrderCStatus = reader["CStatus"].ToString();
                    dailyOrders.DiscountCoupon = reader["DiscountCoupon"].ToString();
                    dailyOrders.RedemptionAmount = Convert.ToDouble(reader["RedemptionAmount"].ToString());
                    dailyOrders.DiscountApplied = reader["DiscountApplied"].ToString();
                    dailyOrders.MemberPaid = reader["MemberPaid"].ToString();
                    dailyOrders.PointBillingRate = Convert.ToDouble(reader["PointBillingRate"]);
                    DateTime? OrderDate = (reader["OrderDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["OrderDate"]);
                    dailyOrders.OrderDate = OrderDate;
                    dailyOrders.GRSOrderNum = reader["GRSOrderNum"].ToString();
                    //dailyOrders.PartnerSystemOrderNum = reader["PartnerSystemOrderNum"].ToString();
                    dailyOrders.ItemNumber = reader["ItemNumber"].ToString();
                    dailyOrders.ItemDescription = string.IsNullOrEmpty(reader["ItemDescription"].ToString())? reader["RewardName"].ToString(): reader["ItemDescription"].ToString();
                    dailyOrders.ItemOption = reader["ItemOption"].ToString();
                    dailyOrders.Email = reader["Email"].ToString();
                    dailyOrders.ProductCost = Convert.ToDouble(reader["ProductCost"]);
                    dailyOrders.CatalogCode = reader["CatalogCode"].ToString();
                    DateTime? DateProcessed = (reader["DateProcessed"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["DateProcessed"]);
                    dailyOrders.DateProcessed = DateProcessed;
                    dailyOrders.QuantityShipped = Convert.ToInt32(reader["QuantityShipped"]);
                    dailyOrders.TrackingNumber = reader["TrackingNumber"].ToString();
                    dailyOrders.CourierName = reader["CourierName"].ToString();
                    dailyOrders.Memo = reader["Memo"].ToString();
                    dailyOrders.Note = reader["Note"].ToString();
                    //TimeSpan span = DateTime.Now.Subtract((Convert.ToDateTime(reader["OrderDate"])));
                    //int delayed = span.Days;
                    //dailyOrders.delayed = delayed;






                    DailyOrdersList.Add(dailyOrders);
                }
                con.Close();
                return DailyOrdersList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
        //public List<GRSDailyOrders> GetDGC(string orderNO)
        //{

        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    try
        //    {

        //        MySqlCommand com = new MySqlCommand("GetGCOrders", con);
        //        com.CommandType = System.Data.CommandType.StoredProcedure;
        //        com.Parameters.Add(new MySqlParameter("VarOrderID", orderNO));
        //        List<GRSDailyOrders> DGCList = new List<GRSDailyOrders>();

        //        con.Open();
        //        // com.ExecuteReader();

        //        MySqlDataReader reader = com.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            GRSDailyOrders dgcdailyOrders = new GRSDailyOrders();
        //            dgcdailyOrders.Status = reader["Status"].ToString();
        //            dgcdailyOrders.FirstName = reader["FirstName"].ToString();
        //            dgcdailyOrders.LastName = reader["LastName"].ToString();
        //            dgcdailyOrders.UserId = reader["UserId"].ToString();
        //            dgcdailyOrders.PhoneNumber = reader["PhoneNumber"].ToString();
        //            dgcdailyOrders.CatalogName = reader["CatalogName"].ToString();
        //            dgcdailyOrders.Quantity = Convert.ToInt32(reader["Quantity"]);
        //            dgcdailyOrders.CompanyName = reader["CompanyName"].ToString();
        //            dgcdailyOrders.Address1 = reader["Address1"].ToString();
        //            dgcdailyOrders.Address2 = reader["Address2"].ToString();
        //            dgcdailyOrders.City = reader["City"].ToString();
        //            dgcdailyOrders.StateProvince = reader["State_Province"].ToString();
        //            dgcdailyOrders.ZipPostalCode = reader["Zip_PostalCode"].ToString();
        //            dgcdailyOrders.Country = reader["Country"].ToString();
        //            DateTime? OrderDate = (reader["OrderDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["OrderDate"]);
        //            dgcdailyOrders.OrderDate = OrderDate;
        //            dgcdailyOrders.GRSOrder = reader["GRSOrder"].ToString();
        //            dgcdailyOrders.PartnerSystemOrder = (reader["GRSOrder"].ToString()).Split('-')[0];
        //            dgcdailyOrders.ItemNumber = reader["ItemNumber"].ToString();
        //            dgcdailyOrders.ItemDescription = reader["ItemDescription"].ToString();
        //            dgcdailyOrders.ItemOption = reader["ItemOption"].ToString();
        //            dgcdailyOrders.Email = reader["Email"].ToString();
        //            dgcdailyOrders.ProductCost = Convert.ToDouble(reader["ProductCost"]);
        //            dgcdailyOrders.CatalogCode = reader["CatalogCode"].ToString();
        //            DateTime? DateProcessed = (reader["DateProcessed"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["DateProcessed"]);
        //            dgcdailyOrders.DateProcessed = DateProcessed;
        //            int? QuantityShipped = (reader["QuantityShipped"] == System.DBNull.Value) ? (int?)null : Convert.ToInt32(reader["QuantityShipped"]);
        //            dgcdailyOrders.QuantityShipped = QuantityShipped;
        //            dgcdailyOrders.TrackingNumber = reader["TrackingNumber"].ToString();
        //            dgcdailyOrders.CourierName = reader["CourierName"].ToString();
        //            dgcdailyOrders.Memo = reader["Memo"].ToString();
        //            //TimeSpan span = DateTime.Now.Subtract((Convert.ToDateTime(reader["ordarDate"])));
        //            //int delayed = span.Days;
        //            //dgcdailyOrders.delayed = delayed;
        //            DGCList.Add(dgcdailyOrders);
        //        }
        //        con.Close();
        //        return DGCList;
        //    }
        //    catch
        //    {
        //        con.Close();
        //        return null;
        //    }
        //}
        public void InsertDCL(ClientsDailyOrders DCO)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertClinetsDaily", con);
            //Procedure Parameters.
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.AddWithValue("VarID", DCO.P2MOrderNumber);
            com.Parameters.AddWithValue("VarFirstName", DCO.FirstName);
            com.Parameters.AddWithValue("VarLastName", DCO.LastName);
            com.Parameters.AddWithValue("VarDeptName", DCO.DeptName);
            com.Parameters.AddWithValue("VarDeptCode", DCO.DeptCode);
            com.Parameters.AddWithValue("VarPIN", DCO.PIN);
            com.Parameters.AddWithValue("VarEmployeeID", DCO.EmployeeID);
            com.Parameters.AddWithValue("VarJobTitle", DCO.JobTitle);
            com.Parameters.AddWithValue("VarPhoneNumber", DCO.PhoneNumber);
            com.Parameters.AddWithValue("VarCatalogName", DCO.CatalogName);
            com.Parameters.AddWithValue("VarRewardName", DCO.RewardName);
            if (string.IsNullOrEmpty(Convert.ToString(DCO.Quantity)))
            {
                com.Parameters.AddWithValue("VarQuantity", "0");
            }
            else { com.Parameters.AddWithValue("VarQuantity", DCO.Quantity); }
            com.Parameters.AddWithValue("VarDetails", DCO.Details);
            com.Parameters.AddWithValue("VarHighestLevelCategory", DCO.HighestLevelCategory);
            com.Parameters.AddWithValue("VarLowestLevelCategory", DCO.LowestLevelCategory);
            com.Parameters.AddWithValue("VarCompany", DCO.ShipToCompany);
            com.Parameters.AddWithValue("VarName", DCO.ShipToName);
            com.Parameters.AddWithValue("VarAddress1", DCO.ShipToAddress1);
            com.Parameters.AddWithValue("VarAddress2", DCO.ShipToAddress2);
            com.Parameters.AddWithValue("VarCity", DCO.ShipToCity);
            com.Parameters.AddWithValue("VarState", DCO.ShipToState);
            com.Parameters.AddWithValue("VarZipCode", DCO.ShipToZipCode);
            com.Parameters.AddWithValue("VarCountry", DCO.ShipToCountry);
            com.Parameters.AddWithValue("VarP2MOrderNumber", DCO.P2MOrderNumber);
            com.Parameters.AddWithValue("VarOrderStatus", DCO.OrderStatus);
            com.Parameters.AddWithValue("VarCurrentStatus", DCO.CurrentStatus);
            com.Parameters.AddWithValue("VarDiscountCoupon", DCO.DiscountCoupon);
            if (string.IsNullOrEmpty(DCO.RedemptionAmount))
            {
                com.Parameters.AddWithValue("VarRedemptionAmount", "0");
            }
            else { com.Parameters.AddWithValue("VarRedemptionAmount", DCO.RedemptionAmount); }
            com.Parameters.AddWithValue("VarMemberPaid", DCO.MemberPaid);
            com.Parameters.AddWithValue("VarDiscountApplied", DCO.DiscountApplied);
            com.Parameters.AddWithValue("VarPointBillingRate", DCO.PointBillingRate);
            com.Parameters.AddWithValue("VarOrderDate", DCO.DateandTime);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        //public List<ClientsDailyOrders> GetDCO(string orderNO)
        //{

        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    try
        //    {

        //        MySqlCommand com = new MySqlCommand("GetCLientOrders", con);
        //        com.CommandType = System.Data.CommandType.StoredProcedure;
        //        com.Parameters.Add(new MySqlParameter("VarOrderID", orderNO));
        //        List<ClientsDailyOrders> DCOList = new List<ClientsDailyOrders>();

        //        con.Open();
        //        // com.ExecuteReader();

        //        MySqlDataReader reader = com.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            ClientsDailyOrders CLO = new ClientsDailyOrders();
        //            CLO.FirstName = reader["FirstName"].ToString();
        //            CLO.LastName = reader["LastName"].ToString();
        //            CLO.DeptName = reader["DeptName"].ToString();
        //            CLO.DeptCode = reader["DeptCode"].ToString();
        //            CLO.PIN = reader["PIN"].ToString();
        //            CLO.EmployeeID = reader["EmployeeID"].ToString();
        //            CLO.JobTitle = reader["JobTitle"].ToString();
        //            CLO.PhoneNumber = reader["PhoneNumber"].ToString();
        //            CLO.CatalogName = reader["CatalogName"].ToString();
        //            CLO.RewardName = reader["RewardName"].ToString();
        //            CLO.Quantity = Convert.ToInt32(reader["Quantity"].ToString());
        //            CLO.Details = reader["Details"].ToString();
        //            CLO.HighestLevelCategory = reader["HighestLevelCategory"].ToString();
        //            CLO.LowestLevelCategory = reader["LowestLevelCategory"].ToString();
        //            CLO.ShipToCompany = reader["ShipToCompany"].ToString();
        //            CLO.ShipToName = reader["ShipToName"].ToString();
        //            CLO.ShipToAddress1 = reader["ShipToAddress1"].ToString();
        //            CLO.ShipToAddress2 = reader["ShipToAddress2"].ToString();
        //            CLO.ShipToCity = reader["ShipToCity"].ToString();
        //            CLO.ShipToState = reader["ShipToState"].ToString();
        //            CLO.ShipToZipCode = reader["ShipToZipCode"].ToString();
        //            CLO.ShipToCountry = reader["ShipToCountry"].ToString();
        //            CLO.P2MOrderNumber = reader["P2MOrderNumber"].ToString();
        //            CLO.OrderStatus = reader["OrderStatus"].ToString();
        //            CLO.CurrentStatus = reader["CurrentStatus"].ToString();
        //            CLO.DiscountCoupon = reader["DiscountCoupon"].ToString();
        //            CLO.RedemptionAmount = reader["RedemptionAmount"].ToString();
        //            CLO.DiscountApplied = reader["DiscountApplied"].ToString();
        //            CLO.PointBillingRate = Convert.ToDouble(reader["PointBillingRate"].ToString());
        //            DateTime? DateandTime = (reader["DateandTime"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["DateandTime"]);
        //            CLO.DateandTime = DateandTime;
        //            //TimeSpan span = DateTime.Now.Subtract((Convert.ToDateTime(reader["ordarDate"])));
        //            //int delayed = span.Days;
        //            //dgcdailyOrders.delayed = delayed;
        //            DCOList.Add(CLO);
        //        }
        //        con.Close();
        //        return DCOList;
        //    }
        //    catch
        //    {
        //        con.Close();
        //        return null;
        //    }
        //}
        //public void DeleteDCO(string GRSNUM)
        //{
        //    //Connection and Command objects.
        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    MySqlCommand com = new MySqlCommand("DeleteClientOrder", con);
        //    com.CommandType = System.Data.CommandType.StoredProcedure;
        //    //Procedure Parameters.
        //    com.Parameters.Add(new MySqlParameter("VarOrderID", GRSNUM));
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();

        //}
        //public void DeleteDailyOrderss(string ID)
        //{
        //    //Connection and Command objects.
        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    MySqlCommand com = new MySqlCommand("DeleteDailyOrders", con);
        //    com.CommandType = System.Data.CommandType.StoredProcedure;
        //    //Procedure Parameters.
        //    com.Parameters.Add(new MySqlParameter("VarID", ID));
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();

        //}
    }
}
