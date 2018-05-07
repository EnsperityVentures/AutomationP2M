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
using System.Globalization;

namespace P2M_Operations.WebPages.OmanFloats
{
    public partial class OmanFloatsPage : System.Web.UI.Page
    {
        string uppath = @"~/Upload/OmanFloat/OmanFloat.csv";
        static string archivepath = @"~/Archive/OmanFloat/";
        static string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
        string output = archivepath + date + "OmanFloat.csv";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(uppath)))
                ReadWriteCSVFile();
          
            if (!IsPostBack)
            {
                GetOmanFloat();
                //imgPopup1.Attributes.Add("onclick", "return ShowCalendar('" + tbDate.ClientID + "');");

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
                IEnumerable<OmanFloat> record = csvread.GetRecords<OmanFloat>();

                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {
                    csw.WriteRecord<OmanFloat>(rec);
                    csw.NextRecord();
                    OmanFloatDAL OFDAL = new OmanFloatDAL();
                    OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    OFDAL.InsertOmanFloat(rec);

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
                    ImportFile.SaveAs(Server.MapPath("~/Upload/OmanFloat/" + ImportFile.FileName));
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
            GetOmanFloat();
        }
        private void GetOmanFloat()
        {
            OmanFloatDAL OFDAL = new OmanFloatDAL();
            OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<OmanFloat> OFList = OFDAL.GetOmanFloat(null);
            gvOF.DataSource = OFList;
            gvOF.DataBind();
            //lblTotalAmount.Text=OFList
        }
        private void GetOmanFloat(string orderno)
        {
            OmanFloatDAL OFDAL = new OmanFloatDAL();
            OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<OmanFloat> OFList = OFDAL.GetOmanFloat(orderno);
            gvOF.DataSource = OFList;
            gvOF.DataBind();

        }
        protected void gvOF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteOF")
            {
                OmanFloatDAL OFDAL = new OmanFloatDAL();
                OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                OFDAL.DeleteOmanFloat(e.CommandArgument.ToString());
                GetOmanFloat();
            }
        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            gvOF.EditIndex = -1;
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (tbSearchOrderNo.Text != "")
            {
                string OrederNO = tbSearchOrderNo.Text;
                GetOmanFloat(OrederNO);
            }
            else
            {
                GetOmanFloat(null);
            }
        }
        protected void gvOF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete The Order') ");


            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            OmanFloatDAL OFDAL = new OmanFloatDAL();
            OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<OmanFloat> OFList = OFDAL.GetOmanFloat(null);

            var mem = new MemoryStream();
            var writer = new StreamWriter(mem, Encoding.UTF8, 1024, true);
            var csvWriter = new CsvWriter(writer);


            csvWriter.Configuration.Delimiter = ",";


            csvWriter.WriteField("OrderNo");
            csvWriter.WriteField("OrderDate");
            csvWriter.WriteField("MemberName");
            csvWriter.WriteField("PaymentstoOman");
            csvWriter.WriteField("Totalcost");
            csvWriter.WriteField("Deliveryfees");
            csvWriter.WriteField("TotaCostwithDelivery");
            csvWriter.WriteField("TotalRemainingAmount");
            csvWriter.WriteField("Status");
            csvWriter.WriteField("DeliveryDate");
            csvWriter.WriteField("CardTypeandAmount");
            csvWriter.WriteField("Quantity");
            csvWriter.WriteField("Dateofpayment");
            csvWriter.NextRecord();

            int lenght = OFList.Count - 1;
            for (int i = 0; i <= lenght; i++)
            {

                csvWriter.WriteField(OFList[i].OrderNo);
                csvWriter.WriteField(OFList[i].OrderDate);
                csvWriter.WriteField(OFList[i].MemberName);
                csvWriter.WriteField(OFList[i].PaymentstoOman);
                csvWriter.WriteField(OFList[i].Totalcost);
                csvWriter.WriteField(OFList[i].Deliveryfees);
                csvWriter.WriteField(OFList[i].TotalCostwithDelivery);
                csvWriter.WriteField(OFList[i].TotalRemainingAmount);
                csvWriter.WriteField(OFList[i].Status);
                csvWriter.WriteField(OFList[i].DeliveryDate);
                csvWriter.WriteField(OFList[i].CardTypeandAmount);
                csvWriter.WriteField(OFList[i].Quantity);
                csvWriter.WriteField(OFList[i].Dateofpayment);
                csvWriter.NextRecord();

            }
            writer.Flush();
            var data = Encoding.UTF8.GetString(mem.ToArray());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=OmanFloat.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Write(data.ToString());
            Response.End();
        }
        protected void gvOF_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOF.EditIndex = e.NewEditIndex;
            GetOmanFloat();
        }
        protected void gvOF_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            OmanFloatDAL OFDAL = new OmanFloatDAL();
            OmanFloat com = new OmanFloat();
            OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            com.OrderNo = (gvOF.Rows[e.RowIndex].FindControl("lblOrderNo") as Label).Text;
            com.OrderDate = Convert.ToDateTime((gvOF.Rows[e.RowIndex].FindControl("lblOrderDate") as Label).Text);
            com.MemberName = (gvOF.Rows[e.RowIndex].FindControl("lblMemberName") as Label).Text;
            com.Totalcost = Convert.ToDouble((gvOF.Rows[e.RowIndex].FindControl("tbTotalcost") as TextBox).Text);
            com.Deliveryfees = Convert.ToDouble((gvOF.Rows[e.RowIndex].FindControl("tbDeliveryfees") as TextBox).Text);
            com.TotalCostwithDelivery = Convert.ToDouble((gvOF.Rows[e.RowIndex].FindControl("tbTCWD") as TextBox).Text);
            com.Status = (gvOF.Rows[e.RowIndex].FindControl("tbStatus") as TextBox).Text;
            DateTime? DD = (((gvOF.Rows[e.RowIndex].FindControl("tbDD") as TextBox).Text) == "")? (DateTime?)null: Convert.ToDateTime(((gvOF.Rows[e.RowIndex].FindControl("tbDD") as TextBox).Text));
            com.DeliveryDate = DD;
            com.CardTypeandAmount = (gvOF.Rows[e.RowIndex].FindControl("tbCardTypeandAmount") as TextBox).Text;
            com.Quantity = Convert.ToInt32((gvOF.Rows[e.RowIndex].FindControl("tbQuantity") as TextBox).Text);

            OFDAL.InsertOmanFloat(com);
            gvOF.EditIndex = -1;
            GetOmanFloat();

        }
        protected void gvOF_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOF.EditIndex = -1;
            GetOmanFloat();
        }
    }
}