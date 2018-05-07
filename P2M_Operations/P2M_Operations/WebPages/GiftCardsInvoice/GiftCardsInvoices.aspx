<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiftCardsInvoices.aspx.cs" Inherits="P2M_Operations.WebPages.GiftCardsInvoice.GiftCardsInvoices" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gift Cards Invoices</title>
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
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblSearchOrderNo" runat="server" Text="OrderNo"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="tbSearchOrderNo" runat="server" MaxLength="50" Width="200px" placeholder="OrderNo..."></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSearchEmpID" runat="server" Text="Employee ID"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="tbSearchEmpID" runat="server" MaxLength="50" Width="200px" placeholder="EmpolyeeNumber..."></asp:TextBox></td>
                    </tr>
                    <tr>

                        <td style="width: 100px">
                            <asp:Button ID="ButtonSearch" Text="Search" runat="server" OnClick="ButtonSearch_Click" />
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
        </div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblstartdate" runat="server" Text="Start Date" Visible="true" /></td>
                <td>
                    <asp:TextBox ID="tbSDate" runat="server"></asp:TextBox></td>
                <td>
                    <asp:ImageButton ID="imgPopup1" ImageUrl="~/images/calendarSm_htl_New.png"
                        runat="server" OnClick="imgPopup1_Click" /></td>
                <td>
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
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblenddate" runat="server" Text="End Date" Visible="true" /></td>
                <td>

                    <asp:TextBox ID="tbEDate" runat="server"></asp:TextBox></td>
                <td>
                    <asp:ImageButton ID="imgPopup" ImageUrl="~/images/calendarSm_htl_New.png"
                        runat="server" OnClick="imgPopup_Click" /></td>
                <td>
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
                </td>

            </tr>
        </table>
        <div style="margin-left: auto; margin-right: auto; text-align: center;">
            <asp:Label ID="lblMessage" runat="server" Text="Please Choose File To Upload" Font-Bold="true"></asp:Label>
        </div>
        <div style="margin-left: auto; margin-top: auto; margin-bottom: auto; margin-right: auto; text-align: center; display: block;">
            <asp:FileUpload ID="ImportFile" runat="server" />
            <asp:Button ID="BtnUpload" runat="server" OnClick="BtnUpload_Click" Text="Import File" Height="21px" />
            <br />
        </div>
        <div style="margin-left: auto; margin-top: auto; margin-bottom: auto; margin-right: auto; text-align: center; display: block;">
            <asp:Button ID="BtnExport" runat="server" OnClick="BtnExport_Click" Text="Export File" Height="21px" />
        </div>
        <asp:GridView ID="gvGCI" runat="server" AutoGenerateColumns="False"
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
    </form>
</body>
</html>
