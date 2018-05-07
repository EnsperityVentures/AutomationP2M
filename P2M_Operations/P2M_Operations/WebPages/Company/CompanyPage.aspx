<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyPage.aspx.cs" Inherits="P2M_Operations.CompanyPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Company</title>
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

        <div style="margin-left: auto; margin-top: auto; margin-bottom: auto; margin-right: auto; text-align: center; display: block;">
            <asp:Panel ID="PanelSearch" runat="server" DefaultButton="ButtonSearch">
                <asp:TextBox ID="TxtSearchKey" runat="server" placeholder="Search.." />
                <asp:Button ID="ButtonSearch" Text="Search" runat="server" OnClick="ButtonSearch_Click" />
                <br />
            </asp:Panel>
        </div>
        <asp:GridView ID="gvCompany" runat="server" AutoGenerateColumns="False" DataKeyNames="Name" OnRowCommand="gvCompany_RowCommand" OnRowEditing="gvCompany_RowEditing" OnRowUpdating="gvCompany_RowUpdating" OnRowCancelingEdit="gvCompany_RowCancelingEdit" OnRowDataBound="gvCompany_RowDataBound">
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
                                    <asp:TextBox ID="tbCountry" runat="server" Text='<%# Bind("Country") %>' MaxLength="50" Width="200px"></asp:TextBox></td>
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
                                    <asp:TextBox ID="tbNameAr" runat="server" Text='<%# Bind("NameAr") %>' MaxLength="50" Width="200px"></asp:TextBox></td>
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
                                    <asp:TextBox ID="tbSite" runat="server" Text='<%# Bind("Site") %>' MaxLength="50" Width="200px"></asp:TextBox></td>
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
                <table>
                    <tr>
                        <td style="width: 10px; color: red">*
                        </td>
                        <td>
                            <asp:Label ID="lblAddCompany" runat="server" Text="Company Name"></asp:Label></td>
                        <td style="width: 10px">:</td>
                        <td>
                            <asp:TextBox ID="tbAddCompany" runat="server" MaxLength="50" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; color: Red; height: 26px;">*</td>
                        <td>
                            <asp:Label ID="lblAddCountry" runat="server" Text="Country"></asp:Label></td>
                        <td style="width: 10px">:</td>
                        <td>
                            <asp:TextBox ID="tbAddCountry" runat="server" MaxLength="50" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; color: Red; height: 26px;">*</td>
                        <td>
                            <asp:Label ID="lblAddArname" runat="server" Text="Arabic Name"></asp:Label></td>
                        <td style="width: 10px">:</td>
                        <td>
                            <asp:TextBox ID="tbAddArname" runat="server" MaxLength="50" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; color: Red; height: 26px;">*</td>
                        <td>
                            <asp:Label ID="lblAddSite" runat="server" Text="Site"></asp:Label></td>
                        <td style="width: 10px">:</td>
                        <td>
                            <asp:TextBox ID="tbAddCompanytxt" runat="server" MaxLength="50" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="margin-left: auto; margin-top: auto; margin-bottom: auto; margin-right: auto; text-align: center; display: block;" colspan="4">
                            <table>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:Button ID="btnAddNewCompany" runat="server" Text="ADD" OnClick="btnAddNewComp_Click" OnClientClick="Confirm()" Width="75px" /></td>
                                    <td style="width: 100px">
                                        <asp:Button ID="btnCancelAdd" runat="server" Text="Cancel" OnClick="bntBack_Click" Width="75px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
        <br />
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="lblMessage" runat="server" Text="Please Choose File To Upload" Font-Bold="true"></asp:Label>
        </div>

        <div style="margin-left: auto; margin-top: auto; margin-bottom: auto; margin-right: auto; text-align: center; display: block;">
            <asp:FileUpload ID="ImportFile" runat="server" />
            <asp:Button ID="BtnUpload" runat="server" OnClick="BtnUpload_Click" Text="Import File" Height="21px" />
            <br />
        </div>
        <br />
        <div style="margin-left: auto; margin-top: auto; margin-bottom: auto; margin-right: auto; text-align: center; display: block;">
            <asp:Button ID="BtnExport" runat="server" OnClick="BtnExport_Click" Text="Export File" Height="21px" />
        </div>

    </form>
</body>
</html>
