Public Class Footer
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    '   Protected WithEvents anchUserStatus As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents lnkPp As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents USFooter As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents IndiaFooter As System.Web.UI.HtmlControls.HtmlGenericControl
    '   Protected WithEvents A2 As System.Web.UI.HtmlControls.HtmlAnchor
    '  Protected WithEvents divUSA As System.Web.UI.HtmlControls.HtmlGenericControl
    ' Protected WithEvents divUK As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents divIndia As System.Web.UI.HtmlControls.HtmlGenericControl

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        ' If cookie is USA then show USA Div

        If Not IsNothing(Request.Cookies("UserCountry")) Then

            If Request.Cookies("UserCountry").Value.ToString = "USA" Then

                divIndia.Visible = False
                divUK.Visible = False
                divUSA.Visible = True

            ElseIf Request.Cookies("UserCountry").Value.ToString = "India" Then

                divUSA.Visible = False
                divUK.Visible = False
                divIndia.Visible = True

            ElseIf Request.Cookies("UserCountry").Value.ToString = "UK" Then
                divUSA.Visible = False
                divIndia.Visible = False
                divUK.Visible = True

            End If
        End If

        If Not IsNothing(Request.QueryString("UserCountry")) Then
            If Request.QueryString("UserCountry") = "USA" Then

                divIndia.Visible = False
                divUK.Visible = False
                divUSA.Visible = True

            ElseIf Request.QueryString("UserCountry") = "India" Then

                divUSA.Visible = False
                divUK.Visible = False
                divIndia.Visible = True

            ElseIf Request.QueryString("UserCountry") = "UK" Then

                divUSA.Visible = False
                divIndia.Visible = False
                divUK.Visible = True

            ElseIf Request.QueryString("UserCountry") = "Other" Then

                divIndia.Visible = False
                divUK.Visible = False
                divUSA.Visible = True


            End If
        End If



        If Not IsNothing(Request.QueryString("UserCountry")) Then


            If Request.QueryString("UserCountry") = "India" Then


                Response.Cookies("UserCountry").Value = "India"

                Response.Cookies("UserCountry").Expires = DateTime.MaxValue

            End If

            If Request.QueryString("UserCountry") = "USA" Then


                Response.Cookies("UserCountry").Value = "USA"

                Response.Cookies("UserCountry").Expires = DateTime.MaxValue

            End If

            If Request.QueryString("UserCountry") = "Other" Then

                Response.Cookies("UserCountry").Value = "USA"

                Response.Cookies("UserCountry").Expires = DateTime.MaxValue

            End If

            If Request.QueryString("UserCountry") = "UK" Then

                Response.Cookies("UserCountry").Value = "UK"

                Response.Cookies("UserCountry").Expires = DateTime.MaxValue

            End If


        End If


        ' If cookie is India then show India Div

        ' If no cookie then show USA Div

        'Put user code to initialize the page here
        'If Not IsNothing(Request.Cookies("StudentId")) Then
        '    If (Request.Cookies("StudentId").Value <> "") Then
        '        If Not IsNothing(Request.Cookies("StudentMode")) Then
        '            If Request.Cookies("StudentMode").Value.ToLower <> "preview" Or Request.Cookies("StudentMode").Value = "" Then
        '                anchUserStatus.InnerHtml = "<span class=FooterOuterLink>Account</span>"
        '                anchUserStatus.HRef = "EditAccount.aspx"
        '                lnkPp.HRef = "Help.aspx"
        '            Else
        '                anchUserStatus.InnerHtml = "<span class=FooterOuterLink>Register</span>"
        '                anchUserStatus.HRef = "Registration.aspx"
        '                lnkPp.HRef = "help_school_inst.aspx"
        '            End If
        '        End If
        '    End If
        'End If
    End Sub

End Class
