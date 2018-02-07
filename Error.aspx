<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="detailedReport" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style12
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageArea" Runat="Server"> 

<script type="text/javascript">
    onload = delayRedirect;
function delayRedirect()
 {
 var Timeout = setTimeout("window.location='MainPage.aspx'",5000);
 }
</script>


    <table class="style12">
        <tr>
            <td class="FntSure" style="text-align: center">
                <br />
                <br />
                <br />
                An Error Occurred! We regret the Inconvenience caused.<br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="controls">
                <br />
                This page will redirect itself to the Quiz Menu automatically in 5 sec........<br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
            </td>
        </tr>
    </table>

    </asp:Content>

