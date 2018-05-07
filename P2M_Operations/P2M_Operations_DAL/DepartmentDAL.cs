using System;
using System.Collections.Generic;
using System.Text;
using P2M_Operations_Entities;
using MySql.Data.MySqlClient;

namespace P2M_Operations_DAL
{
    public class DepartmentDAL
    {
        public string ConnectionString { get; set; }
        public void InsertDepartment(Department department)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("UpsertDepartments", con);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            //Procedure Parameters .
            com.Parameters.Add(new MySqlParameter("VArID", department.ID));
            com.Parameters.Add(new MySqlParameter("VarName", department.Name));
            com.Parameters.Add(new MySqlParameter("VarNameAr", department.NameAr));
            com.Parameters.Add(new MySqlParameter("VarCompany", department.CompanyName));
            //

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        //public void UpdateDepartment(Department department)
        //{
        //    //Connection and Command objects.
        //    MySqlConnection con = new MySqlConnection(ConnectionString);
        //    MySqlCommand com = new MySqlCommand("UpsertDepartments", con);

        //    //Procedure Parameters .
        //    com.Parameters.AddWithValue("VArID", department.ID);
        //    com.Parameters.AddWithValue("VarName", department.Name);
        //    com.Parameters.AddWithValue("VarNameAr", department.NameAr);
        //    com.Parameters.AddWithValue("VarCompany", department.CompanyName);
        //    //

        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();
        //}

        public void DeleteDepartment(string departmentName)
        {
            //Connection and Command objects.
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand com = new MySqlCommand("DeleteDepartments", con);

            //Procedure Parameters .
            com.CommandType = System.Data.CommandType.StoredProcedure;
            com.Parameters.Add(new MySqlParameter("VarName", departmentName));
            //

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public List<Department> GetDepartment(string departmentName)
        {

            MySqlConnection con = new MySqlConnection(ConnectionString);
            try
            {
                
                MySqlCommand com = new MySqlCommand("GetDepartments", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.Add(new MySqlParameter("VarName", departmentName));
                List<Department> DepartmentList = new List<Department>();
                con.Open();
                MySqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Department department = new Department();


                    department.ID = Convert.ToInt32(reader["ID"]);
                    department.Name = reader["Name"].ToString();
                    department.NameAr = reader["NameAr"].ToString();
                    department.CompanyName = reader["CompanyName"].ToString();




                    DepartmentList.Add(department);
                }
                con.Close();
                return DepartmentList;
            }
            catch
            {
                con.Close();
                return null;
            }
        }

    }
}
