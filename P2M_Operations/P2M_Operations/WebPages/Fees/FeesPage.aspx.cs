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

namespace P2M_Operations.WebPages.WFees
{
    public partial class FeesPage : System.Web.UI.Page
    {
        string uppath = @"~/Upload/Fees/Fees.csv";
        static string archivepath = @"~/Archive/Fees/";
        static string date = System.DateTime.Now.ToString("ddMMyyhhmmss");
        string output = archivepath + date + "Fees.csv";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(uppath)))
                ReadWriteCSVFile();
            if (!IsPostBack)
            {
                GetFees();
            }
        }
        private void GetFees()
        {
            FeesDAL feesDAL = new FeesDAL();
            feesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Fees> FeesList = feesDAL.GetFees(null);
            gvFees.DataSource = FeesList;
            gvFees.DataBind();
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
                IEnumerable<Fees> record = csvread.GetRecords<Fees>();

                csvread.Configuration.PrepareHeaderForMatch = header => header.Replace(" ", "").Replace("/", string.Empty).Replace("#", string.Empty).Replace(".", string.Empty);
                foreach (var rec in record) // Each record will be fetched and printed on the screen
                {

                    csw.WriteRecord<Fees>(rec);
                    csw.NextRecord();
                    FeesDAL feesDAL = new FeesDAL();
                    feesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                    feesDAL.InsertFees(rec);

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
                    ImportFile.SaveAs(Server.MapPath("~/Upload/Fees/" + ImportFile.FileName));
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
            GetFees();
        }
        protected void gvFees_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteFees")
            {
                FeesDAL feesDAL = new FeesDAL();
                feesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                feesDAL.DeleteFees(e.CommandArgument.ToString());
                GetFees();
            }

        }
        protected void gvFees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvFees.EditIndex = e.NewEditIndex;
            GetFees();
        }
        protected void gvFees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            FeesDAL feesDAL = new FeesDAL();
            Fees com = new Fees();
            feesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            com.ID=Convert.ToInt32((gvFees.DataKeys[e.RowIndex].Values["ID"]));
            com.RewardName = (gvFees.Rows[e.RowIndex].FindControl("tbRewardName") as TextBox).Text;
            com.ShippingCost = Convert.ToDouble((gvFees.Rows[e.RowIndex].FindControl("tbShippingCost") as TextBox).Text);
            com.HandlingCost = Convert.ToDouble((gvFees.Rows[e.RowIndex].FindControl("tbHandlingCost") as TextBox).Text);
            com.ServiceCharge = Convert.ToDouble((gvFees.Rows[e.RowIndex].FindControl("tbServiceCharge") as TextBox).Text);
            com.Total = Convert.ToDouble((gvFees.Rows[e.RowIndex].FindControl("tbTotal") as TextBox).Text);
            com.SKU= (gvFees.Rows[e.RowIndex].FindControl("tbSKU") as TextBox).Text;

            feesDAL.InsertFees(com);
            gvFees.EditIndex = -1;
            GetFees();

        }
        protected void gvCompany_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvFees.EditIndex = -1;
            GetFees();
        }
        protected void btnAddNewFees_Click(object sender, EventArgs e)
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

            FeesDAL feesDAL = new FeesDAL();
            Fees com = new Fees();

            feesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            com.RewardName = tbRewardName.Text;
            com.ShippingCost = Convert.ToDouble(tbShippingCost.Text);
            com.HandlingCost = Convert.ToDouble(tbHandlingCost.Text);
            com.ServiceCharge = Convert.ToDouble(tbServiceCharge.Text);
            com.SKU = tbSKU.Text;


            feesDAL.InsertFees(com);
            gvFees.EditIndex = -1;
            tbRewardName.Text = string.Empty;
            tbShippingCost.Text = string.Empty;
            tbHandlingCost.Text = string.Empty;
            tbServiceCharge.Text = string.Empty;
            tbSKU.Text = string.Empty;
            GetFees();

        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            gvFees.EditIndex = -1;
        }
        protected void gvFees_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete Fees') ");
                Button btnAddNewCompany = e.Row.FindControl("btnAddNewComp_Click") as Button;
                btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to Add Fees') ");
            }
        }
        protected void BtnExport_Click(object sender, EventArgs e)
        {
            FeesDAL feesDAL = new FeesDAL();
            Fees com = new Fees();

            feesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<Fees> FeesList = feesDAL.GetFees(null);

            var mem = new MemoryStream();
            var writer = new StreamWriter(mem, Encoding.UTF8, 1024, true);
            var csvWriter = new CsvWriter(writer);


            csvWriter.Configuration.Delimiter = ",";
            csvWriter.WriteField("ID");
            csvWriter.WriteField("RewardName");
            csvWriter.WriteField("ShippingCost");
            csvWriter.WriteField("HandlingCost");
            csvWriter.WriteField("ServiceCharge");
            csvWriter.WriteField("Total");
            csvWriter.WriteField("SKU");
            csvWriter.NextRecord();

            int lenght = FeesList.Count - 1;
            for (int i = 0; i <= lenght; i++)
            {
                csvWriter.WriteField(FeesList[i].ID);
                csvWriter.WriteField(FeesList[i].RewardName);
                csvWriter.WriteField(FeesList[i].ShippingCost);
                csvWriter.WriteField(FeesList[i].HandlingCost);
                csvWriter.WriteField(FeesList[i].ServiceCharge);
                csvWriter.WriteField(FeesList[i].Total);
                csvWriter.WriteField(FeesList[i].SKU);
                csvWriter.NextRecord();

            }
            writer.Flush();
            var data = Encoding.UTF8.GetString(mem.ToArray());
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment; filename=Fees.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Write(data.ToString());
            Response.End();
        }
        protected void gvFees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvFees.EditIndex = -1;
            GetFees();
        }
        protected void btnAddNewfees_Click(object sender, EventArgs e)
        {
            FeesDAL feesDAL = new FeesDAL();
            feesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            Fees fees = new Fees();
            fees.RewardName = tbRewardName.Text;
            fees.ShippingCost = Convert.ToDouble(tbShippingCost.Text);
            fees.HandlingCost = Convert.ToDouble(tbHandlingCost.Text);
            fees.ServiceCharge = Convert.ToDouble(tbServiceCharge.Text);
            fees.SKU = (tbSKU.Text);
            feesDAL.InsertFees(fees);
            gvFees.EditIndex = -1;
            GetFees();
            tbRewardName.Text = string.Empty;
            tbShippingCost.Text = string.Empty;
            tbHandlingCost.Text = string.Empty;
            tbServiceCharge.Text = string.Empty;
            tbSKU.Text = string.Empty;
        }
        protected void gvFees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFees.PageIndex = e.NewPageIndex;
            GetFees();
            //this.DataBind();
            lblPage.Text = "Displaying Page" + (gvFees.PageIndex + 1).ToString() + "of" + gvFees.PageCount.ToString();
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            {
                FeesDAL feesDAL = new FeesDAL();
                feesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                List<Fees> FeesList = feesDAL.GetFees(null);
                gvFees.DataSource = FeesList;
                gvFees.DataBind();
            }
            if (tbSearch.Text != "")
            {
                string search = tbSearch.Text;
                FeesDAL feesDAL = new FeesDAL();
                feesDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                List<Fees> FeesList = feesDAL.GetFees(search);
                gvFees.DataSource = FeesList;
                gvFees.DataBind();

            }
            else { GetFees(); }
        }
    }

}