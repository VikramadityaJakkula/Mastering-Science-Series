<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PreviewReports.aspx.cs" Inherits="PreviewReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style12
        {
            width: 100%;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageArea" Runat="Server">
<table class="style12">
             <tr class="SubjectHead_linksGrid" style="width:100%">
                 <td class="SubjectHead_links" style="width:100%">
                     &nbsp; &nbsp;
                     <asp:HyperLink ID="HyperLink1" runat="server" 
                         NavigateUrl="http://www.quizmine.com" CssClass="navigateLinks"> Home </asp:HyperLink> >
                     <asp:HyperLink ID="HyperLink2" runat="server" 
                         NavigateUrl="~/MainPage.aspx" CssClass="navigateLinks"> Arithmetic Helper </asp:HyperLink> 
                     
                     </td>
             </tr>
         </table>

    <table class="style12">
    <tr style="width:100%"><td style="width:100%; text-align: center; color: #003300;" 
            class="Yellow">The Reports are available only for Subscribed Users.<br />
&nbsp;<a href="http://www.quizmine.com/purchase.aspx" style="color:Red; font-weight:bolder; font-size:medium">**SUBSCRIBE**</a> and keep track of your performances in the Quizzes.&nbsp; </td></tr>
        <tr>
            <td colspan="2" 
                style="text-align: center; color: #000099; font-size: medium; font-weight: bold;" 
                bgcolor="Silver" class="bg-light">
                PERSONAL
                PERFORMANCE REPORT</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <img alt="" src="Images/PerformanceReport.jpg" 
                    style="width: 845px; height: 426px;"  /></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center; color: #000099; font-size: medium; font-weight: bold;" 
                bgcolor="Silver" class="bg-light">
                HISTORY</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <img alt="" src="Images/HistoryReport.jpg" 
                    style="width: 849px; height: 382px" /></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center; color: #000099; font-size: medium; font-weight: bold;" 
                bgcolor="Silver" class="bg-light">
                BENCHMARKS</td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="BarColor">
                <img alt="" src="Images/BenchmarkReport.jpg" 
                    style="width: 848px; height: 514px" /></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
          <tr style="width:100%"><td style="width:100%; text-align: center; color: #003300;" 
            class="Yellow">The Reports are available only for Subscribed Users.<br />
&nbsp;<a href="http://www.quizmine.com/purchase.aspx" style="color:Red; font-weight:bolder; font-size:medium">**SUBSCRIBE**</a> and keep track of your performances in the Quizzes.&nbsp; </td></tr>
    </table>
</asp:Content>

