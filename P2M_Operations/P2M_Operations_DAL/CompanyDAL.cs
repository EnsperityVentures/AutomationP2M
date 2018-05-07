using System;
using P2M_Operations_Entities;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace P2M_Operations_DAL
{

    public class CompanyDAL
    {
        public string ConnectionString { get; set; }
        public void InsertCompany(Company company)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertCompany", con);
            //Procedure Parameters .
            com.CommandType =  System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarName", company.Name)); 
            com.Parameters.Add(new MySqlParameter("VarCountry", company.Country)); 
            com.Parameters.Add(new MySqlParameter("VarNameAr", company.NameAr)); 
            com.Parameters.Add(new MySqlParameter("VarSite", company.Site));
            //
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCompany(string companyName)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteCompany", con);
            //Procedure Parameters .
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarName", companyName));
            //
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        public List<Company> GetCompany(string companyName)
        {
            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                //Connection and Command objects.

                MySqlCommand com = new MySqlCommand("GetCompany", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add(new MySqlParameter("VarName", companyName));
                List<Company> CompanyList = new List<Company>();
                con.Open();
                Company company = new Company();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    company = new Company();


                    company.ID = Convert.ToInt32(reader["ID"]);
                    company.Name = reader["Name"].ToString();
                    company.Country = reader["Country"].ToString();
                    company.NameAr = reader["NameAr"].ToString();
                    company.Site = reader["Site"].ToString();

                    CompanyList.Add(company);
                }
                con.Close();
                return CompanyList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
    }
}
