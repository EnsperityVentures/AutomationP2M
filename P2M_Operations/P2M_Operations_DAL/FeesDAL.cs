using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using P2M_Operations_Entities;

namespace P2M_Operations_DAL
{
    public class FeesDAL
    {
        public string ConnectionString { get; set; }
        public void InsertFees(Fees fees)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertFees", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            //Procedure Parameters .
            com.Parameters.Add(new MySqlParameter("VarID", fees.ID));
            com.Parameters.Add(new MySqlParameter("VarRewardName", fees.RewardName));
            com.Parameters.Add(new MySqlParameter("VarShippingCost", fees.ShippingCost));
            com.Parameters.Add(new MySqlParameter("VarHandlingCost", fees.HandlingCost));
            com.Parameters.Add(new MySqlParameter("VarServiceCharge", fees.ServiceCharge));
            com.Parameters.Add(new MySqlParameter("VarSKU", fees.SKU));
            //
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteFees(string ID )
        {
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteFees", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarID", Convert.ToInt32(ID)));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public List<Fees> GetFees(string Rname )
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                MySqlCommand com = new MySqlCommand("GetFees", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                //Procedure Parameters .
                com.Parameters.Add(new MySqlParameter("VarRName", Rname));

                List<Fees> FeesList = new List<Fees>();
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Fees fees = new Fees();


                    fees.ID = Convert.ToInt32(reader["ID"]);
                    fees.RewardName = reader["RewardName"].ToString();
                    fees.ShippingCost = Convert.ToDouble(reader["ShippingCost"]);
                    fees.HandlingCost = Convert.ToDouble(reader["HandlingCost"]);
                    fees.ServiceCharge = Convert.ToDouble(reader["ServiceCharge"]);
                    fees.Total = Convert.ToDouble(reader["Total"]);
                    fees.SKU = (reader["SKU"]).ToString();




                    FeesList.Add(fees);
                }
                con.Close();
                return FeesList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
    }
}
