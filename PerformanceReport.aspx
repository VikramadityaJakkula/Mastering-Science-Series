<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PerformanceReport.aspx.cs" Inherits="PerformanceReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style12
        {
            width: 111px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageArea" Runat="Server">

   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <table class="style13" width="100%">
             <tr class="SubjectHead_linksGrid">
                 <td class="SubjectHead_links">
                     &nbsp; &nbsp;
                     <asp:HyperLink ID="HyperLink1" runat="server" 
                         NavigateUrl="http://www.quizmine.com" CssClass="navigateLinks"> Home </asp:HyperLink> > 
                     <asp:HyperLink ID="HyperLink2" runat="server" 
                         NavigateUrl="~/MainPage.aspx" CssClass="navigateLinks"> Mastering Everyday Math </asp:HyperLink>>
                         Report
                     
                     </td>
             </tr>
         </table>


     <asp:Panel ID="MainPanel" runat="server"                     
        style="top: 0px; left: 0px; width: 100%; position: relative; height: 787px;">
    
       
       
<div style="position:relative">
</div>
   
   <div style="position:absolute">
   <asp:LinkButton ID="BenchmarkButton" runat="server" BackColor="White" 
             BorderColor="Black" BorderStyle="Outset" BorderWidth="1px" Font-Bold="True" 
             Font-Italic="True" Font-Names="Book Antiqua" Font-Size="Large" 
             Font-Underline="False" ForeColor="#0099FF"  
             
           style="top: 20px; left: 562px; position: absolute; height: 23px; width: 180px; text-align: center;" 
           onclick="BenchmarButton_Click">Benchmarks</asp:LinkButton>
   <asp:LinkButton ID="HistoryButton" runat="server" BackColor="White" 
             BorderColor="Black" BorderStyle="Outset" BorderWidth="1px" Font-Bold="True" 
             Font-Italic="True" Font-Names="Book Antiqua" Font-Size="Large" 
             Font-Underline="False" ForeColor="#0099FF"  
             
           style="top: 20px; left: 379px; position: absolute; height: 23px; width: 180px; text-align: center;" 
           onclick="HistoryButton_Click">History</asp:LinkButton>
   <asp:LinkButton ID="ProgressButton" runat="server" BackColor="White" 
             BorderColor="Black" BorderStyle="Outset" BorderWidth="1px" Font-Bold="True" 
             Font-Italic="True" Font-Names="Book Antiqua" Font-Size="Large" 
             Font-Underline="False" ForeColor="#0099FF"  
             
           style="top: 20px; left: 196px; position: absolute; height: 23px; width: 180px; text-align: center;" 
           onclick="ProgressButton_Click">Progress Chart</asp:LinkButton>
       </div>
   
 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
   
    
      <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">     
    
 
 
 <asp:View ID="BenchmarkView" runat="server">
    
            <asp:Label ID="benchmarkLabel" runat="server" 
        style="top:61px; left: 214px; position: absolute; height: 19px; width: 450px; text-align: center;" 
        Text="Overall Performance Report" Font-Bold="True" Font-Italic="True" 
        Font-Names="Book Antiqua" Font-Size="Large" ForeColor="#666699"></asp:Label>
 
   <table  style="width: 100%; top: 90px; left: 0px; position: absolute; ">
   
   <tr>
   <td>
     <asp:GridView ID="BenchmarkTable" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" 
                
                style="text-align: center; left: 0px; width: 100%; position: relative; top: 0px; height: 49px;" 
                AllowPaging="True" onpageindexchanging="pageChanged" ForeColor="#333333" 
                HorizontalAlign="Left" PageSize="12" AllowSorting="True" >
                <PagerSettings Position="TopAndBottom" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                <Columns>
                    <asp:BoundField DataField="quizType" HeaderText="Quiz Topic">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle HorizontalAlign="Left" Wrap="True" Width="400px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="numberOfQuestions" HeaderText="# Questions" />
                    <asp:BoundField DataField="percentageBenchmark" HeaderText="% Correct" 
                        DataFormatString="{0:F2}" />
                    <asp:BoundField DataField="timeBenchmark" HeaderText="Average Time(sec)" 
                        DataFormatString="{0:F2}" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView> 
    </td></tr>
 
 <tr><td>&nbsp;</td></tr>
         
               <tr>
                   <td style="text-align: center; color: #FFFFFF;" bgcolor="#003366">
                       Report Description</td>
               </tr>
                   
               
         <tr>
             <td style="text-align: left">
                 &nbsp; The report shows the overall status of how a particular quiz is doing.</td>
       </tr>
                   
               
         <tr>
             <td>
             <table align="center" cellpadding="0">
                     <tr>
                         <td class="style12" bgcolor="#FFFFCC">
                             Quiz Topic</td>
                         <td>
                             The topic of the quiz.</td>
                     </tr>
                     <tr>
                         <td class="style12" bgcolor="#FFFFCC">
                             # Questions</td>
                         <td>
                             Number of questions taken so far </td>
                     </tr>
                     <tr>
                         <td class="style12" bgcolor="#FFFFCC">
                             % Correct</td>
                         <td>
                             Percentage of questions answered correctly</td>
                     </tr>
                     <tr>
                         <td class="style12" bgcolor="#FFFFCC">
                             Time(sec)</td>
                         <td>
                             Average time taken to answer each question</td>
                     </tr>
                 </table>
                 </td>
       </tr>
                   
               
         </table>
         
         </asp:View>
 
 
  <asp:View ID="PerformanceView" runat="server">
  
        <asp:Label ID="performanceLabel" runat="server" 
        style="top: 61px; left: 214px; position: absolute; height: 19px; width: 450px; text-align: center;" 
        Text="Progress Report" Font-Bold="True" Font-Italic="True" 
        Font-Names="Book Antiqua" Font-Size="Large" ForeColor="#666699"></asp:Label>
   
    
         
      <table  style="width: 100%; top: 90px; left: 0px; position: absolute; ">
 
   <tr>
   <td>
   
   
       <asp:GridView ID="PerformanceTable" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" 
                
           style="text-align: center; left: 0px; width: 100%; position: relative; top: 0px; height: 49px;" 
                     AllowPaging="True" onpageindexchanging="pageChanged" 
                HorizontalAlign="Left" PageSize="12" AllowSorting="True" 
              ForeColor="#333333" >
                <PagerSettings Position="TopAndBottom" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Size="Small" />
                <Columns>
                    <asp:BoundField DataField="quizType" HeaderText="Quiz Topic">
                    <HeaderStyle Wrap="False" />
                    <ItemStyle HorizontalAlign="Left" Wrap="True" Width="350px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="grade" HeaderText="Performance" />
                    <asp:BoundField 
                        HeaderText="# Questions" DataField="numberOfQuestions" />
                    <asp:BoundField DataField="percentage" DataFormatString="{0:F2}" 
                        HeaderText="% Correct" />
                    <asp:BoundField HeaderText="Benchmark %" DataField="percentageBenchmark" />
                    <asp:BoundField HeaderText="Time (sec)" DataField="averageTime" />
                    <asp:BoundField HeaderText="Benchmark Time(sec)" DataField="timeBenchmark" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </asp:GridView>
 </td>       
     </tr> 

<tr><td style="text-align: center">
   
          <asp:Label ID="subscribePerformance" runat="server" CssClass="imp" Font-Size="Medium" 
              style="height: 19px; width: 100%; text-align: center; " 
              Text="Please **LOGIN** or **REGISTER** to View your Personal GRADES and compare your Overall Performance with others" 
              Visible="False"></asp:Label>
   </td></tr>
   

      <tr><td>&nbsp;</td></tr>
    
               <tr>
                   <td style="text-align: center; color: #FFFFFF;" bgcolor="#003366">
                   
                       Report Description</td>
               </tr>
                   
               
         <tr>
             <td style="text-align: left">
                 &nbsp;&nbsp;&nbsp; This report shows a your personal performance in each quiz .&nbsp;</td>
        </tr>
                   
               
         <tr>
             <td>
                 <table align="center" cellpadding="0">
                     <tr>
                         <td class="style12" bgcolor="#FFFFCC">
                             Quiz Topic</td>
                         <td>
                             The topic of the quiz.</td>
                     </tr>
                     <tr>
                         <td bgcolor="#FFFFCC" class="style12">
                             Performance</td>
                         <td>
                             Your personal grade in the quiz (based on Percentage Correct)</td>
                     </tr>
                     <tr>
                         <td class="style12" bgcolor="#FFFFCC">
                             # Questions</td>
                         <td>
                             Number of questions taken by you in the quiz </td>
                     </tr>
                     <tr>
                         <td class="style12" bgcolor="#FFFFCC">
                             % Correct</td>
                         <td>
                             Percentage of questions answered correctly by you. </td>
                     </tr>
                     <tr>
                         <td bgcolor="#FFFFCC" class="style12">
                             Benchmark %</td>
                         <td>
                             Percentage of questions answered correctly by all the users
                         </td>
                     </tr>
                     <tr>
                         <td class="style12" bgcolor="#FFFFCC">
                             Time(sec)</td>
                         <td>
                             Average time taken by you to answer each question</td>
                     </tr>
                     <tr>
                         <td bgcolor="#FFFFCC" class="style12">
                             Benchmark Time</td>
                         <td>
                             Average time taken by all users to answer a question .</td>
                     </tr>
                 </table>
             </td>
       </tr>
                   
               
         </table>
     
        </asp:View>


<asp:View ID="HistoryView" runat="server">
  
        <asp:Label ID="historyLabel" runat="server" 
        style="top: 65px; left: 214px; position: absolute; height: 19px; width: 450px; text-align: center;" 
        Text="Previous Quizzes Completed" Font-Bold="True" Font-Italic="True" 
        Font-Names="Book Antiqua" Font-Size="Large" ForeColor="#666699"></asp:Label>
   

     <table  style="width: 100%; top: 90px; left: 0px; position: absolute; ">
   
   <tr>
   <td>
            <asp:GridView ID="HistoryTable" runat="server" AllowPaging="True" 
                   AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                   ForeColor="#333333" HorizontalAlign="Left" onpageindexchanging="pageChanged" 
                   PageSize="15" 
                   
               
                style="text-align: center; left: 0px; width: 100%; position: relative; top: 0px; height: 49px;" >
                        <PagerSettings Position="TopAndBottom" />
                   <RowStyle BackColor="#F7F6F3" Font-Size="Small" ForeColor="#333333" />
                   <Columns>
                       <asp:BoundField DataField="time" HeaderText="Date" />
                       <asp:BoundField DataField="quizType" HeaderText="Quiz Topic">
                           <HeaderStyle Wrap="False" />
                           <ItemStyle HorizontalAlign="Left" Width="325px" Wrap="True" />
                       </asp:BoundField>
                       <asp:BoundField DataField="numberOfQuestions" HeaderText="# Questions" />
                       <asp:BoundField DataField="percentage" DataFormatString="{0:F2}" 
                           HeaderText="% Correct " />
                       <asp:BoundField DataField="averageTime" DataFormatString="{0:F2}" 
                           HeaderText="Time (sec)" />
                   </Columns>
                   <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                   <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                   <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                   <EditRowStyle BackColor="#999999" />
                   <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
               </asp:GridView>
           </td>
                   
        </tr>  
   
   <tr><td style="text-align: center">
   
          <asp:Label ID="subscribeHistory" runat="server" CssClass="imp" Font-Size="Medium" 
              style="height: 19px; width: 100%; text-align: center; " 
              Text="Please **LOGIN** or **REGISTER** to keep Track of all the Previous Quizzes Taken" 
              Visible="False"></asp:Label>
   </td></tr>
       <tr><td>&nbsp;</td></tr>
                   <tr>
                       <td bgcolor="#003366" style="text-align: center; color: #FFFFFF;">
                           Report Description</td>
                   </tr>
       <tr>
           <td>
               &nbsp;&nbsp; This report keeps track of all the quizzes completed by you previously
           </td>
       </tr>
       <tr>
           <td>
               <table align="center" cellpadding="0">
                   <tr>
                       <td bgcolor="#FFFFCC" class="style12">
                           Date
                       </td>
                       <td>
                           Time and date when the quiz was taken</td>
                   </tr>
                   <tr>
                       <td bgcolor="#FFFFCC" class="style12">
                           Quiz Topic</td>
                       <td>
                           The topic of the quiz.</td>
                   </tr>
                   <tr>
                       <td bgcolor="#FFFFCC" class="style12">
                           # Questions</td>
                       <td>
                           Number of questions in the quiz</td>
                   </tr>
                   <tr>
                       <td bgcolor="#FFFFCC" class="style12">
                           % Correct</td>
                       <td>
                           Percentage of questions answered correctly</td>
                   </tr>
                   <tr>
                       <td bgcolor="#FFFFCC" class="style12">
                           Time(sec)</td>
                       <td>
                           Average time taken to answer each question</td>
                   </tr>
               </table>
           </td>
       </tr>                  
               
       
  </table>
        </asp:View>


</asp:MultiView>
  
     
        </ContentTemplate>

   
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BenchmarkButton" />
            <asp:AsyncPostBackTrigger ControlID="ProgressButton" />
            <asp:AsyncPostBackTrigger ControlID="HistoryButton" />
        </Triggers>

   
    </asp:UpdatePanel>

</asp:Panel>
</asp:Content>

