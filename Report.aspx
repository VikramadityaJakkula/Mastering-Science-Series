<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" %>
<%@ PreviousPageType VirtualPath="~/Quiz.aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageArea" Runat="Server">
   
    <table class="style13" width="100%">
             <tr class="SubjectHead_linksGrid">
                 <td class="SubjectHead_links">
                     &nbsp; &nbsp;
                     <asp:HyperLink ID="HyperLink1" runat="server" 
                         NavigateUrl="http://www.quizmine.com" CssClass="navigateLinks"> Home </asp:HyperLink> >
                     <asp:HyperLink ID="HyperLink2" runat="server" 
                         NavigateUrl="~/MainPage.aspx" CssClass="navigateLinks"> Mastering Everyday Math</asp:HyperLink> >   <asp:Label runat="server" ID="quizMenu" ></asp:Label>     > Report                   
                     
                     </td>
             </tr>
         </table>

   
   <asp:Panel ID="mainpanel" runat="server" 
        
        
        style="position: relative; width: 100%; height: 429px; top: 0px; left: 0px;">
        
       
   
    <asp:Label ID="averageTime" runat="server" 
        style="top: 244px; left: 440px; position: absolute; height: 19px; width: 224px; text-align: center;" 
        Text="Label" Font-Names="Book Antiqua"></asp:Label>
    <asp:Label ID="percentage" runat="server" 
        style="top: 290px; left: 440px; position: absolute; height: 19px; width: 224px; text-align: center;" 
        Text="Label" Font-Names="Book Antiqua"></asp:Label>
    <asp:Label ID="a" runat="server" Font-Bold="False" 
        style="top: 120px; left: 217px; position: absolute; height: 19px; width: 212px" 
        Text="Total Number of Questions :" CssClass="labelfont" ForeColor="#0066FF"></asp:Label>
    <asp:Label ID="Label3" runat="server" Font-Bold="False" 
        style="top: 160px; left: 217px; position: absolute; height: 19px; width: 194px" 
        Text="Attempted Questions :"  CssClass="labelfont" ForeColor="#0066FF"></asp:Label>
    <asp:Label ID="Label4" runat="server" Font-Bold="False" 
        style="top: 201px; left: 217px; position: absolute; height: 19px; width: 166px" 
        Text="Correct Answers :"  CssClass="labelfont" ForeColor="#0066FF"></asp:Label>
    <asp:Label ID="Label5" runat="server" Font-Bold="False" 
        style="top: 244px; left: 217px; position: absolute; height: 19px; width: 210px" 
        Text="Average Time per Question :"  CssClass="labelfont" ForeColor="#0066FF"></asp:Label>
    <asp:Label ID="subscribelabel" runat="server" Font-Bold="True" 
        
           style="top: 334px; left: 90px; position: absolute; height: 38px; width: 669px; text-align: center;" 
           Font-Names="Arial" ForeColor="Red" 
        > Quizmine offers <span style="color:Green">**Detailed Reports**</span> to keep track of personal performance in the quizzes.<br />Please subscribe to maintain detailed reports for better performance.</asp:Label>
       <asp:Label ID="Label6" runat="server" CssClass="labelfont" Font-Bold="False" 
           ForeColor="#0066FF" 
           style="top: 288px; left: 217px; position: absolute; height: 25px; width: 205px" 
           Text="Overall Percentage :"></asp:Label>
    <asp:Label ID="numberOfQuestions" runat="server" Text="Label" 
        
        
        
        style="top: 120px; left: 440px; position: absolute; height: 26px; width: 224px; text-align: center;" 
        Font-Names="Book Antiqua"></asp:Label>
    <asp:Label ID="correctQuestions" runat="server" 
        style="top: 201px; left: 440px; position: absolute; height: 21px; width: 224px; text-align: center;" 
        Text="Label" Font-Names="Book Antiqua"></asp:Label>
    <asp:Label ID="attemptedQuestions" runat="server" 
        style="left: 440px; position: absolute; height: 19px; width: 224px; top: 160px; text-align: center;" 
        Text="Label" Font-Names="Book Antiqua"></asp:Label>
    
    <asp:Label ID="reportTitle" runat="server" Font-Bold="True" 
        Font-Names="Book Antiqua" Font-Size="X-Large" ForeColor="#000066" 
        style="top: 46px; left: 313px; position: absolute; height: 19px; width: 222px; text-align: center; bottom: 391px;" 
        Text="Quiz Report"></asp:Label>
    <asp:HyperLink ID="subscribe" runat="server" 
    
        style="top: 400px; left: 293px; position: absolute; height: 19px; width: 263px; text-align: center;" 
        CssClass="cssLinkLarge" Font-Size="Small" Font-Underline="False" 
           NavigateUrl="~/PreviewReports.aspx">Click here to view <span style="font-size:medium; color:Green"><u>Sample Reports</u></span></asp:HyperLink>
       <asp:HyperLink ID="performancereport" runat="server" CssClass="cssLinkLarge" 
           Font-Size="Medium" Font-Underline="True" 
           
           
           
           style="top: 357px; left: 325px; position: absolute; height: 19px; width: 198px; text-align: center;">View Performance Report</asp:HyperLink>
    <img alt="" src="Images/reportcard.gif" 
        
        
        
           
           
            style="width: 133px; top: 38px; left: 697px; position: absolute; height: 129px; z-index: -1;" />
        
        </asp:Panel>
    </asp:Content>

