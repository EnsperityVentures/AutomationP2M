<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrencyPage.aspx.cs" Inherits="P2M_Operations.WebPages.WCurrency.CurrencyPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Currency</title>
    <link href="../../css/Main.css" rel="stylesheet" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.1.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.16/jquery-ui.js"></script>
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Add New Currency data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</head>
<body>

    <form id="Currencyform" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" CssClass="tab" StaticMenuItemStyle-CssClass="tabs" StaticHoverStyle-BackColor="#f1f1f1"
            StaticSelectedStyle-BackColor="#f1f1f1" StaticSelectedStyle-Font-Bold="true" StaticMenuItemStyle-Height="20px" StaticMenuItemStyle-VerticalPadding="15px"
            StaticMenuItemStyle-HorizontalPadding="10px" StaticMenuItemStyle-ForeColor="Black">
            <Items>
                <asp:MenuItem ImageUrl="~/images/P2M-Logo_1.png" Selectable="false"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/ClientsInvoices/ClientInvoice.aspx" Text="Clients Invoices" Value="Clients Invoices"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Company/CompanyPage.aspx" Text="Company" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Currency/CurrencyPage.aspx" Text="Currency" Selected="true" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Department/DepartmentPage.aspx" Text="Departments" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Fees/FeesPage.aspx" Text="Fees" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/GiftCardsInvoice/GiftCardsInvoices.aspx" Text="Gift Cards Invoices" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Members/MembersPage.aspx" Text="Members" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/OmanFloat/OmanFloatsPage.aspx" Text="Oman Float" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/DailyOrders/DailyOrders.aspx" Text="Daily Orders" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/OmanAmount/OmanAmountPage.aspx" Text="Oman Amount" Value="New Item"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <div class="container">
            <asp:GridView CssClass="myGridClass" AlternatingRowStyle-CssClass="myAltRowClass" PagerStyle-CssClass="myPagerClass" ID="gvCurrency" runat="server" AutoGenerateColumns="False" DataKeyNames="ID,Name" OnRowCommand="gvCurrency_RowCommand" OnRowEditing="gvCurrency_RowEditing" OnRowUpdating="gvCurrency_RowUpdating" OnRowCancelingEdit="gvCurrency_RowCancelingEdit" OnRowDataBound="gvCurrency_RowDataBound">
                <Columns>
                    <%--                <asp:TemplateField HeaderText="ID">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblIDEdit" runat="server" Text='<%# Bind("ID") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Currency Name">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbCurrName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCurrName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Country">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbCountry" runat="server" Text='<%# Bind("Country") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="	PointValue">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbPointValue_Rate" runat="server" Text='<%# Bind("PointValue_Rate") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPointValue_Rate" runat="server" Text='<%# Bind("PointValue_Rate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="	USD Rate">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbUSDRate" runat="server" Text='<%# Bind("USDRate") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblUSDRate" runat="server" Text='<%# Bind("USDRate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ISO">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbISO" runat="server" Text='<%# Bind("ISO") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblISO" runat="server" Text='<%# Bind("ISO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField ShowEditButton="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteCurrency" CommandArgument='<%#Eval("ID")%>' />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:MultiView ID="mvCurrency" runat="server" ActiveViewIndex="0">
                <asp:View ID="ViewInsertNewcurrency" runat="server">
                    <div class="panel" style="width: 30%;">
                        <h1 class="header"><span style="width: 115px;">Add Currency</span></h1>
                        <table class="search-box" style="width: 100%;">
                        <tr>
                            <td>
                                <asp:Label ID="lblCurrncyName" runat="server" Text="Currency Name"></asp:Label><span class="star"></span></td>
                            <td>
                                <asp:TextBox ID="tbCurrncyName" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Label ID="lblCountry" runat="server" Text="Country"></asp:Label><span class="star"></span></td>

                            <td>
                                <asp:TextBox ID="tbCountry" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Label ID="lblPointValue_Rate" runat="server" Text="Point-Value Rate"></asp:Label><span class="star"></span></td>

                            <td>
                                <asp:TextBox ID="tbPointValue_Rate" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                        </tr>


                        <tr>

                            <td>
                                <asp:Label ID="lblusdrate" runat="server" Text="USD Rate"></asp:Label><span class="star"></span></td>

                            <td>
                                <asp:TextBox ID="tbusdrate" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Label ID="lblISO" runat="server" Text="ISO"></asp:Label><span class="star"></span></td>

                            <td>
                                <asp:TextBox ID="tbISO" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                        </tr>

                        <tr>
                            <td colspan="2" style="padding: 0; margin: 0;">
                                <table class="no-margin no-padding border-collapse float-right">
                                    <tr>
                                        <td style="padding: 0; margin: 0;">
                                            <asp:Button CssClass="btn" ID="btnAddNewFees" runat="server" Text="ADD" OnClick="btnAddNewCurr_Click" OnClientClick="Confirm()" /></td>
                                        <td>&nbsp;</td>
                                        <td style="padding: 0; margin: 0;">
                                            <asp:Button CssClass="btn" ID="btnCancelAdd" runat="server" Text="Cancel" OnClick="bntBack_Click" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </div>
                </asp:View>
            </asp:MultiView>
            <br />
            <div class="panel" style="margin-top: 30px;">
                <h1 class="header"><span style="width: 105px;">Upload File</span></h1>
                <table class="search-box">
                <tr>
                    <th><asp:Label ID="lblMessage" runat="server" Text="Please Choose File To Upload" Font-Bold="true"></asp:Label></th>
                    </tr>
                <tr>
                    <td><asp:FileUpload ID="ImportFile" runat="server" CssClass="input-small" /></td>
                    <td><asp:Button ID="BtnUpload" runat="server" OnClick="BtnUpload_Click" Text="Import File" CssClass="btn" /></td>
                    <td><asp:Button ID="BtnExport" runat="server" OnClick="BtnExport_Click" Text="Export File" CssClass="btn" /></td>
                </tr>
            </table>
            </div>
        </div>
    </form>
</body>
</html>
