<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EnableCookie.aspx.cs" Inherits="EnableCookie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageArea" Runat="Server">
  
  <asp:Panel ID="main" runat=server 
        
        style="position: relative; width: 100%; top: 0px; left: 0px; height: 447px">
    <asp:Label ID="Label2" runat="server" ForeColor="Red" 
        style="position: absolute; top: 43px; left: 279px; height: 19px; width: 314px; text-align: center" 
        Text="Please Enable the Cookies to View the Page."></asp:Label>
    <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" 
        ForeColor="#000099" 
        
          
          style="top: 79px; left: 367px; position: absolute; height: 19px; width: 142px; text-align: center" 
          CssClass="cssLinkLargeRedN" Font-Size="Large">Main Menu</asp:HyperLink>
</asp:Panel>
</asp:Content>

