<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OmanFloatsPage.aspx.cs" Inherits="P2M_Operations.WebPages.OmanFloats.OmanFloatsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Oman Float</title>
    <link href="../../css/Main.css" rel="stylesheet" />
    <script type="text/javascript">
        // To show the dialog & But the Selected Date in The TextBox
        var txt;
        function ShowCalendar(tbDate) {
            txt = "";
            txt = document.getElementById(tbDate);
            window.open("CalendarShow.aspx", window, "width=230,height=230");
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
    <form id="OmanFloatform" runat="server">

        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" CssClass="tab" StaticMenuItemStyle-CssClass="tabs" StaticHoverStyle-BackColor="#f1f1f1"
            StaticSelectedStyle-BackColor="#f1f1f1" StaticSelectedStyle-Font-Bold="true" StaticMenuItemStyle-Height="20px" StaticMenuItemStyle-VerticalPadding="15px"
            StaticMenuItemStyle-HorizontalPadding="10px" StaticMenuItemStyle-ForeColor="Black">
            <Items>
                <asp:MenuItem ImageUrl="~/images/P2M-Logo_1.png" Selectable="false"></asp:MenuItem>
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

        <div class="container">
            <div style="width: 100%;">
                <asp:Panel ID="PanelSearch" runat="server" DefaultButton="ButtonSearch">
                    <table class="search-box float-right">
                        <tr>
                            <td>
                                <asp:Label ID="lblSearchOrderNo" runat="server" Text="Order No"></asp:Label></td>
                            <td>
                                <asp:TextBox ID="tbSearchOrderNo" runat="server" MaxLength="50" CssClass="input-small" placeholder="Order No..."></asp:TextBox></td>

                            <td style="padding: 0; margin: 0;">
                                <asp:Button CssClass="btn" ID="ButtonSearch" Text="Search" runat="server" OnClick="ButtonSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>

            <asp:GridView CssClass="myGridClass" AlternatingRowStyle-CssClass="myAltRowClass" PagerStyle-CssClass="myPagerClass" ID="gvOF" runat="server" AutoGenerateColumns="False" DataKeyNames="OrderNo" OnRowCommand="gvOF_RowCommand" OnRowEditing="gvOF_RowEditing" OnRowUpdating="gvOF_RowUpdating" OnRowCancelingEdit="gvOF_RowCancelingEdit" OnRowDataBound="gvOF_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="Order Number">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("OrderNo") %>'></asp:Label></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblOrderNo" runat="server" Text='<%# Bind("OrderNo") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Order Date">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOrderDate" runat="server" Text='<%# Bind("OrderDate") %>'></asp:Label></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblOrderDate" runat="server" Text='<%# Bind("OrderDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Member Name">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMemberName" runat="server" Text='<%# Bind("MemberName") %>' MaxLength="50" CssClass="input-small"></asp:Label></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblMemberName" runat="server" Text='<%# Bind("MemberName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbQuantity" runat="server" Text='<%# Bind("Quantity") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total cost">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbTotalcost" runat="server" Text='<%# Bind("Totalcost") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTotalcost" runat="server" Text='<%# Bind("Totalcost") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delivery Fees">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbDeliveryfees" runat="server" Text='<%# Bind("Deliveryfees") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDeliveryfees" runat="server" Text='<%# Bind("Deliveryfees") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Cost+Delivery">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbTCWD" runat="server" Text='<%# Bind("TotalCostwithDelivery") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTCWD" runat="server" Text='<%# Bind("TotalCostwithDelivery") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--                <asp:TemplateField HeaderText="Total Remaining Amount">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbTRA" runat="server" Text='<%# Bind("TotalRemainingAmount") %>' MaxLength="50" Width="200px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbltbTRA" runat="server" Text='<%# Bind("TotalRemainingAmount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="Status">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbStatus" runat="server" Text='<%# Bind("Status") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Delivery Date">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbDD" runat="server" Text='<%# Bind("DeliveryDate") %>' MaxLength="50" Width="200px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblDD" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Card Type+Amount">
                        <EditItemTemplate>
                            <table style="width: 100%">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="tbCardTypeandAmount" runat="server" Text='<%# Bind("CardTypeandAmount") %>' MaxLength="50" CssClass="input-small"></asp:TextBox></td>
                                </tr>
                            </table>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCardTypeandAmount" runat="server" Text='<%# Bind("CardTypeandAmount") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <%-- <asp:TemplateField HeaderText="Date Of Payment">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblDateofpayment" runat="server" Text='<%# Bind("Dateofpayment") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDateofpayment" runat="server" Text='<%# Bind("Dateofpayment") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>


                    <asp:CommandField ShowEditButton="True" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteOF" CommandArgument='<%#Eval("OrderNo")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

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
