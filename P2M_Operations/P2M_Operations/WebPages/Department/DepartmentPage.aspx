<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentPage.aspx.cs" Inherits="P2M_Operations.WebPages.Departments.DepartmentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department</title>
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
        </br>
 <asp:GridView ID="gvDept" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="gvDept_RowCommand" OnRowEditing="gvDept_RowEditing" OnRowUpdating="gvDept_RowUpdating" OnRowCancelingEdit="gvDept_RowCancelingEdit" OnRowDataBound="gvDept_RowDataBound">
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
                             <asp:TextBox ID="tbNameAr" runat="server" Text='<%# Bind("NameAr") %>' MaxLength="50" Width="200px"></asp:TextBox></td>
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
                             <asp:TextBox ID="tbCompName" runat="server" Text='<%# Bind("CompanyName") %>' MaxLength="50" Width="200px"></asp:TextBox></td>
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
                <table>
                    <tr>
                        <td style="width: 10px; color: Red; height: 26px;">*</td>
                        <td>
                            <asp:Label ID="lblAddCountry" runat="server" Text="ID"></asp:Label></td>
                        <td style="width: 10px">:</td>
                        <td>
                            <asp:TextBox ID="tbAddID" runat="server" MaxLength="50" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>

                        <td style="width: 10px; color: red;">* </td>
                        <td>
                            <asp:Label ID="lblAddCompany" runat="server" Text="Department Name"></asp:Label></td>
                        <td style="width: 10px">:</td>
                        <td>
                            <asp:TextBox ID="tbAddDepartmentName" runat="server" MaxLength="50" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="width: 10px; color: Red; height: 26px;">*</td>
                        <td>
                            <asp:Label ID="lblAddArname" runat="server" Text="Arabic Name"></asp:Label>
                        </td>
                        <td style="width: 10px">:</td>
                        <td>
                            <asp:TextBox ID="tbAddArname" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 10px; color: Red; height: 26px;">*</td>
                        <td>
                            <asp:Label ID="lblAddComName" runat="server" Text="Company Name"></asp:Label></td>
                        <td style="width: 10px">:</td>
                        <td>
                            <asp:TextBox ID="tbAddCompName" runat="server" MaxLength="50" Width="200px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="margin-left: auto; margin-top: auto; margin-bottom: auto; margin-right: auto; text-align: center; display: block;" colspan="4">
                            <table>
                                <tr>
                                    <td style="width: 100px">
                                        <asp:Button ID="btnAddNewCompany" runat="server" Text="ADD" OnClick="btnAddNewDept_Click" OnClientClick="Confirm()" Width="75px" /></td>
                                    <td style="width: 100px">
                                        <asp:Button ID="btnCancelAdd" runat="server" Text="Cancel" OnClick="bntBack_Click" Width="75px" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>


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
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
