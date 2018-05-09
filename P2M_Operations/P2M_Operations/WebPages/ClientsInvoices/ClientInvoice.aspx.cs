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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;

namespace P2M_Operations.WebPages.ClientsInvoices
{
    public partial class ClientsInvoices : System.Web.UI.Page
    {
        //here we define some variable to use them in ervey methods 
        string uppath = @"~/Upload/ClientsInvoices/ClientsInvoices.csv";
        static string archivepath = @"~/Archive/ClientsInvoices";
        static string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
        string output = archivepath + date + "ClientsInvoices.csv";
        static DateTime sdate;
        static DateTime edate;
        double TotalLocalCost;
        double TotalUSDCost;
        static string search;
        static int company;
        protected void Page_Load(object sender, EventArgs e)
        {
            //cheking if there is an file in that path.
            if (File.Exists(Server.MapPath(uppath)))
            {
                ReadWriteCSVFile();
            }
            if (!IsPostBack)
            {
                // Calender is visible so we need to hide it.
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                FillCompanyddl();
            }

            
        }
        // This method needed to pass parameters to get data from Client Invice Table  
        private void GetClinetInvoice(string OrederNo, string empID, int company, DateTime sdate, DateTime edate)
        {
            // Creating object from DAl Class to call methods 
            ClientsInvoicesDAL clientsInvoicesDAL = new ClientsInvoicesDAL();
            //sending  Connection String information.
            clientsInvoicesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            sdate = Convert.ToDateTime(tbSDate.Text);
            // retrieving list of data 
            List<Clients_Invoices> ClientInvoiceList = clientsInvoicesDAL.GetClientsInvoices(OrederNo, empID, sdate, edate, company);
            //Binding GridView with data
            gvClinetInv.DataSource = ClientInvoiceList;
            gvClinetInv.DataBind();
        }
        private void ReadWriteCSVFile()
        {
            string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
            if (File.Exists(Server.MapPath(uppath)))
            {
                //Start Stream Reading and Writing 
                StreamReader sr = new StreamReader(Server.MapPath(uppath));
                StreamWriter write = new StreamWriter(Server.MapPath(output));
                //Create objects to read CSV file.
                CsvReader csvread = new CsvReader(sr);
                CsvWriter csw = new CsvWriter(write);
                IEnumerable<Clients_Invoices> record = csvread.GetRecords<Clients_Invoices>();
                csvread.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", "").Replace("/", string.Empty).Replace("#", string.Empty).Replace(".", string.Empty);
                //csvread.Configuration.HeaderValidated = null;
                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {
                    csw.WriteRecord<Clients_Invoices>(rec);
                    csw.NextRecord();
                    ClientsInvoicesDAL clientInvoice = new ClientsInvoicesDAL();
                    clientInvoice.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    clientInvoice.InsertClientsInvoices(rec);

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
                    ImportFile.SaveAs(Server.MapPath("~/Upload/ClientsInvoices/" + ImportFile.FileName));
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
            GetClinetInvoice(null, null, 0, DateTime.MinValue, DateTime.MinValue);
        }
        protected void gvClinetInv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteOrder")
            {
                //Deleting recored that Needed
                ClientsInvoicesDAL clientInvoice = new ClientsInvoicesDAL();
                clientInvoice.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                clientInvoice.DeleteClientsInvoices(e.CommandArgument.ToString());
                //GetClinetInvoice(null, null, 0, DateTime.MinValue, DateTime.MinValue);
            }
        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            //cancelling the edit
            gvClinetInv.EditIndex = -1;
        }
        protected void gvClinetInv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (((e.Row.RowState) & DataControlRowState.Edit) != 0)
                {
                    DropDownList ddl = (DropDownList)e.Row.FindControl("ddlReasonofReturen");
                    string selectedtext = gvClinetInv.DataKeys[e.Row.RowIndex].Values["ReasonofReturen"].ToString();
                    //ddl.DataSource = selectedtext;
                    //ddl.DataTextField = "selectedtext";
                    //ddl.DataValueField = "0";
                    FillDDL(ddl, selectedtext);
                }

                //else
                //{


                //    LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                //    btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete The Order') ");
                //}


            }
        }
        private void FillDDL(DropDownList ddl, string selectedText)
        {
            //filling DDL
            //ddl.Items.Insert(0, new ListItem("None", "-1"));
            ddl.Items.Add(new System.Web.UI.WebControls.ListItem("None", "-1"));
            ddl.Items.Add(new System.Web.UI.WebControls.ListItem("Not Available", "0"));
            ddl.Items.Add(new System.Web.UI.WebControls.ListItem("By Customer", "1"));

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

        }
        protected void gvClinetInv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //cancelling the edit
            company = Convert.ToInt32(CompanyDDL.SelectedValue);
            gvClinetInv.EditIndex = -1;
            GetClinetInvoice(search, search, company, sdate, edate);
        }
        protected void gvClinetInv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //starting the edit
            int company = Convert.ToInt32(CompanyDDL.SelectedValue);
            gvClinetInv.EditIndex = e.NewEditIndex;
            GetClinetInvoice(search, search, company, sdate, edate);
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            //choosing search criteria 
            sdate = Convert.ToDateTime(tbSDate.Text);
            edate = Convert.ToDateTime(tbEDate.Text);
            ClientsInvoicesDAL clientsInvoicesDAL = new ClientsInvoicesDAL();
            clientsInvoicesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            if (tbSearchEmpID.Text != "")
            {
                search = tbSearchEmpID.Text;
                GetClinetInvoice(null, search, 0, sdate, edate);
            }
            else if (tbSearchOrderNo.Text != "")
            {
                search = tbSearchOrderNo.Text;
                GetClinetInvoice(search, null, 0, sdate, edate);
            }
            else if (CompanyDDL.SelectedValue != "0")
            {
                company = Convert.ToInt32(CompanyDDL.SelectedValue);
                GetClinetInvoice(null, null, company, sdate, edate);
            }
            else if (CompanyDDL.SelectedValue == "")
            {
                GetClinetInvoice(null, null, 0, sdate, edate);
            }
            else
            {
                GetClinetInvoice(search, search, company, sdate, edate);
            }
        }
        protected void gvClinetInv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Create object from dal and fetching data after updating in gridview and send it to update. 
            ClientsInvoicesDAL clientsInvoicesDAL = new ClientsInvoicesDAL();
            clientsInvoicesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            Clients_Invoices com = new Clients_Invoices();
            com.OrderNo = (gvClinetInv.Rows[e.RowIndex].FindControl("lblOrderNo") as Label).Text;
            com.EmployeeID = (gvClinetInv.Rows[e.RowIndex].FindControl("lblEmployeeID") as Label).Text;
            com.FirstName = (gvClinetInv.Rows[e.RowIndex].FindControl("lblFirstName") as Label).Text;
            com.LastName = (gvClinetInv.Rows[e.RowIndex].FindControl("lblLastName") as Label).Text;
            com.CatalogName = (gvClinetInv.Rows[e.RowIndex].FindControl("lblCatalogName") as Label).Text;
            com.Quantity = Convert.ToInt32((gvClinetInv.Rows[e.RowIndex].FindControl("lblQuantity") as Label).Text);
            com.OrderDate = Convert.ToDateTime((gvClinetInv.Rows[e.RowIndex].FindControl("lblOrderDate") as Label).Text);
            com.LocalCost = Convert.ToDouble((gvClinetInv.Rows[e.RowIndex].FindControl("lblLocalCost") as Label).Text);
            com.USDCost = Convert.ToDouble((gvClinetInv.Rows[e.RowIndex].FindControl("lblUSDCost") as Label).Text);
            com.TotalLocalCost = Convert.ToDouble(gvClinetInv.DataKeys[e.RowIndex].Values["TotalLocalCost"].ToString());
            com.RedemptionPoints = (gvClinetInv.Rows[e.RowIndex].FindControl("lblRedemptionPoints") as Label).Text;
            // com.ReasonofReturen = gvClinetInv.DataKeys[e.RowIndex].Values["ReasonofReturen"].ToString();
            com.ReasonofReturen = (gvClinetInv.Rows[e.RowIndex].FindControl("ddlReasonofReturen") as DropDownList).SelectedValue;
            //int company = Convert.ToInt32(CompanyDDL.SelectedValue);
            com.Country = gvClinetInv.DataKeys[e.RowIndex].Values[2].ToString();
            clientsInvoicesDAL.InsertClientsInvoices(com);
            gvClinetInv.EditIndex = -1;
            GetClinetInvoice(search, search, company, sdate, edate);


        }
        protected void imgPopup1_Click(object sender, ImageClickEventArgs e)
        {

            //showing calender after click it 
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;

            }
            else
            {
                Calendar2.Visible = false;
                Calendar1.Visible = true;
            }
            // sdate = Convert.ToDateTime(tbSDate.Text);
        }
        protected void imgPopup_Click(object sender, ImageClickEventArgs e)
        {
            //showing calender after click it 
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
            //choosing date after pressing it
           // tbSDate.Text = Calendar1.SelectedDate.Value.ToString();
            string date = Request.Form[tbSDate.UniqueID];
            Calendar1.Visible = false;

            sdate = Convert.ToDateTime(tbSDate.Text);

        }
        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            //choosing date after pressing it
            tbEDate.Text = Calendar2.SelectedDate.ToShortDateString();

            Calendar2.Visible = false;

            edate = Convert.ToDateTime(tbEDate.Text);
        }
        protected void FillCompanyddl()
        {
            //Connecting to Database to get list of companies name to use it in search criteria
            CompanyDDL.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select Company--", "0"));
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

                    con.Close();
                }
            }
        }
        protected void gvClinetInv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        { 
            // to navigate between pages.
            gvClinetInv.PageIndex = e.NewPageIndex;
            GetClinetInvoice(search, search, company, sdate, edate);
            //lblPage.Text = "Displaying Page" + (gvClinetInv.PageIndex + 1).ToString() + "of" + gvClinetInv.PageCount.ToString();
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            //exporting a csv file 
        int company = Convert.ToInt32(CompanyDDL.SelectedValue);
        DateTime sdate = Convert.ToDateTime(tbSDate.Text);
        DateTime edate = Convert.ToDateTime(tbEDate.Text);
        ClientsInvoicesDAL clientInvoice = new ClientsInvoicesDAL();
        clientInvoice.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
        List<Clients_Invoices> clientInvoiceList = clientInvoice.GetClientsInvoices(null, null, sdate, edate, company);
        List<Clients_Invoices> TotalInvoicesList = clientInvoice.GetInvoiceTotal(null, null, sdate, edate, company);
            //string aa = TotalInvoicesList.TotalLocalCost;
            foreach (var val in TotalInvoicesList)
            {
                TotalLocalCost = Convert.ToDouble(val.TotalLocalCost);
                TotalUSDCost = Convert.ToDouble(val.TotalUSDCost);
            }

    var mem = new MemoryStream();
    var writer = new StreamWriter(mem, Encoding.UTF8, 1024, true);
    var csvWriter = new CsvWriter(writer);


    csvWriter.Configuration.Delimiter = ",";


            csvWriter.WriteField("OrderNo");
            csvWriter.WriteField("EmployeeID");
            csvWriter.WriteField("FirstName");
            csvWriter.WriteField("LastName");
            csvWriter.WriteField("CatalogName");
            csvWriter.WriteField("Quantity");
            csvWriter.WriteField("OrderDate");
            csvWriter.WriteField("RedemptionPoints");
            csvWriter.WriteField("LocalCost");
            csvWriter.WriteField("USDCost");
            csvWriter.WriteField("TotalUSDCost");
            csvWriter.WriteField("TotalLocalCost");
            csvWriter.NextRecord();

            int lenght = clientInvoiceList.Count - 1;
            for (int i = 0; i <= lenght; i++)
            {

                csvWriter.WriteField(clientInvoiceList[i].OrderNo);
                csvWriter.WriteField(clientInvoiceList[i].EmployeeID);
                csvWriter.WriteField(clientInvoiceList[i].FirstName);
                csvWriter.WriteField(clientInvoiceList[i].LastName);
                csvWriter.WriteField(clientInvoiceList[i].CatalogName);
                csvWriter.WriteField(clientInvoiceList[i].Quantity);
                csvWriter.WriteField(clientInvoiceList[i].OrderDate);
                csvWriter.WriteField(clientInvoiceList[i].RedemptionPoints);
                csvWriter.WriteField(clientInvoiceList[i].LocalCost);
                csvWriter.WriteField(clientInvoiceList[i].USDCost);
                csvWriter.WriteField(TotalLocalCost);
                csvWriter.WriteField(TotalUSDCost);
                csvWriter.NextRecord();

            }

writer.Flush();
            var data = Encoding.UTF8.GetString(mem.ToArray());
Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=ClientInvoice.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Write(data.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        protected void gv_PreRender(object sender, EventArgs e)
        {
            if (gvClinetInv.Rows.Count > 0)
            {
                gvClinetInv.UseAccessibleHeader = true;
                gvClinetInv.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}





