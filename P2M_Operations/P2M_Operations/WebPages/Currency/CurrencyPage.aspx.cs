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

namespace P2M_Operations.WebPages.WCurrency
{
    public partial class CurrencyPage : System.Web.UI.Page
    {
        string uppath = @"~/Upload/Currency/Currency.csv";
        static string archivepath = @"~/Archive/Currency/";
        static string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
        string output = archivepath + date + "Currency.csv";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(uppath)))
                ReadWriteCSVFile();
            if (!IsPostBack)
            {
                GetCurrency();
            }
        }
        private void GetCurrency()
        {
            CurrencyDAL currencyDAL = new CurrencyDAL();
            currencyDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Currency> CurrencyList = currencyDAL.GetCurrency();
            gvCurrency.DataSource = CurrencyList;
            gvCurrency.DataBind();
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
                IEnumerable<Currency> record = csvread.GetRecords<Currency>();

                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {
                    csw.WriteRecord<Currency>(rec);
                    csw.NextRecord();
                    CurrencyDAL currencyDAL = new CurrencyDAL();
                    currencyDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    currencyDAL.InsertCurrency(rec);

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
                    ImportFile.SaveAs(Server.MapPath("~/Upload/Currency/" + ImportFile.FileName));
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
            GetCurrency();
        }
        protected void gvCurrency_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteCurrency")
            {
                CurrencyDAL currencyDAL = new CurrencyDAL();
                currencyDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                currencyDAL.DeleteCurrency(e.CommandArgument.ToString());
                GetCurrency();
            }
        }
        protected void btnAddNewCurr_Click(object sender, EventArgs e)
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
            CurrencyDAL currencyDAL = new CurrencyDAL();
            Currency com = new Currency();
            currencyDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            com.Name = tbCurrncyName.Text;
            com.Country = (tbCountry.Text);
            com.PointValue_Rate = Convert.ToDouble(tbPointValue_Rate.Text);
            com.USDRate = Convert.ToDouble(tbusdrate.Text);
            com.ISO = (tbISO.Text);


            currencyDAL.InsertCurrency(com);
            gvCurrency.EditIndex = -1;
            tbCurrncyName.Text = string.Empty;
            tbCountry.Text = string.Empty;
            tbPointValue_Rate.Text = string.Empty;
            tbusdrate.Text= string.Empty;
            GetCurrency();

        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            gvCurrency.EditIndex = -1;
        }
        protected void gvCurrency_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete Currency') ");
            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            CurrencyDAL currencyDAL = new CurrencyDAL();
            Currency com = new Currency();
            currencyDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Currency> CurrncyList = currencyDAL.GetCurrency();

            var mem = new MemoryStream();
            var writer = new StreamWriter(mem, Encoding.UTF8, 1024, true);
            var csvWriter = new CsvWriter(writer);


            csvWriter.Configuration.Delimiter = ",";


            csvWriter.WriteField("Name");
            csvWriter.WriteField("Country");
            csvWriter.WriteField("PointValue_Rate");
            csvWriter.WriteField("USDRate");
            csvWriter.WriteField("ISO");
            csvWriter.NextRecord();

            int lenght = CurrncyList.Count - 1;
            for (int i = 0; i <= lenght; i++)
            {

                csvWriter.WriteField(CurrncyList[i].Name);
                csvWriter.WriteField(CurrncyList[i].Country);
                csvWriter.WriteField(CurrncyList[i].PointValue_Rate);
                csvWriter.WriteField(CurrncyList[i].USDRate);
                csvWriter.WriteField(CurrncyList[i].ISO);
                csvWriter.NextRecord();

            }
            writer.Flush();
            var data = Encoding.UTF8.GetString(mem.ToArray());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=Currency.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Write(data.ToString());
            Response.End();
        }
        protected void gvCurrency_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCurrency.EditIndex = -1;
            GetCurrency();
        }
        protected void gvCurrency_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCurrency.EditIndex = e.NewEditIndex;
            GetCurrency();
        }
        protected void gvCurrency_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            CurrencyDAL currencyDAL = new CurrencyDAL();
            currencyDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            Currency com = new Currency();
            com.ID = Convert.ToInt32((gvCurrency.DataKeys[e.RowIndex].Values["ID"]));
            com.Name = (gvCurrency.Rows[e.RowIndex].FindControl("tbCurrName") as TextBox).Text;
            com.Country = (gvCurrency.Rows[e.RowIndex].FindControl("tbCountry") as TextBox).Text;
            com.PointValue_Rate = Convert.ToDouble((gvCurrency.Rows[e.RowIndex].FindControl("tbPointValue_Rate") as TextBox).Text);
            com.USDRate= Convert.ToDouble((gvCurrency.Rows[e.RowIndex].FindControl("tbusdrate") as TextBox).Text);
            com.ISO = (gvCurrency.Rows[e.RowIndex].FindControl("tbISO") as TextBox).Text;

            currencyDAL.UpdateCurrency(com);
            gvCurrency.EditIndex = -1;
            GetCurrency();
        }

    }
}