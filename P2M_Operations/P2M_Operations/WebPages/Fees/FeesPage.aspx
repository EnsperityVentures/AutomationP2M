<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FeesPage.aspx.cs" Inherits="P2M_Operations.WebPages.WFees.FeesPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fees</title>
    <link href="../../css/Main.css" rel="stylesheet" />
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to Add New Fees data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</head>
<body>
    <form id="Feesform" runat="server">
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" CssClass="tab" StaticMenuItemStyle-CssClass="tabs" StaticHoverStyle-BackColor="#f1f1f1"
            StaticSelectedStyle-BackColor="#f1f1f1" StaticSelectedStyle-Font-Bold="true" StaticMenuItemStyle-Height="20px" StaticMenuItemStyle-VerticalPadding="15px"
            StaticMenuItemStyle-HorizontalPadding="10px" StaticMenuItemStyle-ForeColor="Black">
            <Items>
                <asp:MenuItem ImageUrl="~/images/P2M-Logo_1.png" Selectable="false"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/ClientsInvoices/ClientInvoice.aspx" Text="Clients Invoices" Value="Clients Invoices"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Company/CompanyPage.aspx" Text="Company" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Currency/CurrencyPage.aspx" Text="Currency" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Department/DepartmentPage.aspx" Text="Departments" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Fees/FeesPage.aspx" Text="Fees" Selected="true" Value="New Item"></asp:MenuItem>
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
                            <asp:Label ID="lblSearch" runat="server" Text="Reward Name"></asp:Label></td>
                        <td style="padding: 0; margin: 0;">
                            <asp:TextBox ID="tbSearch" runat="server" MaxLength="50" CssClass="input-small" placeholder="Reward Name..."></asp:TextBox></td>
                        <td style="padding: 0; margin: 0;">
                            <asp:Button CssClass="btn" ID="ButtonSearch" Text="Search" runat="server" OnClick="ButtonSearch_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
        <asp:GridView CssClass="myGridClass" AlternatingRowStyle-CssClass="myAltRowClass" PagerStyle-CssClass="myPagerClass" ID="gvFees" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            OnRowCommand="gvFees_RowCommand" OnRowEditing="gvFees_RowEditing"
            OnRowUpdating="gvFees_RowUpdating" OnRowCancelingEdit="gvFees_RowCancelingEdit" OnRowDataBound="gvFees_RowDataBound"
            AllowPaging="True" OnPageIndexChanging="gvFees_PageIndexChanging" PageSize="10">

            <Columns>
                <%-- <asp:TemplateField HeaderText="ID">
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
                <asp:TemplateField HeaderText="Reward Name">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbRewardName" runat="server" Text='<%# Bind("RewardName") %>'></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblRewardName" runat="server" Text='<%# Bind("RewardName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Shipping Cost">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbShippingCost" runat="server" Text='<%# Bind("ShippingCost") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblShippingCost" runat="server" Text='<%# Bind("ShippingCost") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Handling Cost">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbHandlingCost" runat="server" Text='<%# Bind("HandlingCost") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblHandlingCost" runat="server" Text='<%# Bind("HandlingCost") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Service Charge">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbServiceCharge" runat="server" Text='<%# Bind("ServiceCharge") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblServiceCharge" runat="server" Text='<%# Bind("ServiceCharge") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbTotal" runat="server" Text='<%# Bind("Total") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SKU">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbSKU" runat="server" Text='<%# Bind("SKU") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSKU" runat="server" Text='<%# Bind("SKU") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteFees" CommandArgument='<%#Eval("ID")%>' />

                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First" LastPageText="Last" />
        </asp:GridView>

        <asp:Label ID="lblPage" runat="server"></asp:Label>
        <asp:MultiView ID="mvFees" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewInsertNewFees" runat="server">
                <div class="panel" style="width: 30%; margin-top: 30px;">
                    <h1 class="header"><span style="width: 110px;" >Add Reward</span></h1>
                    <table class="search-box" style="width: 100%;">
                    <tr>
                        
                        <td>
                            <asp:Label ID="lblRewardName" runat="server" Text="Reward Name"></asp:Label></td>
                        
                        <td>
                            <asp:TextBox ID="tbRewardName" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                    </tr>
                    <tr>
                        
                        <td>
                            <asp:Label ID="lblShippingCost" runat="server" Text="Shipping Cost"></asp:Label></td>
                        
                        <td>
                            <asp:TextBox ID="tbShippingCost" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                    </tr>
                    <tr>
                        
                        <td>
                            <asp:Label ID="lblHandlingCost" runat="server" Text="Handling Cost"></asp:Label></td>
                        
                        <td>
                            <asp:TextBox ID="tbHandlingCost" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                    </tr>
                    <tr>
                        
                        <td>
                            <asp:Label ID="lblServiceCharge" runat="server" Text="ServiceCharge"></asp:Label></td>
                        
                        <td>
                            <asp:TextBox ID="tbServiceCharge" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                    </tr>

                    <tr>
                        
                        <td>
                            <asp:Label ID="lblSKU" runat="server" Text="SKU"></asp:Label></td>
                        
                        <td>
                            <asp:TextBox ID="tbSKU" runat="server" MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                    </tr>
                        <tr>
                            <td></td>
                        </tr>
                    <tr>
                        <td colspan="2" style="padding: 0; margin: 0;">
                                
                                <table class="no-margin no-padding border-collapse float-right">
                                    <tr>
                                        <td style="padding: 0; margin: 0;">
                                        <asp:Button CssClass="btn" ID="btnAddNewFees" runat="server" Text="+ Add" OnClick="btnAddNewfees_Click" OnClientClick="Confirm()" /></td>
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
        </div>
    </form>
</body>
</html>
