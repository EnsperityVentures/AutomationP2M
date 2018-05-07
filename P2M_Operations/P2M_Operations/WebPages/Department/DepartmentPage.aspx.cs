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


namespace P2M_Operations.WebPages.Departments
{
    public partial class DepartmentPage : System.Web.UI.Page
    {
        string uppath = @"~/Upload/Department/Department.csv";
        static string archivepath = @"~/Archive/Department/";
        static string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
        string output = archivepath + date + "Department.csv";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(uppath)))
                ReadWriteCSVFile();
            if (!IsPostBack)
            {
                GetDepartments();
            }

        }
        private void GetDepartments()
        {
            DepartmentDAL departmentDAL = new DepartmentDAL();
            departmentDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Department> DepartmentsList = departmentDAL.GetDepartment(null);

            gvDept.DataSource = DepartmentsList;
            gvDept.DataBind();

        }
        private void GetDepartments(string Name)
        {
            DepartmentDAL departmentDAL = new DepartmentDAL();
            departmentDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Department> DepartmentsList = departmentDAL.GetDepartment(Name);

            gvDept.DataSource = DepartmentsList;
            gvDept.DataBind();

        }
        private void ReadWriteCSVFile()
        {
            string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
            if (File.Exists(Server.MapPath(uppath)))
            {
                StreamReader sr = new StreamReader(Server.MapPath(uppath));
                StreamWriter write = new StreamWriter(Server.MapPath(output));
                CsvReader csvread = new CsvReader(sr);
                CsvWriter csw = new CsvWriter(write);
                IEnumerable<Department> record = csvread.GetRecords<Department>();

                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {
                    csw.WriteRecord<Department>(rec);
                    csw.NextRecord();
                    DepartmentDAL departmentDAL = new DepartmentDAL();
                    departmentDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    departmentDAL.InsertDepartment(rec);

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
                    ImportFile.SaveAs(Server.MapPath("~/Upload/Department/" + ImportFile.FileName));
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
            GetDepartments();
        }
        protected void gvDept_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteDepartment")
            {
                DepartmentDAL departmentDAL = new DepartmentDAL();
                departmentDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                departmentDAL.DeleteDepartment(e.CommandArgument.ToString());
                GetDepartments();
            }

        }
        protected void gvDept_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDept.EditIndex = e.NewEditIndex;
            GetDepartments();
        }
        protected void gvDept_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DepartmentDAL departmentDAL = new DepartmentDAL();
            departmentDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            Department dept = new Department();
            dept.ID = Convert.ToInt32((gvDept.Rows[e.RowIndex].FindControl("txIDEdit") as TextBox).Text);
            dept.Name = (gvDept.Rows[e.RowIndex].FindControl("txNameEdit") as TextBox).Text;
            dept.NameAr = (gvDept.Rows[e.RowIndex].FindControl("tbNameAr") as TextBox).Text;
            dept.CompanyName = (gvDept.Rows[e.RowIndex].FindControl("tbCompName") as TextBox).Text;

            departmentDAL.InsertDepartment(dept);
            gvDept.EditIndex = -1;
            GetDepartments();

        }
        protected void gvDept_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDept.EditIndex = -1;
            GetDepartments();
        }
        protected void btnAddNewDept_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            }
            else
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }

            DepartmentDAL departmentDAL = new DepartmentDAL();
            Department com = new Department();

            departmentDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            com.ID = Convert.ToInt32(tbAddID.Text);
            com.Name = tbAddDepartmentName.Text;
            com.NameAr = tbAddArname.Text;
            com.CompanyName = tbAddCompName.Text;


            departmentDAL.InsertDepartment(com);
            gvDept.EditIndex = -1;
            tbAddID.Text = string.Empty;
            tbAddDepartmentName.Text = string.Empty;
            tbAddArname.Text = string.Empty;
            tbAddCompName.Text = string.Empty;
            GetDepartments();

        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            gvDept.EditIndex = -1;
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {//ButtonSearch_Click
            DepartmentDAL departmentDAL = new DepartmentDAL();
            departmentDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            if (TxtSearchKey.Text != "")
            {
                string name = TxtSearchKey.Text;
                GetDepartments(name);
            }
            else
            {
                GetDepartments(null);
            }
        }
        protected void gvDept_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete Department') ");

            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DepartmentDAL departmentDAL = new DepartmentDAL();
            departmentDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Department> DepartmentList = departmentDAL.GetDepartment(null);

            var mem = new MemoryStream();
            var writer = new StreamWriter(mem, Encoding.UTF8, 1024, true);
            var csvWriter = new CsvWriter(writer);


            csvWriter.Configuration.Delimiter = ",";

            csvWriter.WriteField("ID");
            csvWriter.WriteField("Name");
            csvWriter.WriteField("NameAr");
            csvWriter.WriteField("CompanyName");
            csvWriter.NextRecord();

            int lenght = DepartmentList.Count - 1;
            for (int i = 0; i <= lenght; i++)
            {

                csvWriter.WriteField(DepartmentList[i].ID);
                csvWriter.WriteField(DepartmentList[i].Name);
                csvWriter.WriteField(DepartmentList[i].NameAr);
                csvWriter.WriteField(DepartmentList[i].CompanyName);
                csvWriter.NextRecord();

            }
            writer.Flush();
            var data = Encoding.UTF8.GetString(mem.ToArray());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=Department.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Write(data.ToString());
            Response.End();
        }
    }
}