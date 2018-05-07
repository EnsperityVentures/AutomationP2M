<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MembersPage.aspx.cs" Inherits="P2M_Operations.WebPages.Member.MembersPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Members</title>
</head>
<body>
    <form id="MembersForm" runat="server">
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
                            <asp:Label ID="lblSearchEmpID" runat="server" Text="Employee ID"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="tbSearchEmpID" runat="server" MaxLength="50" Width="200px" placeholder="EmpolyeeNumber..."></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblSearchName" runat="server" Text="Employee Name"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="tbSearchName" runat="server" MaxLength="50" Width="200px" placeholder="Name..."></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Company"></asp:Label></td>
                        <td>
                            <asp:DropDownList ID="CompanyDDL" runat="server" Width="203px">
                            </asp:DropDownList></td>

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
        </br>
        <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeNumber" OnRowCommand="gvMembers_RowCommand" OnRowEditing="gvMembers_RowEditing" OnRowUpdating="gvMembers_RowUpdating" OnRowCancelingEdit="gvMembers_RowCancelingEdit" OnRowDataBound="gvMembers_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="Pin">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblPinEdit" runat="server" Text='<%# Bind("Pin") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPin" runat="server" Text='<%# Bind("Pin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Employee Number">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblEmployeeNumberEdit" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeNumber" runat="server" Text='<%# Bind("EmployeeNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbFirstName" runat="server" Text='<%# Bind("FirstName") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
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
                                    <asp:TextBox ID="tbLastName" runat="server" Text='<%# Bind("LastName") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbEmail" runat="server" Text='<%# Bind("Email") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Job Title">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbJobTitle" runat="server" Text='<%# Bind("JobTitle") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblJobTitle" runat="server" Text='<%# Bind("JobTitle") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Hire Date">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbHireDate" runat="server" Text='<%# Bind("HireDate") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblHireDate" runat="server" Text='<%# Bind("HireDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Birth Date">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbBirthDate" runat="server" Text='<%# Bind("BirthDate") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblBirthDate" runat="server" Text='<%# Bind("BirthDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address1">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbAddress1" runat="server" Text='<%# Bind("Address1") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAddress1" runat="server" Text='<%# Bind("Address1") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address2">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbAddress2" runat="server" Text='<%# Bind("Address2") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAddress2" runat="server" Text='<%# Bind("Address2") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbCity" runat="server" Text='<%# Bind("City") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Province State">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbProvinceState" runat="server" Text='<%# Bind("ProvinceState") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProvinceState" runat="server" Text='<%# Bind("ProvinceState") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbCountry" runat="server" Text='<%# Bind("Country") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCountry" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Postal Code">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbPostalCode" runat="server" Text='<%# Bind("PostalCode") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPostalCode" runat="server" Text='<%# Bind("PostalCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telephone Area Code">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbTelephoneAreaCode" runat="server" Text='<%# Bind("TelephoneAreaCode") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTelephoneAreaCode" runat="server" Text='<%# Bind("TelephoneAreaCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telephone Number">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbTelephoneNumber" runat="server" Text='<%# Bind("TelephoneNumber") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTelephoneNumber" runat="server" Text='<%# Bind("TelephoneNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telephone Country Code">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbTelephoneCountryCode" runat="server" Text='<%# Bind("TelephoneCountryCode") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTelephoneCountryCode" runat="server" Text='<%# Bind("TelephoneCountryCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Language Code">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbLanguageCode" runat="server" Text='<%# Bind("LanguageCode") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLanguageCode" runat="server" Text='<%# Bind("LanguageCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Code">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbDepartmentCode" runat="server" Text='<%# Bind("DepartmentCode") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentCode" runat="server" Text='<%# Bind("DepartmentCode") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Department Name">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbDepartmentName" runat="server" Text='<%# Bind("DepartmentName") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDepartmentName" runat="server" Text='<%# Bind("DepartmentName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Access Groups">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbAccessGroups" runat="server" Text='<%# Bind("AccessGroups") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAccessGroups" runat="server" Text='<%# Bind("AccessGroups") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Employee Type">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbEmployeeType" runat="server" Text='<%# Bind("EmployeeType") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmployeeType" runat="server" Text='<%# Bind("EmployeeType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>




                <asp:TemplateField HeaderText="Deletion Date">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbDeletionDate" runat="server" Text='<%# Bind("DeletionDate") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDeletionDate" runat="server" Text='<%# Bind("DeletionDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbPassword" runat="server" Text='<%# Bind("Password") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPassword" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Disable Login">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbDisableLogin" runat="server" Text='<%# Bind("DisableLogin") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDisableLogin" runat="server" Text='<%# Bind("DisableLogin") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DisableEarn">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbDisableEarn" runat="server" Text='<%# Bind("DisableEarn") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDisableEarn" runat="server" Text='<%# Bind("DisableEarn") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Username">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbUsername" runat="server" Text='<%# Bind("Username") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblUsername" runat="server" Text='<%# Bind("Username") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="FnameAR">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbFnameAR" runat="server" Text='<%# Bind("FnameAR") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFnameAR" runat="server" Text='<%# Bind("FnameAR") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="LnameAR">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbLnameAR" runat="server" Text='<%# Bind("LnameAR") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblLnameAR" runat="server" Text='<%# Bind("LnameAR") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PositionAr">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbPositionAr" runat="server" Text='<%# Bind("PositionAr") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPositionAr" runat="server" Text='<%# Bind("PositionAr") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MNA">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbMNA" runat="server" Text='<%# Bind("MNA") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMNA" runat="server" Text='<%# Bind("MNA") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MNE">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbMNE" runat="server" Text='<%# Bind("MNE") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMNE" runat="server" Text='<%# Bind("MNE") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="META">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbMETA" runat="server" Text='<%# Bind("META") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMETA" runat="server" Text='<%# Bind("META") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Child">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbChild" runat="server" Text='<%# Bind("Child") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblChild" runat="server" Text='<%# Bind("Child") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="marriage">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbMrgDate" runat="server" Text='<%# Bind("MrgDate") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
                            </tr>
                        </table>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMrgDate" runat="server" Text='<%# Bind("MrgDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Name">
                    <EditItemTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                    <asp:TextBox ID="tbCompName" runat="server" Text='<%# Bind("CompanyName") %>' MaxLength="50" Width="100px"></asp:TextBox></td>
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
                        <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandName="DeleteMembers" CommandArgument='<%# Eval("Pin") + "," + Eval("EmployeeNumber") + "," + Eval("CompanyName")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
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
