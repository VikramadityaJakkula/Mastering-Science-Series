<%@ Page enableEventValidation="false" viewStateEncryptionMode="Never" Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Quiz.aspx.cs" Inherits="Quiz" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        #Text1
        {
            top: -396px;
            left: 158px;
            position: absolute;
            height: 22px;
            width: 128px;
        }
        #timeLabel1
        {
            top: -397px;
            left: 200px;
            position: absolute;
            height: 22px;
            width: 128px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageArea" Runat="Server">

 <table class="style13" width="100%">
             <tr class="SubjectHead_linksGrid">
                 <td class="SubjectHead_links">
                     &nbsp; &nbsp;
                     <asp:HyperLink ID="HyperLink1" runat="server" 
                         NavigateUrl="http://www.quizmine.com" CssClass="navigateLinks"> Home </asp:HyperLink> >
                     <asp:HyperLink ID="HyperLink2" runat="server" 
                         NavigateUrl="~/MainPage.aspx" CssClass="navigateLinks"> Mastering Everyday Math </asp:HyperLink>   >
                     
                     
                     <asp:Label runat="server" ID="quizMenu" ></asp:Label>                     
                     
                     </td>
             </tr>
         </table>


 <asp:Panel ID="MainPanel" runat="server" 
        
        style="position: relative; width: 100%; top: 0px; left: 0px; height: 1095px;">   
   
    <asp:Label ID="timeLabel" runat=server  
        style="top: -380px; left: 1px; position: absolute; height: 19px; width: 127px; z-index: 1;" 
        Text="Total Time (sec)  : " Font-Names="Book Antiqua" Visible="False"></asp:Label>
   
    <asp:TextBox ID="timeLabel1" runat="server"         
        style="top: -380px; left: 123px; position: absolute; height: 19px; width: 42px" 
        Font-Bold="True" ForeColor="#003300" Visible="true"></asp:TextBox>
 
    <script type="text/javascript">

        var time = 0;
   //    window.onload = ShowTime;
        
        function ShowTime() {
            document.getElementById("<%= timeLabel1.ClientID %>").value = String(++time);
            window.setTimeout("ShowTime()", 1000);
        }
        
        function ask() {

                var dis = true;
                if ((document.getElementById("<%= askCompleteConfirmation.ClientID %>").value == "true") && (document.getElementById("<%= askConfirmation.ClientID %>").value == "true"))
                    dis = confirm('Are you sure you would like to Complete the Quiz? You still have some questions unanswered and marked a few for review.');
                else if (document.getElementById("<%= askCompleteConfirmation.ClientID %>").value == "true")
                    dis = (confirm('Are you sure you would like to Complete the Quiz? You still have some questions unanswered.'));

                if (dis == true) {
                    document.getElementById("<%= completeQuiz.ClientID %>").style.visibility = "Hidden";
                    document.getElementById("<%= completeQuiz0.ClientID %>").style.visibility = "Hidden";
                }
                        
                    return dis;
                                
            }

   </script>
 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
  <asp:Label ID="quizName" runat="server" 
        style="top: 9px; left: 0px; position: absolute; height: 19px; width: 100%; text-align: center; float: none;" 
        Text="Label" CssClass="bg-light" Font-Bold="False" Font-Size="Large" 
         ForeColor="#006699"></asp:Label>
     
  <asp:LinkButton ID="tutorialLinkButton" runat="server" 
        
        style="top: 41px; left: 289px; position: absolute; height: 23px; width: 180px; text-align: center;" 
        onclick="tutorialLinkButton_Click" BackColor="White" BorderColor="Black" 
        BorderStyle="Outset" BorderWidth="1px" Font-Bold="True" Font-Italic="True" 
        Font-Size="Large" Font-Underline="False" ForeColor="#0099FF" 
        Font-Names="Book Antiqua">View Tutorial</asp:LinkButton>   
    
    
  <asp:LinkButton ID="QuizLinkButton" runat="server" 
        
        style="top:41px; left:106px; position: absolute; height: 23px; width: 180px; text-align: center;" 
        onclick="QuizLinkButton_Click" BackColor="White" BorderColor="Black" 
        BorderStyle="Outset" BorderWidth="1px" Font-Bold="True" Font-Italic="True" 
        Font-Size="Large" Font-Underline="False" ForeColor="#0099FF" 
        Font-Names="Book Antiqua">Quiz</asp:LinkButton>   
      
  <asp:LinkButton ID="VideoLinkButton" runat="server" 
        
        style="top:41px; left:655px; position: absolute; height: 23px; width: 180px; text-align: center;" 
         BackColor="White" Text="View Video"
        BorderColor="Black" BorderStyle="Outset" BorderWidth="1px" Font-Bold="True" 
        Font-Italic="True" Font-Size="Large" Font-Underline="False" 
        ForeColor="#0099FF" Font-Names="Book Antiqua"  runat="server"
          OnClick="VideoLinkButton_Click" ></asp:LinkButton>

     <asp:LinkButton ID="AnimationLinkButton" runat="server" BackColor="White" 
         BorderColor="Black" BorderStyle="Outset" BorderWidth="1px" Font-Bold="True" 
         Font-Italic="True" Font-Names="Book Antiqua" Font-Size="Large" 
         Font-Underline="False" ForeColor="#0099FF" OnClick="AnimationLinkButton_Click" 
         style="top:41px; left:472px; position: absolute; height: 23px; width: 180px; text-align: center;">View Animation</asp:LinkButton>

   <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">

        <ContentTemplate>
  
  <asp:MultiView ID="MainMultiView" runat="server" ActiveViewIndex="0" 
               >

 
               
                <asp:View ID="quizView" runat="server">
 
     <asp:Panel ID="quizPanel" runat="server" 
             
             
         
         
         style="top: 81px; left: -5px; position: absolute; height: 1009px; width: 100%" >

  
    <asp:Label ID="evaluate" runat="server" Text="" Font-Bold="True" 
        
        
        style="top: 71px; left: 200px; position: absolute; height: 19px; width: 68px"></asp:Label>
  
    <asp:Label ID="instructions" runat="server" 
        Text="Correct Mark : +1 | Negative Mark : 0" 
             style="top: 0px; left: 590px; position: absolute; height: 20px; width: 261px; text-align: right;"></asp:Label>
    
    <asp:Button ID="completeQuiz0" runat="server" Font-Bold="True" 
        onclick="Button1_Click" 
        style="top: 34px; left: 614px; position: absolute; height: 28px; width: 149px" 
        Text="Complete Quiz " OnClientClick="return ask()" />     
        
         <asp:Button ID="completeQuiz" runat="server" Font-Bold="True" 
             onclick="Button1_Click" OnClientClick="return ask()" 
             style="top: 290px; left: 614px; position: absolute; height: 28px; width: 149px" 
             Text="Complete Quiz " />
        
    <asp:UpdateProgress ID="UpdateProgress" runat="server" 
                AssociatedUpdatePanelID="QuestionUpdatePanel" DisplayAfter="100"><ProgressTemplate>
            <asp:Label ID="loading" runat="server" 
    style="top: 153px; left: 720px; position: absolute; height: 19px; width: 157px" 
    Text="Loading........" Font-Bold="True" Font-Italic="True" Font-Size="Larger" 
                    ForeColor="Red"></asp:Label></ProgressTemplate></asp:UpdateProgress>
     
    <asp:UpdatePanel ID="QuestionUpdatePanel" runat="server"><ContentTemplate>
    
    <asp:Label ID="questionNumber" runat="server" Text="Label"       
                            
                style="top: 71px; left: 98px; position: absolute; height: 70px; width: 93px; text-align: center; float: none;" 
                BorderColor="#C0C7FE" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" 
                Font-Names="Times New Roman" Font-Size="Medium" ForeColor="Black">
                
                </asp:Label>
     
     <asp:Label ID="question" runat="server" 
                            style="top: 71px; left: 192px; position: absolute; height: 70px; width: 649px; text-align: justify; float: none;" 
                            Text="Label" BorderColor="#C0C7FE" BorderStyle="Solid" 
                BorderWidth="1px" Font-Bold="False" Font-Names="Courier New" 
                Font-Size="Large" ForeColor="#000066"></asp:Label>
      
      <asp:RadioButtonList ID="options" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="options_SelectedIndexChanged" 
                            
                style="top: 144px; left: 98px; position: absolute; height: 137px; width: 744px; float: none;" 
                BorderColor="#C0C7FE" BorderStyle="Solid" BorderWidth="1px" 
                Font-Names="Times New Roman" Font-Size="Medium">
                
                <asp:ListItem></asp:ListItem><asp:ListItem></asp:ListItem><asp:ListItem></asp:ListItem><asp:ListItem></asp:ListItem>
                
                </asp:RadioButtonList>
        <asp:Button ID="previous0" runat="server" 
        style="top: 34px; left: 143px; position: absolute; height: 28px; width: 149px; right: 571px; float: none;" 
        Text="&lt;&lt;&lt; Prev" onclick="previous_Click" 
                Font-Bold="True"  EnableViewState=true/>
                
                <asp:Button ID="previous" runat="server" EnableViewState="true" 
            Font-Bold="True" onclick="previous_Click" 
            style="top: 290px; left: 143px; position: absolute; height: 28px; width: 149px; right: 571px; float: none;" 
            Text="&lt;&lt;&lt; Prev" />
                
                <asp:Button ID="next0" runat="server" 
        style="top: 34px; left: 296px; position: absolute; height: 28px; width: 149px; float: none;" 
        Text="Next &gt;&gt;&gt;" onclick="next_Click" Font-Bold="True"  
            EnableViewState=true/>
        <asp:Button ID="next" runat="server" EnableViewState="true" Font-Bold="True" 
            onclick="next_Click" 
            style="top: 290px; left: 296px; position: absolute; height: 28px; width: 149px; float: none;" 
            Text="Next &gt;&gt;&gt;" />
        </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="options" 
                EventName="SelectedIndexChanged" /><asp:AsyncPostBackTrigger ControlID="previous" EventName="Click" /><asp:AsyncPostBackTrigger ControlID="next" EventName="Click" /></Triggers></asp:UpdatePanel>
    
    <asp:UpdatePanel ID="SolutionUpdatePanel" runat="server"><ContentTemplate>
    
    <asp:Panel runat="server" ID="solutionPanel" 
                    
            style="top: 391px; left: -1px; position: absolute; height: 905px; width: 855px">
                    
                    <asp:Label ID="time" runat="server" 
        style="top: -139px; left: 643px; position: absolute; height: 27px; width: 198px; text-align: center;" 
        Text="Label" BorderColor="#C0C7FE" BorderStyle="Solid" BorderWidth="1px" 
                Font-Names="times new roman, medium"></asp:Label>
                
                <asp:Label ID="answer" runat="server" Text="111&lt;br&gt;&lt;br&gt;Label" 
                   style="top: -62px; left: 99px; position: absolute; height: 133px; width: 744px; text-align: left;" 
                BorderColor="#C0C7FE" BorderStyle="Solid" BorderWidth="1px" 
                Font-Names="Courier New" Font-Size="Medium" Font-Bold="False"></asp:Label>
                
               <asp:Label ID="solution" runat="server" 
                style="top: 75px; left: 99px; position: absolute; height: 514px; width: 744px" 
                Text="
&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;&amp;#160;
                " Font-Names="Tahoma" Font-Size="Small" BorderColor="#C0C7FE" BorderStyle="Solid" 
                        BorderWidth="1px" ></asp:Label>
                
                
                    <asp:Image ID="result" runat="server" 
            style="top: -228px; left: 405px; position: absolute; height: 97px; width: 114px" /><asp:Label ID="Label2" runat="server" Font-Bold="True" 
                style="top: -62px; left: 101px; position: absolute; height: 19px; width: 61px" 
                Text="Answer :"></asp:Label>&#160;</asp:Panel>
     
     </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="options" 
                EventName="SelectedIndexChanged" /><asp:AsyncPostBackTrigger ControlID="next" EventName="Click" /><asp:AsyncPostBackTrigger ControlID="previous" EventName="Click" /></Triggers></asp:UpdatePanel>
    
    <asp:UpdatePanel ID="QuestionListUpdatePanel" runat="server" 
             UpdateMode="Conditional">
             
             <ContentTemplate>
             
             <asp:HiddenField ID="askConfirmation" runat="server" Value="" />
             <asp:HiddenField ID="askCompleteConfirmation" runat="server" Value="true" />
            <asp:HiddenField ID="disableCompleteButton" runat="server" Value="false" />
             
             <asp:Button ID="markForReview0" runat="server" Text="Mark for Review" 
                     Font-Bold="True" onclick="markForReview_Click" 
             style="top: 34px; left: 455px; position: absolute; height: 28px; width: 149px" />
             
                 <asp:Button ID="markForReview" runat="server" Font-Bold="True" 
                     onclick="markForReview_Click" 
                     style="top: 290px; left: 455px; position: absolute; height: 28px; width: 149px" 
                     Text="Mark for Review" />
             
             <asp:GridView ID="questionView" runat="server" AllowPaging="True" 
                     AutoGenerateColumns="False" onpageindexchanging="questionListPageChange" 
                     onrowcommand="questionSelected" 
                     
                     
                     style="top: 25px; left: 17px; position: absolute; width: 59px; text-align: center" 
                     BackColor="White" BorderColor="#3366CC" BorderStyle="Solid" BorderWidth="0px" 
                     CellPadding="1" Font-Bold="True" PageSize="15">
                 <PagerSettings Mode="NextPreviousFirstLast" />
                 <RowStyle BackColor="White" Font-Bold="True" ForeColor="#003399" /><Columns><asp:ButtonField DataTextField="number" DataTextFormatString="{0}" 
                             HeaderText="Go" CommandName="selected"><HeaderStyle BackColor="#666699" /><ItemStyle Font-Bold="True" Font-Underline="False" /></asp:ButtonField></Columns>
                 <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                 <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                 <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                 <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                 </asp:GridView>
              
              </ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="markForReview" EventName="Click" /><asp:AsyncPostBackTrigger ControlID="previous" EventName="Click" /><asp:AsyncPostBackTrigger ControlID="next" EventName="Click" /><asp:AsyncPostBackTrigger ControlID="options" 
                     EventName="SelectedIndexChanged" /></Triggers></asp:UpdatePanel>
    
    </asp:Panel>

</asp:View>



<asp:View ID="animationView" runat="server">
       
   <asp:Panel ID="animationPanel" runat="server" 
             
             
        
        
        style="top: 87px; left: 19px; position: absolute; height: 724px; width: 817px">
       <iframe id="anime" runat="server" BorderColor="#C0C7FE" BorderStyle="Solid" BorderWidth="1px" 
                  frameborder="0" scrolling="no" 
                 
                 
                 
           style="top: 33px; left: 98px; position: absolute; height: 548px; width: 649px"></iframe>   
                  
             <asp:Label ID="animationLabel" runat="server" Font-Bold="True" 
                 Font-Names="Times New Roman" Font-Size="Large" ForeColor="#000066" 
                 style="top: 5px; left: 255px; position: absolute; height: 19px; width: 334px; text-align: center" 
                 Text="Animation on Arithmetic Calculations"></asp:Label>
              
             
                  
             
                  
             
                  
         </asp:Panel>
     </asp:View> 


<asp:View ID="tutorialView" runat=server>
      <asp:Panel ID="tutorialPanel" runat="server" 
          
          style="top:83px; left: 1px; position: absolute; height: 1004px; width: 100%">


       <iframe id="tutorial"  runat="server" BorderColor="#C0C7FE" BorderStyle="Solid" BorderWidth="1px" 
                  frameborder="1" scrolling="auto"                           
              
              style="border: thin solid #E1E1FF; top: 0px; left: 32px; position: absolute; height: 994px; width: 790px"></iframe>   
          
 </asp:Panel>
     </asp:View>

<asp:View ID="videoView" runat="server">
       
   <asp:Panel ID="videoPanel" runat="server" 
             
             
        
        
        style="top: 87px; left: 19px; position: absolute; height: 724px; width: 817px">
       <iframe id="video" runat="server" BorderColor="#C0C7FE" BorderStyle="Solid" BorderWidth="1px" 
                  frameborder="0" scrolling="no"             
                 
           
           
           
           style="top: 34px; left: -4px; position: absolute; height: 620px; width: 837px"></iframe>   
                  
             <asp:Label ID="videoLabel" runat="server" Font-Bold="True" 
                 Font-Names="Times New Roman" Font-Size="Large" ForeColor="#000066" 
                 style="top: 5px; left: 255px; position: absolute; height: 19px; width: 334px; text-align: center" 
                 Text="Videos on Arithmetic Calculations"></asp:Label>
              
             
                  
             
                  
             
                  
         </asp:Panel>
     </asp:View> 


   </asp:MultiView>
   
           </ContentTemplate>
 
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="QuizLinkButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="AnimationLinkButton" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="VideoLinkButton" EventName="Click" />
            <asp:PostBackTrigger ControlID="completeQuiz" />
            <asp:PostBackTrigger ControlID="completeQuiz0" />
            <asp:AsyncPostBackTrigger ControlID="tutorialLinkButton" EventName="Click" />
        </Triggers>
 
 </asp:UpdatePanel>
  
  </asp:Panel>  
</asp:Content>


