using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CsvHelper;
using System.IO;
using P2M_Operations_Entities;
using P2M_Operations_DAL;
using System.Configuration;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace P2M_Operations.WebPages.Member
{
    public partial class MembersPage : System.Web.UI.Page
    {
        string uppath = @"~/Upload/Members/Members.csv";
        // string ext = @"~/Upload/Members/";
        static string archivepath = @"~/Archive/Members/";
        static string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
        string output = archivepath + date + "Members.csv";
        static string comp;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(uppath)))
                ReadWriteCSVFile();
            if (!IsPostBack)
            {
                //GetMembers(null, null, null);
                FillCompanyddl();
            }
        }
        private void GetMembers(string emp, string comp, string name)
        {
            MembersDAL memberDAL = new MembersDAL();
            memberDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Members> MembersList = memberDAL.GetMembers(emp, comp, name);

            gvMembers.DataSource = MembersList;
            gvMembers.DataBind();

        }
        private void ReadWriteCSVFile()
        {
            string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
            if (File.Exists(Server.MapPath(uppath)))
            {

                StreamReader sr = new StreamReader(Server.MapPath(uppath));
                StreamWriter write = new StreamWriter(Server.MapPath(output));
                CsvReader csvread = new CsvReader(sr);
                csvread.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", "").Replace("/", string.Empty).Replace("#", string.Empty).Replace(".", string.Empty);
                //csvread.Configuration.TypeConverterOptionsCache.GetOptions<DateTime?>().NullValues.Add("NULL");
                CsvWriter csw = new CsvWriter(write);
                IEnumerable<Members> record = csvread.GetRecords<Members>();

                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {
                    //csvread.Configuration.TypeConverterOptionsCache.GetOptions<DateTime?>().NullValues.Add("NULL");
                    csw.WriteRecord<Members>(rec);
                    csw.NextRecord();
                    MembersDAL membersDAL = new MembersDAL();
                    membersDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    membersDAL.InsertMembers(rec);

                }
                sr.Close();
                write.Close();//close file streams

                if (File.Exists(Server.MapPath(uppath)))
                {
                    File.Delete(Server.MapPath(uppath));
                }
            }
        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (ImportFile.HasFile)
            {
                // Get the file extension
                string fileExtension = System.IO.Path.GetExtension(ImportFile.FileName);

                if (fileExtension.ToLower() != ".csv" && fileExtension.ToLower() != ".xlsx")
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only files with .csv and .xlsx extension are allowed";
                }
                else
                {

                    // Upload the file
                    //string Fname = System.DateTime.Now.ToString("ddMMyyhhmmss") + ImportFile.FileName;
                    ImportFile.SaveAs(Server.MapPath("~/Upload/Members/" + ImportFile.FileName));
                    //FileUpload1.SaveAs(Server.MapPath("~/Archive/" + FileUpload1.FileName));
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "File uploaded successfully";
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select a file";
            }
            ReadWriteCSVFile();
            GetMembers(null, null, null);
        }
        protected void gvMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteMembers")
            {
                MembersDAL membersDAL = new MembersDAL();
                membersDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();


                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                string pin = commandArgs[0];
                string empid = commandArgs[1];
                string compname = commandArgs[2];
                if (pin != null)
                {
                    membersDAL.DeleteMembers(pin, null, null);
                    GetMembers(null, null, null);
                }
                else if (empid != null)
                {
                    membersDAL.DeleteMembers(null, empid, null);
                    GetMembers(null, null, null);
                }
                else if (pin != null && empid != null)
                {
                    membersDAL.DeleteMembers(null, null, compname);
                    GetMembers(null, null, null);
                }
            }

        }
        protected void gvMembers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMembers.EditIndex = e.NewEditIndex;
            GetMembers(null, null, null);
        }
        protected void gvMembers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            MembersDAL membersDAL = new MembersDAL();
            membersDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            Members Mem = new Members();
            Mem.Pin = (gvMembers.Rows[e.RowIndex].FindControl("lblPinEdit") as Label).Text;
            Mem.EmployeeNumber = (gvMembers.Rows[e.RowIndex].FindControl("lblEmployeeNumberEdit") as Label).Text;
            Mem.FirstName = (gvMembers.Rows[e.RowIndex].FindControl("tbFirstName") as TextBox).Text;
            Mem.LastName = (gvMembers.Rows[e.RowIndex].FindControl("tbLastName") as TextBox).Text;
            Mem.Email = (gvMembers.Rows[e.RowIndex].FindControl("tbEmail") as TextBox).Text;
            Mem.JobTitle = (gvMembers.Rows[e.RowIndex].FindControl("tbJobTitle") as TextBox).Text;
            DateTime? HireDate = ((gvMembers.Rows[e.RowIndex].FindControl("tbHireDate") as TextBox).Text=="") ? (DateTime?)null : Convert.ToDateTime((gvMembers.Rows[e.RowIndex].FindControl("tbHireDate") as TextBox).Text);
            Mem.HireDate = HireDate;
            DateTime? BirthDate = ((gvMembers.Rows[e.RowIndex].FindControl("tbBirthDate") as TextBox).Text == "") ? (DateTime?)null : Convert.ToDateTime((gvMembers.Rows[e.RowIndex].FindControl("tbBirthDate") as TextBox).Text);
            Mem.BirthDate = BirthDate;
            Mem.Address1 = (gvMembers.Rows[e.RowIndex].FindControl("tbAddress1") as TextBox).Text;
            Mem.Address2 = (gvMembers.Rows[e.RowIndex].FindControl("tbAddress2") as TextBox).Text;
            Mem.City = (gvMembers.Rows[e.RowIndex].FindControl("tbCity") as TextBox).Text;
            Mem.ProvinceState = (gvMembers.Rows[e.RowIndex].FindControl("tbProvinceState") as TextBox).Text;
            Mem.Country = (gvMembers.Rows[e.RowIndex].FindControl("tbCountry") as TextBox).Text;
            Mem.PostalCode = (gvMembers.Rows[e.RowIndex].FindControl("tbPostalCode") as TextBox).Text;
            Mem.TelephoneAreaCode = (gvMembers.Rows[e.RowIndex].FindControl("tbTelephoneAreaCode") as TextBox).Text;
            Mem.TelephoneNumber = (gvMembers.Rows[e.RowIndex].FindControl("tbTelephoneNumber") as TextBox).Text;
            Mem.TelephoneCountryCode = (gvMembers.Rows[e.RowIndex].FindControl("tbTelephoneCountryCode") as TextBox).Text;
            Mem.LanguageCode = (gvMembers.Rows[e.RowIndex].FindControl("tbLanguageCode") as TextBox).Text;
            Mem.DepartmentCode = (gvMembers.Rows[e.RowIndex].FindControl("tbDepartmentCode") as TextBox).Text;
            Mem.DepartmentName = (gvMembers.Rows[e.RowIndex].FindControl("tbDepartmentName") as TextBox).Text;
            Mem.AccessGroups = (gvMembers.Rows[e.RowIndex].FindControl("tbAccessGroups") as TextBox).Text;
            Mem.EmployeeType = (gvMembers.Rows[e.RowIndex].FindControl("tbEmployeeType") as TextBox).Text;
            DateTime? DeletionDate = ((gvMembers.Rows[e.RowIndex].FindControl("tbDeletionDate") as TextBox).Text == "") ? (DateTime?)null : Convert.ToDateTime((gvMembers.Rows[e.RowIndex].FindControl("tbDeletionDate") as TextBox).Text);
            Mem.DeletionDate = DeletionDate;
            Mem.Password = (gvMembers.Rows[e.RowIndex].FindControl("tbPassword") as TextBox).Text;
            Mem.DisableLogin = (gvMembers.Rows[e.RowIndex].FindControl("tbDisableLogin") as TextBox).Text;
            Mem.DisableEarn = (gvMembers.Rows[e.RowIndex].FindControl("tbDisableEarn") as TextBox).Text;
            Mem.Username = (gvMembers.Rows[e.RowIndex].FindControl("tbUsername") as TextBox).Text;
            Mem.FnameAR = (gvMembers.Rows[e.RowIndex].FindControl("tbFnameAR") as TextBox).Text;
            Mem.LnameAR = (gvMembers.Rows[e.RowIndex].FindControl("tbLnameAR") as TextBox).Text;
            Mem.PositionAr = (gvMembers.Rows[e.RowIndex].FindControl("tbPositionAr") as TextBox).Text;
            Mem.MNA = (gvMembers.Rows[e.RowIndex].FindControl("tbMNA") as TextBox).Text;
            Mem.MNE = (gvMembers.Rows[e.RowIndex].FindControl("tbMNE") as TextBox).Text;
            Mem.META = (gvMembers.Rows[e.RowIndex].FindControl("tbMETA") as TextBox).Text;
            Mem.Child = (gvMembers.Rows[e.RowIndex].FindControl("tbChild") as TextBox).Text;
            DateTime? MrgDate = ((gvMembers.Rows[e.RowIndex].FindControl("tbMrgDate") as TextBox).Text == "") ? (DateTime?)null : Convert.ToDateTime((gvMembers.Rows[e.RowIndex].FindControl("tbMrgDate") as TextBox).Text);
            Mem.MrgDate = MrgDate;
            Mem.CompanyName = (gvMembers.Rows[e.RowIndex].FindControl("tbCompName") as TextBox).Text;
            Mem.DepartmentName = (gvMembers.Rows[e.RowIndex].FindControl("tbDepartmentName") as TextBox).Text;
            membersDAL.InsertMembers(Mem);
            gvMembers.EditIndex = -1;
            GetMembers(null, null, null);
        }
        protected void gvMembers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMembers.EditIndex = -1;
            GetMembers(null, null, null);
        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            gvMembers.EditIndex = -1;
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {//ButtonSearch_Click
            MembersDAL membersDAL = new MembersDAL();
            membersDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            if (CompanyDDL.SelectedValue != "")
            {
                 comp = CompanyDDL.SelectedValue;
                GetMembers(null, comp, null);
            }
            else if (tbSearchEmpID.Text != "")
            {
                string empid = tbSearchEmpID.Text;
                GetMembers(empid, comp, null);
            }
            else if (tbSearchName.Text != "")
            {
                string name = tbSearchName.Text;
                GetMembers(null, comp, name);
            }
            else
            {
                GetMembers(null, null, null);
            }
        }
        protected void gvMembers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete Employee') ");

            }

        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            MembersDAL membersDAL = new MembersDAL();
            membersDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Members> MembersList = membersDAL.GetMembers(null, comp, null);

            var mem = new MemoryStream();
            var writer = new StreamWriter(mem, Encoding.UTF8, 1024, true);
            var csvWriter = new CsvWriter(writer);


            csvWriter.Configuration.Delimiter = ",";

            csvWriter.WriteField("Pin");
            csvWriter.WriteField("Employee Number");
            csvWriter.WriteField("First Name");
            csvWriter.WriteField("Last Name");
            csvWriter.WriteField("Email");
            csvWriter.WriteField("Job Title");
            csvWriter.WriteField("Hire Date");
            csvWriter.WriteField("Birth Date");
            csvWriter.WriteField("Address1");
            csvWriter.WriteField("Address2");
            csvWriter.WriteField("City");
            csvWriter.WriteField("Province/State");
            csvWriter.WriteField("Country");
            csvWriter.WriteField("Postal Code");
            csvWriter.WriteField("Telephone Area Code");
            csvWriter.WriteField("Telephone Number");
            csvWriter.WriteField("Telephone Country Code");
            csvWriter.WriteField("Language Code");
            csvWriter.WriteField("Department Code");
            csvWriter.WriteField("Department Name");
            csvWriter.WriteField("Access Groups");
            csvWriter.WriteField("Employee Type");
            csvWriter.WriteField("Deletion Date");
            csvWriter.WriteField("Password");
            csvWriter.WriteField("Disable Login");
            csvWriter.WriteField("Disable Earn");
            csvWriter.WriteField("Username");
            csvWriter.WriteField("FnameAR");
            csvWriter.WriteField("LnameAR");
            csvWriter.WriteField("PositionAr");
            csvWriter.WriteField("MNA");
            csvWriter.WriteField("MNE");
            csvWriter.WriteField("META");
            csvWriter.WriteField("Child");
            csvWriter.WriteField("MrgDate");
            csvWriter.WriteField("Company Name");
            csvWriter.NextRecord();

            int lenght = MembersList.Count - 1;
            for (int i = 0; i <= lenght; i++)
            {

                csvWriter.WriteField(MembersList[i].Pin);
                csvWriter.WriteField(MembersList[i].EmployeeNumber);
                csvWriter.WriteField(MembersList[i].FirstName);
                csvWriter.WriteField(MembersList[i].LastName);
                csvWriter.WriteField(MembersList[i].Email);
                csvWriter.WriteField(MembersList[i].JobTitle);
                csvWriter.WriteField(MembersList[i].HireDate);
                csvWriter.WriteField(MembersList[i].BirthDate);
                csvWriter.WriteField(MembersList[i].Address1);
                csvWriter.WriteField(MembersList[i].Address2);
                csvWriter.WriteField(MembersList[i].City);
                csvWriter.WriteField(MembersList[i].ProvinceState);
                csvWriter.WriteField(MembersList[i].Country);
                csvWriter.WriteField(MembersList[i].PostalCode);
                csvWriter.WriteField(MembersList[i].TelephoneAreaCode);
                csvWriter.WriteField(MembersList[i].TelephoneNumber);
                csvWriter.WriteField(MembersList[i].TelephoneAreaCode);
                csvWriter.WriteField(MembersList[i].LanguageCode);
                csvWriter.WriteField(MembersList[i].DepartmentCode);
                csvWriter.WriteField(MembersList[i].DepartmentName);
                csvWriter.WriteField(MembersList[i].AccessGroups);
                csvWriter.WriteField(MembersList[i].EmployeeType);
                csvWriter.WriteField(MembersList[i].DeletionDate);
                csvWriter.WriteField(MembersList[i].Password);
                csvWriter.WriteField(MembersList[i].DisableLogin);
                csvWriter.WriteField(MembersList[i].DisableEarn);
                csvWriter.WriteField(MembersList[i].Username);
                csvWriter.WriteField(MembersList[i].FnameAR);
                csvWriter.WriteField(MembersList[i].LnameAR);
                csvWriter.WriteField(MembersList[i].PositionAr);
                csvWriter.WriteField(MembersList[i].MNA);
                csvWriter.WriteField(MembersList[i].MNE);
                csvWriter.WriteField(MembersList[i].META);
                csvWriter.WriteField(MembersList[i].Child);
                csvWriter.WriteField(MembersList[i].MrgDate);
                csvWriter.WriteField(MembersList[i].CompanyName);
                csvWriter.NextRecord();

            }
            writer.Flush();
            var data = Encoding.UTF8.GetString(mem.ToArray());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=Members.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Write(data.ToString());
            Response.End();
        }
        protected void FillCompanyddl()
        {
            CompanyDDL.Items.Insert(0, new ListItem("--Select Company--", "0"));
            string constr = ConfigurationManager.ConnectionStrings["MySQLConn"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT Name FROM  `shobingg_P2M_Operations`.`Clients Invoices` group by Company"))
                {
                    MySqlDataAdapter adp = new MySqlDataAdapter("SELECT ID,Name FROM  `shobingg_P2M_Operations`.`Company` ", con);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0) { }
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    //CompanyDDL.DataSource = cmd.ExecuteReader()
                    CompanyDDL.DataSource = dt;
                    CompanyDDL.DataTextField = "Name";
                    CompanyDDL.DataValueField = "ID";
                    CompanyDDL.DataBind();
                }
                con.Close();

            }
        }
    }
}