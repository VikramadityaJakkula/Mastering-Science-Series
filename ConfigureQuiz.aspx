<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfigureQuiz.aspx.cs" Inherits="ConfigureQuiz" %>
<%@ Reference VirtualPath="~/MainPage.aspx" %>
<%@ Reference VirtualPath="~/PreviewQuizzes.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="PageArea" ContentPlaceHolderID="PageArea" Runat="Server">
  
  <table width=100%>
        <tr class="SubjectHead_linksGrid">
                 <td class="SubjectHead_links">
                     &nbsp; &nbsp;
                     <asp:HyperLink ID="HyperLink2" runat="server" 
                         NavigateUrl="http://www.quizmine.com" CssClass="navigateLinks">Home</asp:HyperLink> >
                     <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/MainPage.aspx" CssClass="navigateLinks">Mastering Everyday Math</asp:HyperLink> >
                     
                     
                     <asp:Label runat="server" ID="quizMenu" ></asp:Label>                                         
                     
                     </td>
             </tr>
    </table>
  
  <asp:Panel runat=server ID="MainPanel" 
        
        style="position: relative; height:399px; width: 100%; top: 0px; left: 0px;">
     
   
    <asp:Label ID="Label2" runat="server" 
        style="top: 91px; left: 174px; position: absolute; height: 19px; width: 245px; float: none; margin-top: 0px; text-align: right;" 
        Text="Select the Number of Questions :" Font-Bold="True" 
        Font-Names="Book Antiqua" Font-Size="Medium"></asp:Label>
    <asp:Button ID="startButton" runat="server" 
        style="top: 151px; left: 380px; position: absolute; height: 26px; width: 112px; float: none; margin-top: 0px;" 
        Text="Start the Quiz" ForeColor="Black" BackColor="#FFCC66" 
          Font-Names="Book Antiqua" CssClass="controls" 
         />
    <asp:DropDownList ID="numberOfQuestionsBox" runat="server"  
    
        
        
        
          
          style="top: 91px; left: 471px; position: absolute; height: 26px; width: 111px; float: none;">
        <asp:ListItem Value="0"></asp:ListItem>
    </asp:DropDownList>
   
      <asp:Label ID="quizName" runat="server" 
          style="top: 32px; left: 0px; position: absolute; height: 21px; width: 100%; text-align: center; float: none;" 
          Text="Label" CssClass="bg-light" Font-Size="Large"></asp:Label>
    <img alt="" src="Images/teacher.jpg" 
        
        
          
          style="z-index: -1; top:161px; left: 123px; position: absolute; height: 202px; width: 227px" /><asp:Label ID="quizID" runat="server" Text="Label" Visible="False"></asp:Label>
    </asp:Panel>
    </asp:Content>

