<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiftCardsInvoices.aspx.cs" Inherits="P2M_Operations.WebPages.GiftCardsInvoice.GiftCardsInvoices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gift Cards Invoices</title>
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
    <form id="GiftCardsInvoicesform" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
                <asp:MenuItem NavigateUrl="~/WebPages/GiftCardsInvoice/GiftCardsInvoices.aspx" Selected="true" Text="Gift Cards Invoices" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/Members/MembersPage.aspx" Text="Members" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/OmanFloat/OmanFloatsPage.aspx" Text="Oman Float" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/DailyOrders/DailyOrders.aspx" Text="Daily Orders" Value="New Item"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/WebPages/OmanAmount/OmanAmountPage.aspx" Text="Oman Amount" Value="New Item"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <div class="container">
            <div class="panel">
            <h1 class="header"><span>Search</span></h1>
            <asp:Panel ID="PanelSearch" runat="server" DefaultButton="ButtonSearch">
                <table class="search-box">
                    <tr>
                        <td>
                            <asp:Label ID="lblSearchOrderNo" runat="server" Text="Order No"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="tbSearchOrderNo" runat="server" MaxLength="50" CssClass="input-small" placeholder="Order No..."></asp:TextBox></td>
                        <td>
                            <asp:Label ID="lblSearchEmpID" runat="server" Text="Employee ID"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="tbSearchEmpID" runat="server" MaxLength="50" CssClass="input-small" placeholder="Empolyee ID..."></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblstartdate" runat="server" Text="From" Visible="true" />
                        </td>
                        <td>
                            <div class="field-wrap">
                                <asp:TextBox ID="tbSDate" ReadOnly="true" TextMode="Date" CssClass="embeded-save-field" runat="server"></asp:TextBox>
                                <asp:ImageButton CssClass="embeded-save-btn" ID="imgPopup1" ImageUrl="~/images/calendarSm_htl_New.png"
                                    runat="server" OnClick="imgPopup1_Click" />
                            </div>
                            <div style="position: absolute;">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Calendar ID="Calendar1" runat="server" BorderWidth="1px"
                                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" Height="200px"
                                            ShowGridLines="True" Width="387px" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                            ForeColor="#663399" OnSelectionChanged="Calendar1_SelectionChanged">
                                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                            <SelectorStyle BackColor="#FFCC66" />
                                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt"
                                                ForeColor="#FFFFCC" />
                                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                            <WeekendDayStyle Font-Names="Calibri" />
                                        </asp:Calendar>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                        <td>
                            <asp:Label ID="lblenddate" runat="server" Text="To" Visible="true" /></td>
                        <td>
                            <div class="field-wrap">
                                <asp:TextBox ID="tbEDate" ReadOnly="true" TextMode="Date" CssClass="embeded-save-field" runat="server"></asp:TextBox>
                                <asp:ImageButton CssClass="embeded-save-btn" ID="imgPopup" ImageUrl="~/images/calendarSm_htl_New.png"
                                    runat="server" OnClick="imgPopup_Click" />

                            </div>
                            <div style="position: absolute;">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Calendar ID="Calendar2" runat="server" BorderWidth="1px"
                                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" Height="200px"
                                            ShowGridLines="True" Width="387px" BackColor="#FFFFCC" BorderColor="#FFCC66"
                                            ForeColor="#663399" OnSelectionChanged="Calendar2_SelectionChanged">
                                            <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                                            <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                                            <OtherMonthDayStyle ForeColor="#CC9966" />
                                            <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                                            <SelectorStyle BackColor="#FFCC66" />
                                            <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt"
                                                ForeColor="#FFFFCC" />
                                            <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                                            <WeekendDayStyle Font-Names="Calibri" />
                                        </asp:Calendar>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="padding: 0; margin: 0;">
                            <asp:Button CssClass="btn float-right" ID="ButtonSearch" Text="Search" runat="server" OnClick="ButtonSearch_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
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
        <asp:GridView CssClass="myGridClass" AlternatingRowStyle-CssClass="myAltRowClass" PagerStyle-CssClass="myPagerClass" ID="gvGCI" runat="server" AutoGenerateColumns="False"
            DataKeyNames="OrderId,ReasonofReturen,SKU,Country" OnRowCommand="gvGCI_RowCommand" OnRowEditing="gvGCI_RowEditing"
            OnRowUpdating="gvGCI_RowUpdating" OnRowCancelingEdit="gvGCI_RowCancelingEdit"
            OnRowDataBound="gvGCI_RowDataBound" AllowPaging="True" PageSize="10"
            OnPageIndexChanging="gvGCI_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Order ID">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblOrderId" runat="server" Text='<%# Bind("OrderId") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOrderId" runat="server" Text='<%# Bind("OrderId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee ID">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeID" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Line Number">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="tbLineNumber" runat="server" Text='<%# Bind("LineNumber") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLineNumber" runat="server" Text='<%# Bind("LineNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reward Name">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblRewardName" runat="server" Text='<%# Bind("RewardName") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblRewardName" runat="server" Text='<%# Bind("RewardName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Order Date">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblOrderDate" runat="server" Text='<%# Bind("OrderDate") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblOrderDate" runat="server" Text='<%# Bind("OrderDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Local Cost">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblLocalCost" runat="server" Text='<%# Bind("LocalCost") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLocalCost" runat="server" Text='<%# Bind("LocalCost") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="USD Cost">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblUSDCost" runat="server" Text='<%# Bind("USDCost") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblUSDCost" runat="server" Text='<%# Bind("USDCost") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reason of Returen">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlReasonofReturen" runat="server">
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblReason" runat="server" Text='<%# Eval("ReasonofReturen") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" />
                <%--                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteGC" CommandArgument='<%#Eval("OrderId")%>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblPage" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
