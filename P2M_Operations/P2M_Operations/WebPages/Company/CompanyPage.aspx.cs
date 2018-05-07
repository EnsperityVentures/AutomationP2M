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

namespace P2M_Operations
{
    public partial class CompanyPage : System.Web.UI.Page
    {

        string uppath = @"~/Upload/Company/Company.csv";
        static string archivepath = @"~/Archive/Company/";
        static string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
        string output = archivepath + date + "Company.csv";


        protected void Page_Load(object sender, EventArgs e)
        {//To get the current path
         // Response.Write(Server.MapPath(".")+"<br/>");
            if (File.Exists(Server.MapPath(uppath)))
                ReadWriteCSVFile();
            if (!IsPostBack)
            {
                FillCompany();
            }

        }
        private void FillCompany()
        {
            CompanyDAL Compdal = new CompanyDAL();
            Compdal.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();

            List<Company> CompanyList = Compdal.GetCompany(null);
            gvCompany.DataSource = CompanyList;
            gvCompany.DataBind();

        }
        private void FillCompany(String Name)
        {
            CompanyDAL Compdal = new CompanyDAL();
            Compdal.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();

            List<Company> CompanyList = Compdal.GetCompany(Name);
            gvCompany.DataSource = CompanyList;
            gvCompany.DataBind();

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
                IEnumerable<Company> record = csvread.GetRecords<Company>();

                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {
                    csw.WriteRecord<Company>(rec);
                    csw.NextRecord();
                    CompanyDAL compdal = new CompanyDAL();
                    compdal.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    compdal.InsertCompany(rec);

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
                    //string Fname = System.DateTime.Now.ToString("ddMMyyhhmmss") + FileUpload1.FileName;
                    ImportFile.SaveAs(Server.MapPath("~/Upload/Company/" + ImportFile.FileName));
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
            FillCompany();
        }
        protected void gvCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteCompany")
            {
                CompanyDAL compdal = new CompanyDAL();
                compdal.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                compdal.DeleteCompany(e.CommandArgument.ToString());
                FillCompany();
            }

        }
        protected void gvCompany_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCompany.EditIndex = e.NewEditIndex;
            FillCompany();
        }
        protected void gvCompany_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CompanyDAL compdal = new CompanyDAL();
            Company com = new Company();
            compdal.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            com.Name = (gvCompany.Rows[e.RowIndex].FindControl("lblNameEdit") as Label).Text;
            com.Country = (gvCompany.Rows[e.RowIndex].FindControl("tbCountry") as TextBox).Text;
            com.NameAr = (gvCompany.Rows[e.RowIndex].FindControl("tbNameAr") as TextBox).Text;
            com.Site = (gvCompany.Rows[e.RowIndex].FindControl("tbSite") as TextBox).Text;

            compdal.InsertCompany(com);
            gvCompany.EditIndex = -1;
            FillCompany();

        }
        protected void gvCompany_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCompany.EditIndex = -1;
            FillCompany();
        }
        protected void btnAddNewComp_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
            }
            else
            {
               // this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
            }

            CompanyDAL compdal = new CompanyDAL();
            Company com = new Company();

            compdal.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            com.Name = tbAddCompany.Text;
            com.Country = tbAddCountry.Text;
            com.NameAr = tbAddArname.Text;
            com.Site = tbAddCompanytxt.Text;


            compdal.InsertCompany(com);
            gvCompany.EditIndex = -1;
            tbAddCompany.Text = string.Empty;
            tbAddCountry.Text = string.Empty;
            tbAddArname.Text = string.Empty;
            tbAddCompanytxt.Text = string.Empty;
            FillCompany();

        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            gvCompany.EditIndex = -1;
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {//ButtonSearch_Click
            CompanyDAL compdal = new CompanyDAL();
            compdal.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            string name = TxtSearchKey.Text;
            if (name != "")
            {

                FillCompany(name);
            }
            else
            {

                FillCompany();
            }
        }
        protected void gvCompany_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete Company') ");
            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            CompanyDAL Compdal = new CompanyDAL();
            Compdal.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Company> CompanyList = Compdal.GetCompany(null);

            var mem = new MemoryStream();
            var writer = new StreamWriter(mem, Encoding.UTF8, 1024, true);
            var csvWriter = new CsvWriter(writer);


            csvWriter.Configuration.Delimiter = ",";

            csvWriter.WriteField("Name");
            csvWriter.WriteField("Country");
            csvWriter.WriteField("NameAr");
            csvWriter.WriteField("Site");
            csvWriter.NextRecord();

            int lenght = CompanyList.Count - 1;
            for (int i = 0; i <= lenght; i++)
            {

                csvWriter.WriteField(CompanyList[i].Name);
                csvWriter.WriteField(CompanyList[i].Country);
                csvWriter.WriteField(CompanyList[i].NameAr);
                csvWriter.WriteField(CompanyList[i].Site);
                csvWriter.NextRecord();

            }
            writer.Flush();
            var data = Encoding.UTF8.GetString(mem.ToArray());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=Company.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Write(data.ToString());
            Response.End();
        }



    }
}