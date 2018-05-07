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

namespace P2M_Operations.WebPages.DailyOrder
{
    public partial class DailyOrder : System.Web.UI.Page
    {
        static string filename;
        static string fileExtension;
        static string uppathCI = @"~/Upload/DailyOrders/DailyClientsOrders.csv";
        static string uppathGC = @"~/Upload/DailyOrders/DailyGCOrders.csv";
        static string archivepath = @"~/Archive/ClientsInvoices";
        string fname = uppathCI+"/"+filename+fileExtension;
        static string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
        string output = archivepath + date + "DailyOrders.csv";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReadWriteCSVFile();
                GetOrders(null);
            }
            


        }
        private void ReadWriteCSVFile()
        {
            string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
            if (File.Exists(Server.MapPath(uppathCI)))
            {
                StreamReader sr = new StreamReader(Server.MapPath(uppathCI));
                StreamWriter write = new StreamWriter(Server.MapPath(output));
                CsvReader csvread = new CsvReader(sr);
                CsvWriter csw = new CsvWriter(write);
                csvread.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", "").Replace("/", string.Empty).Replace("#", string.Empty).Replace(".", string.Empty);
                IEnumerable<ClientsDailyOrders> record = csvread.GetRecords<ClientsDailyOrders>();

                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {
                    csw.WriteRecord<ClientsDailyOrders>(rec);
                    csw.NextRecord();
                    DailyOrdersDAL ONSODAL = new DailyOrdersDAL();
                    ONSODAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    ONSODAL.InsertDCL(rec);

                }
                sr.Close();
                write.Close();//close file streams

                if (File.Exists(Server.MapPath(uppathCI)))
                {
                    File.Delete(Server.MapPath(uppathCI));
                }
            }
            else if (File.Exists(Server.MapPath(uppathGC)))
            {
                StreamReader sr = new StreamReader(Server.MapPath(uppathGC));
                StreamWriter write = new StreamWriter(Server.MapPath(output));
                CsvReader csvread = new CsvReader(sr);
                CsvWriter csw = new CsvWriter(write);
                csvread.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", "").Replace("/", string.Empty).Replace("#", string.Empty).Replace(".", string.Empty);
                IEnumerable<GRSDailyOrders> record = csvread.GetRecords<GRSDailyOrders>();

                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {
                    csw.WriteRecord<GRSDailyOrders>(rec);
                    csw.NextRecord();
                    DailyOrdersDAL ONSODAL = new DailyOrdersDAL();
                    ONSODAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    ONSODAL.InsertDGC(rec);
                }
                sr.Close();
                write.Close();//close file streams

                if (File.Exists(Server.MapPath(uppathCI)))
                {
                    File.Delete(Server.MapPath(uppathCI));
                }
            }
        }
        private void GetOrders(string OrderNO)
        {

                DailyOrdersDAL ONSODAL = new DailyOrdersDAL();
                ONSODAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                List<DailyOrders> ClientInvoiceList = ONSODAL.GetOrders(OrderNO);
                gvDailyorders.DataSource = ClientInvoiceList;
                gvDailyorders.DataBind();


        }
        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            if (ImportFile.HasFile)
            {
                // Get the file extension
                filename = ImportFile.FileName.ToString();
                fileExtension = System.IO.Path.GetExtension(ImportFile.FileName);

                if (fileExtension.ToLower() != ".csv" && fileExtension.ToLower() != ".xlsx")
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only files with .csv and .xlsx extension are allowed";
                }
                else
                {
                  
                        // Upload the file
                        //string Fname = System.DateTime.Now.ToString("ddMMyyhhmmss") + FileUpload1.FileName;
                        ImportFile.SaveAs(Server.MapPath("~/Upload/DailyOrders/" + ImportFile.FileName));
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
            GetOrders(null);
        }
        protected void gvDailyorders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteOrders")
            {
                DailyOrdersDAL ONSODAL = new DailyOrdersDAL();
                ONSODAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                //ONSODAL.DeleteOldOrders(e.CommandArgument.ToString());
                GetOrders(null);
            }
        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            gvDailyorders.EditIndex = -1;
        }
        protected void gvDailyorders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete The Order') ");
                //
                string Date = gvDailyorders.DataKeys[e.Row.RowIndex].Values["OrderDate"].ToString();
                //Label lblODate = e.Row.FindControl("lblODate") as Label;
                TimeSpan span = DateTime.Now.Subtract((Convert.ToDateTime(Date)));
                Label lblStatus = e.Row.FindControl("lblStatus") as Label;
                string Status = (lblStatus.Text).ToLower();
                int delayed = span.Days;
                if (Status == "shipped")
                {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else if (delayed >3 && delayed < 7 && Status == "new")
                {
                    e.Row.BackColor = System.Drawing.Color.Orange;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else if (delayed > 7 && Status == "new")
                {
                    e.Row.BackColor = System.Drawing.Color.IndianRed;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else if (delayed > 7 && delayed < 19 && Status == "po_sent")
                {
                    e.Row.BackColor = System.Drawing.Color.Orange;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else if (delayed >= 19 && Status == "po_sent")
                {
                    e.Row.BackColor = System.Drawing.Color.IndianRed;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else if (delayed>19 && delayed <32 && (Status == "po_received" || Status=="will_shipped"))
                {
                    e.Row.BackColor = System.Drawing.Color.Orange;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else if (delayed >= 32 && (Status == "po_received" || Status == "will_shipped"))
                {
                    e.Row.BackColor = System.Drawing.Color.IndianRed;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }
                else if(Status == "cancelled")
                {
                    e.Row.BackColor = System.Drawing.Color.Black;
                    e.Row.ForeColor = System.Drawing.Color.White;
                }



            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            DailyOrdersDAL ONSODAL = new DailyOrdersDAL();
            ONSODAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<DailyOrders> DailyOredsList = ONSODAL.GetOrders(null);

            var mem = new MemoryStream();
            var writer = new StreamWriter(mem, Encoding.UTF8, 1024, true);
            var csvWriter = new CsvWriter(writer);


            csvWriter.Configuration.Delimiter = ",";

            csvWriter.WriteField("ID");
            csvWriter.WriteField("PIN");
            csvWriter.WriteField("EmployeeID");
            csvWriter.WriteField("FirstName");
            csvWriter.WriteField("LastName");
            csvWriter.WriteField("CatalogName");
            csvWriter.WriteField("Quantity");
            csvWriter.WriteField("OrderDate");
            csvWriter.WriteField("P2MOrderNumber");
            csvWriter.WriteField("GRSOrderNum");
            csvWriter.WriteField("ItemNumber");
            csvWriter.WriteField("JobTitle");
            csvWriter.WriteField("OrderStatus");
            csvWriter.WriteField("ProductCost");
            csvWriter.WriteField("RewardName");
            csvWriter.NextRecord();

            int lenght = DailyOredsList.Count - 1;
            for (int i = 0; i <= lenght; i++)
            {
                csvWriter.WriteField(DailyOredsList[i].ID);
                csvWriter.WriteField(DailyOredsList[i].PIN);
                csvWriter.WriteField(DailyOredsList[i].EmployeeID);
                csvWriter.WriteField(DailyOredsList[i].FirstName);
                csvWriter.WriteField(DailyOredsList[i].LastName);
                csvWriter.WriteField(DailyOredsList[i].CatalogName);
                csvWriter.WriteField(DailyOredsList[i].Quantity);
                csvWriter.WriteField(DailyOredsList[i].OrderDate);
                csvWriter.WriteField(DailyOredsList[i].P2MOrderNumber);
                csvWriter.WriteField(DailyOredsList[i].GRSOrderNum);
                csvWriter.WriteField(DailyOredsList[i].PartnerSystemOrderNum);
                csvWriter.WriteField(DailyOredsList[i].ItemNumber);
                csvWriter.WriteField(DailyOredsList[i].JobTitle);
                csvWriter.WriteField(DailyOredsList[i].OrderStatus);
                csvWriter.WriteField(DailyOredsList[i].ProductCost);
                csvWriter.WriteField(DailyOredsList[i].RewardName);
                csvWriter.NextRecord();

            }
            writer.Flush();
            var data = Encoding.UTF8.GetString(mem.ToArray());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=DailyOrders.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Write(data.ToString());
            Response.End();
        }
        protected void gvDailyorders_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDailyorders.EditIndex = -1;
            GetOrders(null);
        }
        protected void gvDailyorders_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDailyorders.EditIndex = e.NewEditIndex;
            GetOrders(null);
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            DailyOrdersDAL ONSODAL = new DailyOrdersDAL();
            ONSODAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            if (tbSearchOrderNo.Text != "")
            {
                string search = tbSearchOrderNo.Text;
                GetOrders(search);
            }
            else { GetOrders(null); }
        }
        protected void gvDailyorders_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DailyOrdersDAL ONSODAL = new DailyOrdersDAL();
            ONSODAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            DailyOrders DO = new DailyOrders();
            string name = (gvDailyorders.Rows[e.RowIndex].FindControl("lblName") as Label).Text;
            
            DO.ID= (gvDailyorders.Rows[e.RowIndex].FindControl("lblID") as Label).Text;
            DO.RewardName= (gvDailyorders.Rows[e.RowIndex].FindControl("lblRName") as Label).Text;
            DO.Quantity= Convert.ToInt32((gvDailyorders.Rows[e.RowIndex].FindControl("lblQuantity") as Label).Text);
            DO.FirstName= name.Split(' ')[0];
            DO.LastName = name.Split(' ')[1]; ;
            DO.OrderStatus= (gvDailyorders.Rows[e.RowIndex].FindControl("lblStatus") as Label).Text;
            DO.OrderDate= Convert.ToDateTime((gvDailyorders.Rows[e.RowIndex].FindControl("lblODate") as Label).Text);
            DO.P2MOrderNumber= (gvDailyorders.Rows[e.RowIndex].FindControl("lblP2M") as Label).Text;
            DO.Note= (gvDailyorders.Rows[e.RowIndex].FindControl("tbNote") as TextBox).Text;
        }

    }

}

