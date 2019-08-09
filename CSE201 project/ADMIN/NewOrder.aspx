<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN/Home.master" AutoEventWireup="true" CodeFile="NewOrder.aspx.cs" Inherits="ADMIN_NewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">
                NEW ORDER -
                <asp:Label ID="lbll" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                                CellPadding="2" ForeColor="Black" GridLines="None" DataKeyNames="id" 
                                 Width="938px" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting" >
                              
                                
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" 
                                        SortExpression="email" >
                    <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="img" DataImageUrlFormatString="{0}" HeaderText="Image" ControlStyle-BorderStyle="NotSet">
                    </asp:ImageField>
                    <asp:BoundField DataField="foodName" HeaderText="ProductName" 
                                        SortExpression="pname" >
                    <ItemStyle Width="180px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" />
                    <asp:BoundField DataField="orderDate" HeaderText="DATA" 
                                        SortExpression="cname" />
                    <asp:BoundField DataField="TotalPrice" HeaderText="totalprice" 
                                        SortExpression="cname" />
                    <asp:CommandField DeleteText="Dispatch" HeaderText="Dispatch" ShowDeleteButton="True">
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
