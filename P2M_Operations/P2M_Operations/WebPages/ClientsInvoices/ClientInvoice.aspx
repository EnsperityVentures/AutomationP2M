<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClientInvoice.aspx.cs" Inherits="P2M_Operations.WebPages.ClientsInvoices.ClientsInvoices" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ClientsInvoices</title>

</head>
<body>

    <form id="ClientsInvoicesform" runat="server">


        
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
                        <td>
                            <asp:Label ID="lblCompany" runat="server" Text="Company"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="CompanyDDL" runat="server" Width="203px">
                            </asp:DropDownList></td>

                    </tr>


                    <td style="width: 100px">
                        <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="Search" />
                    </td>


                    </tr>
                </table>
                <br />
            </asp:Panel>
        </div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblstartdate" runat="server" Text="Start Date" Visible="false" /></td>
                <td>
                    <asp:TextBox ID="tbSDate" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:ImageButton ID="imgPopup1" ImageUrl="~/images/calendarSm_htl_New.png"
                        runat="server" OnClick="imgPopup1_Click" /></td>
                <td>
                    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
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
                    <asp:Label ID="lblenddate" runat="server" Text="End Date" Visible="false" /></td>
                <td>

                    <asp:TextBox ID="tbEDate" runat="server" ReadOnly="true"></asp:TextBox></td>
                <td>
                    <asp:ImageButton ID="imgPopup" ImageUrl="~/images/calendarSm_htl_New.png"
                        runat="server" OnClick="imgPopup_Click" /></td>
                <td>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
        <asp:GridView ID="gvClinetInv" runat="server" AutoGenerateColumns="False" DataKeyNames="ReasonofReturen,OrderNo,Country,TotalLocalCost,TotalUSDCost" OnRowUpdating="gvClinetInv_RowUpdating"
            OnRowCommand="gvClinetInv_RowCommand" OnRowEditing="gvClinetInv_RowEditing" OnRowCancelingEdit="gvClinetInv_RowCancelingEdit"
            OnRowDataBound="gvClinetInv_RowDataBound"
            Width="852px">
            <RowStyle BackColor="#ffffff" />
            <FooterStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#ee843d" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#ee843d" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
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
                <asp:TemplateField HeaderText="First Name">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Catalog Name">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblCatalogName" runat="server" Text='<%# Bind("CatalogName") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCatalogName" runat="server" Text='<%# Bind("CatalogName") %>'></asp:Label>
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
                <%--                <asp:TemplateField HeaderText="Order Date">
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
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Redemption Points">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblRedemptionPoints" runat="server" Text='<%# Bind("RedemptionPoints") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblRedemptionPoints" runat="server" Text='<%# Bind("RedemptionPoints") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--                <asp:TemplateField HeaderText="Local Cost">
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
                </asp:TemplateField>--%>
                <%--                <asp:TemplateField HeaderText="USD Cost">
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
                </asp:TemplateField>--%>
                <%--                <asp:TemplateField HeaderText="Total USD Cost">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblTotalUSDCost" runat="server" Text='<%# Bind("TotalUSDCost") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTotalUSDCost" runat="server" Text='<%# Bind("TotalUSDCost") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Local Cost">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblTotalLocalCost" runat="server" Text='<%# Bind("TotalLocalCost") %>' MaxLength="50" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTotalLocalCost" runat="server" Text='<%# Bind("TotalLocalCost") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="Reason of Returen">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlReasonofReturen" runat="server">
                                        <%--                                        <asp:ListItem Value="1">None</asp:ListItem>
                                        <asp:ListItem Value="2">Not Available</asp:ListItem>
                                        <asp:ListItem Value="3">By Customer</asp:ListItem>--%>
                                    </asp:DropDownList></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblReason" runat="server" Text='<%# Eval("ReasonofReturen") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="true" />
                <asp:TemplateField>
                    <%--                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteOrder" CommandArgument='<%#Eval("OrderNo")%>' />
                    </ItemTemplate>--%>
                </asp:TemplateField>
            </Columns>
            <%--            <PagerSettings Mode="NumericFirstLast" PageButtonCount="10" FirstPageText="First" LastPageText="Last" />--%>
        </asp:GridView>


    </form>
</body>
</html>
