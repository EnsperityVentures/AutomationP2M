using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using P2M_Operations_Entities;

namespace P2M_Operations_DAL
{
    public class MembersDAL
    {
        public string ConnectionString { get; set; }
        public void InsertMembers(Members members)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertMember", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            //Procedure Parameters.
            com.Parameters.Add(new MySqlParameter("VarPin", members.Pin));
            com.Parameters.Add(new MySqlParameter("VarEmployeeN", members.EmployeeNumber));
            com.Parameters.Add(new MySqlParameter("VarFirstName", members.FirstName));
            com.Parameters.Add(new MySqlParameter("VarLastName", members.LastName));
            com.Parameters.Add(new MySqlParameter("VarEmail", members.Email));
            com.Parameters.Add(new MySqlParameter("VarJobTitle", members.JobTitle));
            com.Parameters.Add(new MySqlParameter("VarHireDate", members.HireDate));
            com.Parameters.Add(new MySqlParameter("VarBirthDate", members.BirthDate));
            com.Parameters.Add(new MySqlParameter("VarAddress1", members.Address1));
            com.Parameters.Add(new MySqlParameter("VarAddress2", members.Address2));
            com.Parameters.Add(new MySqlParameter("VarCity", members.City));
            com.Parameters.Add(new MySqlParameter("VarProvinceState", members.ProvinceState));
            com.Parameters.Add(new MySqlParameter("VarCountry", members.Country));
            com.Parameters.Add(new MySqlParameter("VarPostalCode", members.PostalCode));
            com.Parameters.Add(new MySqlParameter("VarTelAreaCode", members.TelephoneAreaCode));
            com.Parameters.Add(new MySqlParameter("VarTelephoneNumber", members.TelephoneNumber));
            com.Parameters.Add(new MySqlParameter("VarTelephoneCountryCode", members.TelephoneCountryCode));
            com.Parameters.Add(new MySqlParameter("VarLanguageCode", members.LanguageCode));
            com.Parameters.Add(new MySqlParameter("VarDepartmentCode", members.DepartmentCode));
            com.Parameters.Add(new MySqlParameter("VarDeptName", members.DepartmentName));
            com.Parameters.Add(new MySqlParameter("VarAccessGroups", members.AccessGroups));
            com.Parameters.Add(new MySqlParameter("VarEmployeeType", members.EmployeeType));
            com.Parameters.Add(new MySqlParameter("VarDeletionDate", members.DeletionDate));
            com.Parameters.Add(new MySqlParameter("VarPassword", members.Password));
            com.Parameters.Add(new MySqlParameter("VarDisableLogin", members.DisableLogin));
            com.Parameters.Add(new MySqlParameter("VarDisableEarn", members.DisableEarn));
            com.Parameters.Add(new MySqlParameter("VarUsername", members.Username));
            com.Parameters.Add(new MySqlParameter("VarFnameAR", members.FnameAR));
            com.Parameters.Add(new MySqlParameter("VarLnameAR", members.LnameAR));
            com.Parameters.Add(new MySqlParameter("VarPositionAr", members.PositionAr));
            com.Parameters.Add(new MySqlParameter("VarMNA", members.MNA));
            com.Parameters.Add(new MySqlParameter("VarMNE", members.MNE));
            com.Parameters.Add(new MySqlParameter("VarMETA", members.META));
            com.Parameters.Add(new MySqlParameter("VarChild", members.Child));
            com.Parameters.Add(new MySqlParameter("VarMrgDate", members.MrgDate));
            com.Parameters.Add(new MySqlParameter("VarCompName", members.CompanyName));
            
            //
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        //public void UpdateMembers(Members members)
        //{
        //    //Connection and Command objects.
        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    MySqlCommand com = new MySqlCommand("UpsertMember", con);
        //    //Procedure Parameters.

        //    com.Parameters.AddWithValue("VarPin", members.Pin);
        //    com.Parameters.AddWithValue("VarEmployeeN", members.EmployeeNumber);
        //    com.Parameters.AddWithValue("VarFirstName", members.FirstName);
        //    com.Parameters.AddWithValue("VarLastName", members.LastName);
        //    com.Parameters.AddWithValue("VarEmail", members.Email);
        //    com.Parameters.AddWithValue("VarJobTitle", members.JobTitle);
        //    com.Parameters.AddWithValue("VarHireDate", members.HireDate);
        //    com.Parameters.AddWithValue("VarBirthDate", members.BirthDate);
        //    com.Parameters.AddWithValue("VarMobileNumber", members.MobileNumber);
        //    com.Parameters.AddWithValue("VarEmployeeType", members.EmployeeType);
        //    com.Parameters.AddWithValue("VarAddress", members.Address);
        //    com.Parameters.AddWithValue("VarCity", members.City);
        //    com.Parameters.AddWithValue("VarProvinceState", members.Province_State);
        //    com.Parameters.AddWithValue("VarCountry", members.Country);
        //    com.Parameters.AddWithValue("VarPostalCode", members.PostalCode);
        //    com.Parameters.AddWithValue("VarTelAreaCode", members.TelephoneAreaCode);
        //    com.Parameters.AddWithValue("VarLanguageCode", members.LanguageCode);
        //    com.Parameters.AddWithValue("VarAccessGroups", members.AccessGroups);
        //    com.Parameters.AddWithValue("VarDeletionDate", members.DeletionDate);
        //    com.Parameters.AddWithValue("VarPassword", members.Password);
        //    com.Parameters.AddWithValue("VarDisableLogin", members.DisableLogin);
        //    com.Parameters.AddWithValue("VarDisableEarn", members.DisableEarn);
        //    com.Parameters.AddWithValue("VarUsername", members.Username);
        //    com.Parameters.AddWithValue("VarFnameAR", members.FnameAR);
        //    com.Parameters.AddWithValue("VarLnameAR", members.LnameAR);
        //    com.Parameters.AddWithValue("VarPositionAr", members.PositionAr);
        //    com.Parameters.AddWithValue("VarMNA", members.MNA);
        //    com.Parameters.AddWithValue("VarMNE", members.MNE);
        //    com.Parameters.AddWithValue("VarMETA", members.META);
        //    com.Parameters.AddWithValue("VarChild", members.Child);
        //    com.Parameters.AddWithValue("VarMrgDate", members.MrgDate);
        //    com.Parameters.AddWithValue("VarCompName", members.CompName);
        //    com.Parameters.AddWithValue("VarDeptName", members.DeptName);
        //    //
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();
        //}
        public void DeleteMembers(string pin,string empid, string compname)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteMember", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            //Procedure Parameters.
            com.Parameters.Add(new MySqlParameter("VarPin", pin));
            com.Parameters.Add(new MySqlParameter("VarEmpID", empid));
            com.Parameters.Add(new MySqlParameter("VarCompName", compname));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }

        public List<Members> GetMembers(string EmployeeNumber, string CompName, string Name)
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                MySqlCommand com = new MySqlCommand("GetMembers", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                List<Members> membersList = new List<Members>();
                com.Parameters.Add(new MySqlParameter("VarEMPID", EmployeeNumber));
                com.Parameters.Add(new MySqlParameter("VarCompID", CompName));
                com.Parameters.Add(new MySqlParameter("Varname", Name));

                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                   Members members = new Members();


                    members.Pin = reader["Pin"].ToString();
                    members.EmployeeNumber = reader["EmployeeNumber"].ToString();
                    members.FirstName = reader["FirstName"].ToString();
                    members.LastName = reader["LastName"].ToString();
                    members.Email = reader["Email"].ToString();
                    members.JobTitle = reader["JobTitle"].ToString();
                    DateTime? HireDate = (reader["HireDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["HireDate"]);
                    members.HireDate = HireDate;
                    DateTime? BirthDate = (reader["BirthDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["BirthDate"]);
                    members.BirthDate = BirthDate;
                    members.Address1 = reader["Address1"].ToString();
                    members.Address2 = reader["Address2"].ToString();
                    members.City = reader["City"].ToString();
                    members.ProvinceState = reader["Province_State"].ToString();
                    members.Country = reader["Country"].ToString();
                    members.PostalCode = reader["PostalCode"].ToString();
                    members.EmployeeType = reader["EmployeeType"].ToString();
                    members.TelephoneAreaCode = reader["TelephoneAreaCode"].ToString();
                    members.TelephoneNumber = reader["TelephoneNumber"].ToString();
                    members.TelephoneAreaCode = reader["TelephoneAreaCode"].ToString();
                    members.LanguageCode = reader["LanguageCode"].ToString();
                    members.DepartmentCode = reader["DepartmentCode"].ToString();
                    members.AccessGroups = reader["AccessGroups"].ToString();
                    members.EmployeeType = reader["EmployeeType"].ToString();
                    DateTime? DeletionDate = (reader["DeletionDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["DeletionDate"]);
                    members.DeletionDate = DeletionDate;
                    members.Password = reader["Password"].ToString();
                    members.DisableLogin = reader["DisableLogin"].ToString();
                    members.DisableEarn = reader["DisableEarn"].ToString();
                    members.Username = reader["Username"].ToString();
                    members.FnameAR = reader["FnameAR"].ToString();
                    members.LnameAR = reader["LnameAR"].ToString();
                    members.PositionAr = reader["PositionAr"].ToString();
                    members.MNA = reader["MNA"].ToString();
                    members.MNE = reader["MNE"].ToString();
                    members.META = reader["META"].ToString();
                    members.Child = reader["Child"].ToString();
                    DateTime? MrgDate = (reader["MrgDate"] == System.DBNull.Value) ? (DateTime?)null : Convert.ToDateTime(reader["MrgDate"]);
                    members.MrgDate = MrgDate;
                    members.CompanyName = reader["CompanyName"].ToString();
                    members.DepartmentName = reader["DepartmentName"].ToString();
                    membersList.Add(members);
                }
                con.Close();
                return membersList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }
    }
}
