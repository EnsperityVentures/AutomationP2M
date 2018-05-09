<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentPage.aspx.cs" Inherits="P2M_Operations.WebPages.Departments.DepartmentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department</title>
    <link href="../../css/Main.css" rel="stylesheet" />
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Add New Department data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</head>
<body>
    <form id="Departmentform" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" CssClass="tab" StaticMenuItemStyle-CssClass="tabs" StaticHoverStyle-BackColor="#f1f1f1"
            StaticSelectedStyle-BackColor="#f1f1f1" StaticSelectedStyle-Font-Bold="true" StaticMenuItemStyle-Height="20px" StaticMenuItemStyle-VerticalPadding="15px"
            StaticMenuItemStyle-HorizontalPadding="10px" StaticMenuItemStyle-ForeColor="Black">
            <Items>
                <asp:MenuItem ImageUrl="~/images/P2M-Logo_1.png" Selectable="false"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/ClientsInvoices/ClientInvoice.aspx" Text="Clients Invoices" Value="Clients Invoices"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Company/CompanyPage.aspx" Text="Company" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Currency/CurrencyPage.aspx" Text="Currency" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Department/DepartmentPage.aspx" Text="Departments" Selected="true" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Fees/FeesPage.aspx" Text="Fees" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/GiftCardsInvoice/GiftCardsInvoices.aspx" Text="Gift Cards Invoices" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Members/MembersPage.aspx" Text="Members" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/OmanFloat/OmanFloatsPage.aspx" Text="Oman Float" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/DailyOrders/DailyOrders.aspx" Text="Daily Orders" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/OmanAmount/OmanAmountPage.aspx" Text="Oman Amount" Value="New Item"></asp:MenuItem>
            </Items>
        </asp:Menu>

        <div class="container">
            <div style="width: 100%;">
                <asp:Panel ID="PanelSearch" runat="server" DefaultButton="ButtonSearch">
                    <table class="search-box float-right">
                        <tr>
                            <td>
                                <asp:TextBox CssClass="input-small" ID="TxtSearchKey" runat="server" placeholder="Search.." />
                            </td>
                            <td>
                                <asp:Button CssClass="btn" ID="ButtonSearch" Text="Search" runat="server" OnClick="ButtonSearch_Click" />
                            </td>
                        </tr>
                    </table>

                </asp:Panel>
            </div>
            <asp:GridView CssClass="myGridClass" AlternatingRowStyle-CssClass="myAltRowClass" PagerStyle-CssClass="myPagerClass" ID="gvDept" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="gvDept_RowCommand" OnRowEditing="gvDept_RowEditing" OnRowUpdating="gvDept_RowUpdating" OnRowCancelingEdit="gvDept_RowCancelingEdit" OnRowDataBound="gvDept_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txIDEdit" runat="server" Text='<%# Bind("ID") %>'></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txNameEdit" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Arabic Name">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbNameAr" runat="server" Text='<%# Bind("NameAr") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblNameAr" runat="server" Text='<%# Bind("NameAr") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Name">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbCompName" runat="server" Text='<%# Bind("CompanyName") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCompName" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteDepartment" CommandArgument='<%#Eval("ID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:MultiView ID="mvdepartment" runat="server" ActiveViewIndex="0">
                <asp:View ID="ViewInsertNewDepartment" runat="server">
                    <div class="panel" style="width: 30%; margin-top: 30px;">
                        <h1 class="header"><span style="width: 135px;">Add Department</span></h1>
                        <table class="search-box" style="width: 100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblAddCountry" runat="server" Text="ID"></asp:Label><span class="star"></span></td>

                                <td>
                                    <asp:TextBox ID="tbAddID" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAddCompany" runat="server" Text="Department Name"></asp:Label><span class="star"></span></td>

                                <td>
                                    <asp:TextBox ID="tbAddDepartmentName" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="lblAddArname" runat="server" Text="Arabic Name"></asp:Label><span class="star"></span>
                                </td>

                                <td>
                                    <asp:TextBox ID="tbAddArname" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>

                                <td>
                                    <asp:Label ID="lblAddComName" runat="server" Text="Company Name"></asp:Label><span class="star"></span></td>

                                <td>
                                    <asp:TextBox ID="tbAddCompName" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 0; margin: 0;">

                                    <table class="no-margin no-padding border-collapse float-right">
                                        <tr>
                                            <td style="padding: 0; margin: 0;">
                                                <asp:Button CssClass="btn" ID="btnAddNewCompany" runat="server" Text="+ Add" OnClick="btnAddNewDept_Click" OnClientClick="Confirm()" /></td>
                                            <td>&nbsp;
                                            </td>
                                            <td style="padding: 0; margin: 0;">
                                                <asp:Button CssClass="btn" ID="btnCancelAdd" runat="server" Text="Cancel" OnClick="bntBack_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="panel" style="margin-top: 30px;">
                        <h1 class="header"><span style="width: 105px;">Upload File</span></h1>
                        <table class="search-box">
                            <tr>
                                <th>
                                    <asp:Label ID="lblMessage" runat="server" Text="Please Choose File To Upload" Font-Bold="true"></asp:Label></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:FileUpload ID="ImportFile" runat="server" CssClass="input-small" /></td>
                                <td>
                                    <asp:Button ID="BtnUpload" runat="server" OnClick="BtnUpload_Click" Text="Import File" CssClass="btn" /></td>
                                <td>
                                    <asp:Button ID="BtnExport" runat="server" OnClick="BtnExport_Click" Text="Export File" CssClass="btn" /></td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</body>
</html>
