<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
    #pic
    {
        height: 248px;
        width: 343px;
        top: -357px;
        left: 496px;
        position: absolute;
        z-index: -5;
    }
        .style12
        {
            width: 100%;
            top: 19px;
            left: 3px;
            position: absolute;
            height: 27px;
        }
        .style13
        {
            width: 100%;
        }
      
    </style>
</asp:Content>
<asp:Content ID="PageArea" ContentPlaceHolderID="PageArea" runat="Server">
    <table class="style13">
        <tr class="SubjectHead_linksGrid">
            <td class="SubjectHead_links">
                &nbsp; &nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.quizmine.com"
                    CssClass="navigateLinks"> Home </asp:HyperLink>
                > Mastering Everyday Math
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" Style="top: 0px; left: 0px; height: auto; width: 100%;
        text-align: left; position: relative;">
        <asp:HyperLink ID="performancereport" runat="server" NavigateUrl="~/PerformanceReport.aspx"
            Style="top: 23px; left: 686px; position: absolute; height: 19px; width: 154px;
            text-align: center;" Font-Size="Medium" CssClass="cssLinkLargeRed" Visible="False">Performance Report</asp:HyperLink>
        <img alt="" src="Images/kid.gif" style="height: 158px; width: 175px; top: 96px; left: 546px;
            position: absolute" />
        <asp:Label ID="Label1" runat="server" CssClass="style6" Font-Bold="True" Font-Italic="False"
            Font-Names="Book Antiqua" Font-Overline="False" Font-Size="X-Large" Font-Underline="False"
            ForeColor="#CC3300" Text="Mastering Everyday Math (Infinite questions + performance reports)"></asp:Label>
        <table>
            <tr>
                <td style="text-align: justify;" align="left">
                    <br />
                    <br />
                    <br />
                    <asp:HyperLink ID="previewLink" runat="server" CssClass="cssLinkLargeGreen" Font-Size="Large"
                        Font-Underline="False" Visible="False" NavigateUrl="PreviewQuizzes.aspx">Preview ( FREE Quizzes)</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <!-- <div style="overflow: auto; height: 480px; width: auto"  >  -->
                    <asp:TreeView ID="QuizMenu" runat="server" Font-Names="Book Antiqua" ImageSet="Simple"
                        OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Style="text-align: left;
                        margin-left: 23px; width: 400px">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Bold="True" Font-Size="Small" Font-Underline="False" ForeColor="#FF3300" />
                        <SelectedNodeStyle Font-Bold="True" Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                         <asp:TreeNode SelectAction="Expand" Text="Physics" Value="Physics">
                                <asp:TreeNode Expanded="False" Text="Velocity (Infinite questions)" Value="F808776C-D798-4948-AD15-65A5DA5B4679">
                                </asp:TreeNode>
                                 <asp:TreeNode Expanded="False" Text="Acceleration (Infinite questions)" Value="11DFFFDA-581E-4917-AB4B-AD1686FAB065">
                                </asp:TreeNode>
                                 <asp:TreeNode Expanded="False" Text="Gravity (Infinite questions)" Value="490EA2BE-2D24-422e-85E2-FF68CAC89519">
                                </asp:TreeNode>
                                  <asp:TreeNode Expanded="False" Text="Force (Infinite questions)" Value="55B1ED06-8BF1-4ec2-8B2C-C5BFE6090EB5">
                                </asp:TreeNode>

                              

                                
                            </asp:TreeNode>
                        </Nodes>
                        <RootNodeStyle ForeColor="#000066" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="#0000CC" HorizontalPadding="0px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                    <!-- </div>-->
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
