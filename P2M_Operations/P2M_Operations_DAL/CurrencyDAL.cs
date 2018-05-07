using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using P2M_Operations_Entities;

namespace P2M_Operations_DAL
{
    public class CurrencyDAL
    {
        public string ConnectionString { get; set; }

        public void InsertCurrency(Currency currency)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsrtCurrency", con);
            //Procedure Parameters.
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarName", currency.Name));
            com.Parameters.Add(new MySqlParameter("VarCountry", currency.Country));
            com.Parameters.Add(new MySqlParameter("VarPointValue_Rate", currency.PointValue_Rate));
            com.Parameters.Add(new MySqlParameter("VarUSDRate", currency.USDRate));
            com.Parameters.Add(new MySqlParameter("VarISO", currency.ISO));

            //
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateCurrency(Currency currency)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpdateCurrency", con);
            //Procedure Parameters.
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarID", currency.ID));
            com.Parameters.Add(new MySqlParameter("VarName", currency.Name));
            com.Parameters.Add(new MySqlParameter("VarCountry", currency.Country));
            com.Parameters.Add(new MySqlParameter("VarPointValue_Rate", currency.PointValue_Rate));
            com.Parameters.Add(new MySqlParameter("VarUSDRate", currency.USDRate));
            com.Parameters.Add(new MySqlParameter("VarISO", currency.ISO));
            //
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteCurrency(string  ID)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteCurrency", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarID", Convert.ToInt32(ID)));
            //Procedure Parameters.
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public List<Currency> GetCurrency()
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                MySqlCommand com = new MySqlCommand("GetCurrency", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                List<Currency> CurrencyList = new List<Currency>();
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Currency currency = new Currency();


                    currency.ID = Convert.ToInt32(reader["ID"]);
                    currency.Name = reader["Name"].ToString();
                    currency.Country = reader["Country"].ToString();
                    currency.PointValue_Rate = Convert.ToDouble(reader["PointValue_Rate"]);
                    currency.USDRate = Convert.ToDouble(reader["USDRate"]);
                    currency.ISO = reader["ISO"].ToString();




                    CurrencyList.Add(currency);
                }
                con.Close();
                return CurrencyList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }

    }
}
