/* ------------------------------------------------------------------------*/
/* File Name : CalendarShow.aspx.cs                                        */
/* Created By : Khalid Mohammad                                            */
/* Creation Date :06/02/2011 03:15 PM                                      */
/* Comment  : For Popup Calendar                                           */
/* ------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DealingWithGridViewAndDBPages
{
    public partial class CalendarShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void clrBirthDate_SelectionChanged(object sender, EventArgs e)
        {
   
            ClientScript.RegisterStartupScript(this.GetType(), "close", "GetDatePopupCalendar('" + clrBirthDate.SelectedDate.Date.ToShortDateString() + "')", true);
        }
    }
}
