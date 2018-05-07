<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalendarShow.aspx.cs" Inherits="DealingWithGridViewAndDBPages.CalendarShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="_self" />
    <title>Calendar</title>
    <script type="text/javascript">
        // To return The selected Date From The Calender
        function GetDatePopupCalendar(selectdate) {
            window.opener.txt.value = selectdate;
            window.close();

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Calendar ID="clrBirthDate" runat="server" BackColor="White" BorderColor="#3366CC"
                BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="clrBirthDate_SelectionChanged">
                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                <WeekendDayStyle BackColor="#CCCCFF" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True"
                    Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            </asp:Calendar>

        </div>
    </form>
</body>
</html>
