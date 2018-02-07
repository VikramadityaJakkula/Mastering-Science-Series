<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PreviewQuizzes.aspx.cs" Inherits="PreviewQuizzes" %>

<%@ Reference VirtualPath="~/MainPage.aspx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style13
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageArea" runat="Server">

    <script type="text/javascript">

     
    </script>

    <table class="style13">
        <tr class="SubjectHead_linksGrid">
            <td class="SubjectHead_links">
                &nbsp; &nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.quizmine.com"
                    CssClass="navigateLinks"> Home </asp:HyperLink>
                >
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/MainPage.aspx" CssClass="navigateLinks"> Mastering Everyday Math </asp:HyperLink>
                > Preview Quizzes
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="panel" Style="position: relative; height: 405px; width: 100%;
        top: 0px; left: 0px;">
        <table class="style13" style="top: 3px; left: 0px; height: 323px; width: 100%; text-align: center;
            position: absolute;" cellpadding="0">
            <tr>
                <td>
                    <asp:Label ID="subscribe" runat="server" Style="left: 0px; position: relative; top: 3px;
                        height: 23px; width: 100%; text-align: center; float: left;" CssClass="imp" Font-Bold="False"
                        Font-Size="Medium" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td rowspan="1">
                    <asp:Label ID="Label1" runat="server" Text="Try the following quizzes for free."
                        Style="left: 0px; position: relative; top: 3px; height: 23px; width: 100%; text-align: center;
                        float: left;" CssClass="imp" Font-Bold="False" Font-Size="Medium" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp</td>
            </tr>
            <tr>
                <td class="bg-light">
                    <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Size="Large" ForeColor="#006699"
                        Style="left: 10px; position: relative; top: 0px; height: 23px; width: 99%; text-align: left;
                        float: left;" Font-Names="Book Antiqua">Please choose the <span style="color:Red; font-weight: bold">FREE</span> quiz of your choice</asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp</td>
            </tr>
            <tr>
                <td>
                    <asp:TreeView ID="QuizMenu" runat="server" Font-Names="Book Antiqua" ImageSet="Simple"
                        OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Style="text-align: left;
                        top: 0px; left: 0px; position: relative; height: 190px; margin-left: 23px; width: 100%;
                        float: none;">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Bold="True" Font-Size="Small" Font-Underline="False" ForeColor="#FF3300" />
                        <SelectedNodeStyle Font-Bold="True" Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                         <asp:TreeNode SelectAction="Expand" Text="Commission" Value="Commission">
                                <asp:TreeNode Expanded="False" Text="Commission (Infinite questions)" Value="CB6BD55A-C356-4ff7-AB5E-10D471A64492">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Discounts" Value="Discounts">
                                <asp:TreeNode Expanded="False" Text="Discounts (Infinite questions)" Value="0EB2C22A-DDF4-4565-B97D-293795C31655">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Calculating sales tax" Value="SalesTax">
                                <asp:TreeNode Expanded="False" Text="Calculating sales tax (Infinite questions)"  Value="80826568-BAAD-4327-B79E-49068F05DAD3">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Calculating price with sales tax" Value="SalesTaxwithPrice">
                                <asp:TreeNode Expanded="False" Text="Calculating price with sales tax (Infinite questions)" Value="C623FE9F-4D6B-471b-8029-8D2D497D188B">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Estimating tips" Value="Estimatingtips">
                                <asp:TreeNode Expanded="False" Text="Estimating tips (Infinite questions)" Value="AE88C8DC-74AB-42c4-B591-05274860F50D">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Calculating shipping" Value="Calculatingshipping">
                                <asp:TreeNode Expanded="False" Text="Calculating shipping (Infinite questions)" Value="BB6B6730-CA4F-4f43-BE12-6FC9BD0402A7">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <%--<asp:TreeNode SelectAction="Expand" Text="Exponents" Value="Exponents">
                                <asp:TreeNode Expanded="False" Text="Squares (Infinite questions)" Value="9371C7DB-A24B-4be1-9FEE-6B7A85DB400B">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Percentage" Value="Percentage">
                                <asp:TreeNode Expanded="False" Text="Percentage Type 1(What percent of a is b?) (Infinite questions)"
                                    Value="F7AB6F95-69D3-4611-BED8-362857A3A65C"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Fractions" Value="Fractions">
                                <asp:TreeNode Expanded="False" Text="Fraction Addition (Infinite questions)" Value="768022B5-9141-4574-9EB1-72D185F0FAF6">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Decimal Rounding" Value="Decimal Rounding">
                                <asp:TreeNode Expanded="False" Text="Decimal rounding to 1 decimal place (Infinite questions)"
                                    Value="832A7AEC-5E92-42d7-BC76-CCFAE786D9A5"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Time" Value="Time">
                                <asp:TreeNode Expanded="False" Text="Hours to Minutes Conversion (Infinite questions)"
                                    Value="86E245E0-C54E-4ada-AF27-B9044ADC08F2"></asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Currency" Value="Currency">
                                <asp:TreeNode Expanded="False" Text="US Currency Addition (Infinite questions)" Value="781F7BEE-DA32-4555-9F26-1C618E31E3EA">
                                </asp:TreeNode>
                                 </asp:TreeNode>--%>
                            <%-- <asp:TreeNode SelectAction="Expand" Text="Simple Interest" Value="Simple Interest">
                                <asp:TreeNode Expanded="False" Text="Simple Interest (Infinite questions)" Value="0134BBB6-EA9E-4556-8313-987B84C03F70">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Commission" Value="Commission">
                                <asp:TreeNode Expanded="False" Text="Commission (Infinite questions)" Value="CB6BD55A-C356-4ff7-AB5E-10D471A64492">
                                </asp:TreeNode>
                            </asp:TreeNode>
                            <asp:TreeNode SelectAction="Expand" Text="Discounts" Value="Discounts">
                                <asp:TreeNode Expanded="False" Text="Discounts (Infinite questions)" Value="0EB2C22A-DDF4-4565-B97D-293795C31655">
                                </asp:TreeNode>
                            </asp:TreeNode>--%>
                            <%--<asp:TreeNode SelectAction="Expand" Text="Addition" Value="Addition">
                    <asp:TreeNode Text="Single Digit Addition" 
                        Value="5cb3961b-511e-4262-90c0-478824a44a31"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode SelectAction="Expand" Text="Subtraction" Value="Subtraction">
                    <asp:TreeNode Text="Single Digit Subtraction" 
                        Value="b45bddfb-944f-46ff-b98b-213298a5677e"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode SelectAction="Expand" Text="Multiplication" 
                    Value="Multiplication">
                    <asp:TreeNode Text="Single Digit Multiplication" 
                        Value="b8708d2c-935d-48e3-861d-0a664db56b1c"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode SelectAction="Expand" Text="Division" Value="Division">
                    <asp:TreeNode Text="Division of Two Digit With Single Digit, No Remainder" 
                        Value="62ac9f7a-fa94-4b2a-b249-f2c6377d4ee7"></asp:TreeNode>
                </asp:TreeNode>--%>
                        </Nodes>
                        <RootNodeStyle ForeColor="#000066" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="#0000CC" HorizontalPadding="0px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
