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

namespace P2M_Operations.WebPages.GiftCardsInvoice
{
    public partial class GiftCardsInvoices : System.Web.UI.Page
    {
        string uppath = @"~/Upload/GiftCardsInvoices/GiftCardsInvoices.csv";
        static string archivepath = @"~/Archive/GiftCardsInvoices/";
        static string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
        string output = archivepath + date + "GiftCardsInvoices.csv";
        double TotalLocalCost;
        double TotalUSDCost;
        static DateTime sdate;
        static DateTime edate;
        static string searcho;
        static string searche;
        static string selectedtext;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (File.Exists(Server.MapPath(uppath)))
            {
                ReadWriteCSVFile();
            }
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                if (sdate != DateTime.MinValue) { GetGiftCardsInvoice(searcho, searche, sdate, edate); }
                else if (searcho != "")
                {
                    GetGiftCardsInvoice(searcho, searche, sdate, edate);
                }
                else if (searche != "")
                {

                    GetGiftCardsInvoice(searcho, searche, sdate, edate);
                }
            }
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
                IEnumerable<Gift_Cards_Invoice> record = csvread.GetRecords<Gift_Cards_Invoice>();

                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {
                    csw.WriteRecord<Gift_Cards_Invoice>(rec);
                    csw.NextRecord();
                    GiftCardsInvoiceDAL GCI = new GiftCardsInvoiceDAL();
                    GCI.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    GCI.InsertGiftCardsInvoice(rec);

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
                    ImportFile.SaveAs(Server.MapPath("~/Upload/GiftCardsInvoices/" + ImportFile.FileName));
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
            GetGiftCardsInvoice(searcho, searche, sdate, edate);
        }
        private void GetGiftCardsInvoice(string OrederNo, string empID, DateTime sdate, DateTime edate)
        {
            string ONO = OrederNo;
            string empid = empID;
            GiftCardsInvoiceDAL GCIDAL = new GiftCardsInvoiceDAL();
            GCIDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();

            List<Gift_Cards_Invoice> GCIList = GCIDAL.GetGiftCardsInvoice(ONO, empid, sdate, edate);
            gvGCI.DataSource = GCIList;
            gvGCI.DataBind();
        }
        //private void GetGiftCardsInvoice(DateTime sdate, DateTime edate)
        //{
        //    GiftCardsInvoiceDAL GCIDAL = new GiftCardsInvoiceDAL();
        //    GCIDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();

        //    List<Gift_Cards_Invoice> GCIList = GCIDAL.GetGiftCardsInvoice(null, null, 0, sdate, edate);
        //    gvGCI.DataSource = GCIList;
        //    gvGCI.DataBind();
        //}
        protected void gvGCI_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteGC")
            {
                GiftCardsInvoiceDAL GCIDAL = new GiftCardsInvoiceDAL();
                GCIDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                GCIDAL.DeleteGiftCardsInvoice(e.CommandArgument.ToString());
                //GetGiftCardsInvoice(null, null, DateTime.MinValue, DateTime.MinValue);
            }
        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            gvGCI.EditIndex = -1;
            if (sdate != DateTime.MinValue) { GetGiftCardsInvoice(searcho, searche, sdate, edate); }
            else if (searcho != "")
            {
                GetGiftCardsInvoice(searcho, searche, sdate, edate);
            }
            else if (searche != "")
            {

                GetGiftCardsInvoice(searcho, searche, sdate, edate);
            }

        }
        protected void gvGCI_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((e.Row.RowState) & DataControlRowState.Edit) != 0)
                {
                    DropDownList ddl = (DropDownList)e.Row.FindControl("ddlReasonofReturen");
                    selectedtext = gvGCI.DataKeys[e.Row.RowIndex].Values["ReasonofReturen"].ToString();
                    //ddl.DataSource = selectedtext;
                    //ddl.DataTextField = "selectedtext";
                    //ddl.DataValueField = "0";
                    FillDDL(ddl, selectedtext);
                }

            }
        }
        protected void FillDDL(DropDownList ddl, string selectedText)
        {
            ddl.Items.Add(new ListItem("None", "-1"));
            ddl.Items.Add(new ListItem("Not Available", "0"));
            ddl.Items.Add(new ListItem("By Customer", "1"));
            ddl.DataBind();
            if (selectedText == "Not Available")
            {
                ddl.SelectedValue = "0";
            }
            else if (selectedText == "By Customer")
            {
                ddl.SelectedValue = "1";
            }
            else
            {
                ddl.SelectedValue = "-1";
            }
            //ddl.DataBind();
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            //DateTime sdate = Convert.ToDateTime(tbSDate.Text);
            //DateTime edate = Convert.ToDateTime(tbEDate.Text);
            ClientsInvoicesDAL clientInvoice = new ClientsInvoicesDAL();
            GiftCardsInvoiceDAL GCIDAL = new GiftCardsInvoiceDAL();

            GCIDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Gift_Cards_Invoice> GCList = GCIDAL.GetGiftCardsInvoice(null, null, sdate, edate);
            List<Gift_Cards_Invoice> TotalInvoicesList = GCIDAL.GetGCTotal(sdate, edate);
            foreach (var val in TotalInvoicesList)
            {
                TotalLocalCost = Convert.ToDouble(val.TotalLocalCost);
                TotalUSDCost = Convert.ToDouble(val.TotalUSDCost);
            }
            var mem = new MemoryStream();
            var writer = new StreamWriter(mem, Encoding.UTF8, 1024, true);
            var csvWriter = new CsvWriter(writer);


            csvWriter.Configuration.Delimiter = ",";


            csvWriter.WriteField("OrderId");
            csvWriter.WriteField("EmployeeID");
            csvWriter.WriteField("LineNumber");
            csvWriter.WriteField("RewardName");
            csvWriter.WriteField("OrderDate");
            csvWriter.WriteField("Quantity");
            csvWriter.WriteField("LocalCost");
            csvWriter.WriteField("USDCost");
            csvWriter.WriteField("TotalUSDCost");
            csvWriter.WriteField("TotalLocalCost");
            csvWriter.NextRecord();

            int lenght = GCList.Count - 1;
            for (int i = 0; i <= lenght; i++)
            {

                csvWriter.WriteField(GCList[i].OrderId);
                csvWriter.WriteField(GCList[i].EmployeeID);
                csvWriter.WriteField(GCList[i].LineNumber);
                csvWriter.WriteField(GCList[i].RewardName);
                csvWriter.WriteField(GCList[i].OrderDate);
                csvWriter.WriteField(GCList[i].Quantity);
                csvWriter.WriteField(GCList[i].LocalCost);
                csvWriter.WriteField(GCList[i].USDCost);
                csvWriter.WriteField(TotalUSDCost);
                csvWriter.WriteField(TotalLocalCost);
                csvWriter.NextRecord();

            }
            writer.Flush();
            var data = Encoding.UTF8.GetString(mem.ToArray());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=GiftCardsInvoice.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Write(data.ToString());
            Response.End();
        }
        protected void gvGCI_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvGCI.EditIndex = -1;
            if (sdate != DateTime.MinValue) { GetGiftCardsInvoice(searcho, searche, sdate, edate); }
            else if (searcho != "")
            {
                GetGiftCardsInvoice(searcho, searche, sdate, edate);
            }
            else if (searche != "")
            {

                GetGiftCardsInvoice(searcho, searche, sdate, edate);
            }
        }
        protected void gvGCI_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvGCI.EditIndex = e.NewEditIndex;
            if (sdate != DateTime.MinValue) { GetGiftCardsInvoice(searcho, searche, sdate, edate); }
            else if (searcho != "")
            {
                GetGiftCardsInvoice(searcho, searche, sdate, edate);
            }
            else if (searche != "")
            {

                GetGiftCardsInvoice(searcho, searche, sdate, edate);
            }
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

            GiftCardsInvoiceDAL GCIDAL = new GiftCardsInvoiceDAL();
            GCIDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            if (tbSearchOrderNo.Text != "")
            {
                searcho = tbSearchOrderNo.Text;
                GetGiftCardsInvoice(searcho, searche, sdate, edate);
            }
            else if (tbSearchEmpID.Text != "")
            {
                searche = tbSearchEmpID.Text;
                GetGiftCardsInvoice(searcho, searche, sdate, edate);

            }
            else
            {
                //sdate = Convert.ToDateTime(tbSDate.Text);
                //edate = Convert.ToDateTime(tbEDate.Text);
                GetGiftCardsInvoice(searcho, searche, sdate, edate);
            }
        }
        protected void gvGCI_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GiftCardsInvoiceDAL GCIDAL = new GiftCardsInvoiceDAL();
            GCIDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            Gift_Cards_Invoice com = new Gift_Cards_Invoice();
            com.OrderId = (gvGCI.Rows[e.RowIndex].FindControl("lblOrderId") as Label).Text;
            com.EmployeeID = (gvGCI.Rows[e.RowIndex].FindControl("lblEmployeeID") as Label).Text;
            com.LineNumber = (gvGCI.Rows[e.RowIndex].FindControl("tbLineNumber") as Label).Text;
            com.RewardName = (gvGCI.Rows[e.RowIndex].FindControl("lblRewardName") as Label).Text;
            com.OrderDate = Convert.ToDateTime((gvGCI.Rows[e.RowIndex].FindControl("lblOrderDate") as Label).Text);
            com.LocalCost = (gvGCI.Rows[e.RowIndex].FindControl("lblLocalCost") as Label).Text;
            com.Quantity = Convert.ToInt32((gvGCI.Rows[e.RowIndex].FindControl("lblQuantity") as Label).Text);
            //com.ReasonofReturen = gvGCI.DataKeys[e.RowIndex].Values[1].ToString();
            com.ReasonofReturen = (gvGCI.Rows[e.RowIndex].FindControl("ddlReasonofReturen") as DropDownList).SelectedValue;
            com.Country = gvGCI.DataKeys[e.RowIndex].Values["Country"].ToString();
            com.SKU = gvGCI.DataKeys[e.RowIndex].Values["SKU"].ToString();
            GCIDAL.InsertGiftCardsInvoice(com);
            gvGCI.EditIndex = -1;
            GetGiftCardsInvoice(searcho, searche, sdate, edate);

        }
        protected void imgPopup1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar2.Visible = false;
                Calendar1.Visible = true;
            }

        }
        protected void imgPopup_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar1.Visible = false;
                Calendar2.Visible = true;
            }

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            tbSDate.Text = Calendar1.SelectedDate.ToShortDateString();

            Calendar1.Visible = false;

            sdate = Convert.ToDateTime(tbSDate.Text);

        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            tbEDate.Text = Calendar2.SelectedDate.ToShortDateString();

            Calendar2.Visible = false;

            edate = Convert.ToDateTime(tbEDate.Text);
        }
        protected void gvGCI_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGCI.PageIndex = e.NewPageIndex;
            GetGiftCardsInvoice(searcho, searche, sdate, edate);
            //lblPage.Text = "Displaying Page" + (gvGCI.PageIndex + 1).ToString() + "of" + gvGCI.PageCount.ToString();
        }
    }
}