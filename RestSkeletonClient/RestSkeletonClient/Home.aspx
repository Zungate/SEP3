<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Default.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RestSkeletonClient.Home" %>

<asp:Content ID="products" ContentPlaceHolderID="Products" runat="server">
   <asp:Repeater ID="data" runat="server">
       <HeaderTemplate><table style="width: 25%" align="center"></HeaderTemplate>
        <ItemTemplate>
        <tr>
            <td><strong>Question <%# Container.ItemIndex + 1 %>:</strong></td>
            <td><%# Container.DataItem %></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
   </asp:Repeater>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
