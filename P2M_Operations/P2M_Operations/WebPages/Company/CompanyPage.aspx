<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyPage.aspx.cs" Inherits="P2M_Operations.CompanyPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company</title>
    <link href="../../css/Main.css" rel="stylesheet" />
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Add New Company data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</head>
<body>
    <form id="Companyform" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" CssClass="tab" StaticMenuItemStyle-CssClass="tabs" StaticHoverStyle-BackColor="#f1f1f1"
            StaticSelectedStyle-BackColor="#f1f1f1" StaticSelectedStyle-Font-Bold="true" StaticMenuItemStyle-Height="20px" StaticMenuItemStyle-VerticalPadding="15px"
            StaticMenuItemStyle-HorizontalPadding="10px" StaticMenuItemStyle-ForeColor="Black">
            
            <Items>
                <asp:MenuItem ImageUrl="~/images/P2M-Logo_1.png" Selectable="false"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/ClientsInvoices/ClientInvoice.aspx" Text="Clients Invoices" Value="Clients Invoices"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Company/CompanyPage.aspx" Selected="true" Text="Company" Value="New Item"></asp:MenuItem>
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

        <div class="container">
            <div class="float-right">
                <asp:Panel ID="PanelSearch" runat="server" DefaultButton="ButtonSearch">
                    <table class="search-box">
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
            <asp:GridView CssClass="myGridClass" AlternatingRowStyle-CssClass="myAltRowClass" PagerStyle-CssClass="myPagerClass" ID="gvCompany" runat="server" AutoGenerateColumns="False" DataKeyNames="Name" OnRowCommand="gvCompany_RowCommand" OnRowEditing="gvCompany_RowEditing" OnRowUpdating="gvCompany_RowUpdating" OnRowCancelingEdit="gvCompany_RowCancelingEdit" OnRowDataBound="gvCompany_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
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
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNameEdit" runat="server" Text='<%# Bind("Name") %>'></asp:Label></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Site">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbSite" runat="server" Text='<%# Bind("Site") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSite" runat="server" Text='<%# Bind("Site") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteCompany" CommandArgument='<%#Eval("Name")%>' />
                            <%-- <asp:LinkButton runat="server" ID="Button1" Text="Update" CommandName="UpdateCompany"
                            CommandArgument='<%# Eval("Name") + "," + Eval("Country") + "," + Eval("NameAr") + "," + Eval("Site")%>' />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:MultiView ID="mvcompany" runat="server" ActiveViewIndex="0">
                <asp:View ID="ViewInsertNewCompany" runat="server">
                    <div class="panel" style="width: 30%; margin-top: 30px;">
                        <h1 class="header"><span style="width: 120px;">Add Company</span></h1>
                        <table class="search-box" style="width: 100%;">
                        <tr>
                            
                            <td>
                                <asp:Label ID="lblAddCompany" runat="server" Text="Company Name"></asp:Label></td>
                            
                            <td>
                                <asp:TextBox ID="tbAddCompany" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td>
                                <asp:Label ID="lblAddCountry" runat="server" Text="Country"></asp:Label></td>
                            
                            <td>
                                <asp:TextBox ID="tbAddCountry" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td>
                                <asp:Label ID="lblAddArname" runat="server" Text="Arabic Name"></asp:Label></td>
                            
                            <td>
                                <asp:TextBox ID="tbAddArname" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                        </tr>
                        <tr>
                            
                            <td>
                                <asp:Label ID="lblAddSite" runat="server" Text="Site"></asp:Label></td>
                            
                            <td>
                                <asp:TextBox ID="tbAddCompanytxt" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                        </tr>
                            <tr>
                                <td></td>
                            </tr>
                        <tr>
                            <td colspan="2" style="padding: 0; margin: 0;">
                                <table class="no-margin no-padding border-collapse float-right">
                                    <tr>    
                                        <td class="no-padding no-margin">
                                            <asp:Button ID="btnAddNewCompany" runat="server" Text="+ Add" OnClick="btnAddNewComp_Click" OnClientClick="Confirm()" CssClass="btn" /></td>
                                        <td class="no-padding no-margin">
                                            <asp:Button ID="btnCancelAdd" runat="server" Text="Cancel" OnClick="bntBack_Click" CssClass="btn" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    </div>
                </asp:View>
            </asp:MultiView>
            
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
