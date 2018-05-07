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

namespace P2M_Operations.WebPages.OmanAmounts
{
    public partial class OmanAmountPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgPopup1.Attributes.Add("onclick", "return ShowCalendar('" + tbDate.ClientID + "');");
                GetTAmount();
                GetOAmount();
            }

        }

        protected void GetTAmount()
        {
            OmanFloatDAL OFDAL = new OmanFloatDAL();
            OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            Double TAmount = Convert.ToDouble(OFDAL.GetAmount());
            lblTAmount.Text = TAmount.ToString();
        }

        protected void BtnAmount_Click(object sender, EventArgs e)
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

            OmanFloatDAL OFDAL = new OmanFloatDAL();
            OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            double amount = Convert.ToDouble(tbamount.Text);
            string s = tbDate.Text;
            DateTime PaymentDate = Convert.ToDateTime(tbDate.Text);
            OFDAL.OmanAddAmount(amount, PaymentDate);
            GetOAmount();
            GetTAmount();
            tbamount.Text = string.Empty;
            tbDate.Text = string.Empty;
        }
        private void GetOAmount()
        {
            OmanFloatDAL OFDAL = new OmanFloatDAL();
            OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            List<OmanAmount> AFList = OFDAL.GetOmanAmount();
            
            gvOF.DataSource = AFList;
            gvOF.DataBind();
            //lblTotalAmount.Text = "1111";
            //lblTotalAmount.Text = OFDAL.GetAmount;
        }
        protected void gvOF_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteOA")
            {
                OmanFloatDAL OFDAL = new OmanFloatDAL();
                OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
                OFDAL.DeleteOmanAmount(e.CommandArgument.ToString());
                GetOAmount();
                GetTAmount();
            }
        }
        protected void bntBack_Click(object sender, EventArgs e)
        {
            gvOF.EditIndex = -1;
        }
        protected void gvOF_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton btnDelete = e.Row.FindControl("btnDelete") as LinkButton;
                btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete The Order') ");


            }
        }
        protected void gvOF_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvOF.EditIndex = e.NewEditIndex;
            GetOAmount();
            GetTAmount();
        }
        protected void gvOF_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvOF.EditIndex = -1;
            GetOAmount();
            GetTAmount();
        }
        protected void gvOF_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            OmanFloatDAL OFDAL = new OmanFloatDAL();
            OmanAmount com = new OmanAmount();
            OFDAL.ConnectionString = ConfigurationManager.ConnectionStrings["MySQLConn"].ToString();
            com.ID = Convert.ToInt32((gvOF.DataKeys[e.RowIndex].Values["ID"]));
            com.PaymentstoOman = Convert.ToDouble((gvOF.Rows[e.RowIndex].FindControl("tbP2O") as TextBox).Text);
            DateTime? DOP = (((gvOF.Rows[e.RowIndex].FindControl("lblDateofpayment") as Label).Text) == "")? (DateTime?)null : Convert.ToDateTime(((gvOF.Rows[e.RowIndex].FindControl("lblDateofpayment") as Label).Text));
            com.Dateofpayment = DOP;
            OFDAL.InsertOmanAmount(com);
            gvOF.EditIndex = -1;
            GetOAmount();
            GetTAmount();

        }
    }
}