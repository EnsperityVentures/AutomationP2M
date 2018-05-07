<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OmanAmountPage.aspx.cs" Inherits="P2M_Operations.WebPages.OmanAmounts.OmanAmountPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OmanAmount</title>
    <script type="text/javascript">
        // To show the dialog & But the Selected Date in The TextBox
        var txt;
        function ShowCalendar(tbDate) {
            txt = "";
            txt = document.getElementById(tbDate);
            window.open("../Calendar/CalendarShow.aspx", window, "width=230,height=230");
            return false;
        }
    </script>
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Add New Amount data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="~/WebPages/ClientsInvoices/ClientInvoice.aspx" Text="Clients Invoices" Value="Clients Invoices"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Company/CompanyPage.aspx" Text="Company" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Currency/CurrencyPage.aspx" Text="Currency" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Department/DepartmentPage.aspx" Text="Departments" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Fees/FeesPage.aspx" Text="Fees" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/GiftCardsInvoice/GiftCardsInvoices.aspx" Text="Gift Cards Invoices" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Members/MembersPage.aspx" Text="Members" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/OmanFloat/OmanFloatsPage.aspx" Text="Oman Float" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/DailyOrders/DailyOrders.aspx" Text="Daily Orders" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/OmanAmount/OmanAmountPage.aspx" Text="Oman Amount" Value="New Item"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:GridView ID="gvOF" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="gvOF_RowCommand" OnRowEditing="gvOF_RowEditing" OnRowUpdating="gvOF_RowUpdating" OnRowCancelingEdit="gvOF_RowCancelingEdit" OnRowDataBound="gvOF_RowDataBound">
            <Columns>

                <asp:TemplateField HeaderText="Payments To Oman">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbP2O" runat="server" Text='<%# Bind("PaymentstoOman") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblP2O" runat="server" Text='<%# Bind("PaymentstoOman") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

<%--                <asp:TemplateField HeaderText="Total Remaining Amount">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="tbTRA" runat="server" Text='<%# Bind("TotalRemainingAmount") %>' MaxLength="50" Width="100px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbltbTRA" runat="server" Text='<%# Bind("TotalRemainingAmount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Date Of Payment">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblDateofpayment" runat="server" Text='<%# Bind("Dateofpayment") %>' MaxLength="50" Width="100px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDateofpayment" runat="server" Text='<%# Bind("Dateofpayment") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteOA" CommandArgument='<%#Eval("ID")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblTRAmount" runat="server" Text="Total Remaining Amount is :" Width="100%"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTAmount" runat="server" Width="100%"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAmount" runat="server" Text="Payment Amount" Width="100%"></asp:Label></td>
                <td>
                    <asp:TextBox ID="tbamount" runat="server" MaxLength="50" Width="200px" placeholder="0.0"></asp:TextBox></td>
                <td>
                    <asp:Button ID="ButtonAmount" runat="server" OnClick="BtnAmount_Click" OnClientClick="Confirm()" Text="Add Amount" Height="21px" /></td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblstartdate" runat="server" Text="Amount Date" Visible="true" /></td>
                <td>
                    <asp:TextBox ID="tbDate" runat="server" Width="100%"></asp:TextBox>

                </td>

                <td>

                    <asp:ImageButton ID="imgPopup1" ImageUrl="~/images/calendarSm_htl_New.png" runat="server" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
