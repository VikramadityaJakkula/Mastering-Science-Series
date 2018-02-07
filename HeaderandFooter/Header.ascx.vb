Imports System.Data.SqlClient
Imports System.Data



Public Class Header
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'Protected WithEvents Signout As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents referFriend As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents StudyMode As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents CoachingMode As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents ExamMode As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents SubQue As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents lbllogin As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents Login As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents ChangePassword As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents divMarketingLinks As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents ProgressReport As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents lblGuest As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents anchRegistration As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents lblSeperator As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents divForLoginStudent As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents divOfModes As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents hrefComunity As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents EnableStudentSuccess As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents hrefHelp As System.Web.UI.HtmlControls.HtmlAnchor
    'Protected WithEvents dvWelcome As System.Web.UI.HtmlControls.HtmlGenericControl
    'Protected WithEvents dvHelp As System.Web.UI.HtmlControls.HtmlGenericControl

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
        'Put user code to initialize the page here
        ' This code checks for community link, its not visible at the main page
        ' This is settin community link to false so that it is not visible

        Dim ExamId As String
        Dim ExamIdTemp As String

        ExamId = System.Configuration.ConfigurationManager.AppSettings("ExamId")
        ExamIdTemp = System.Configuration.ConfigurationManager.AppSettings("ExamIdTemp")


        If Not IsNothing(Request.Cookies("StudentId")) Then
            If Request.Cookies("StudentId").Value <> "" Then
                dvWelcome.Visible = True
            End If
        End If

        If Not IsNothing(ExamId) Then
            If ExamId <> "" Then
                dvHelp.Visible = True
            End If
        End If
        hrefComunity.Visible = False
        ' This is an html server anchor control

        Dim ds As DataSet
        Dim TotalPoints As Integer
        Dim dsExamname As DataSet

        'DONE
        If (IsNothing(ExamId)) Then
            If (Not IsNothing(ExamIdTemp)) Then
                If (ExamIdTemp <> "") Then

                    dsExamname = GetDataSet("GetExamNameForGivenExamID '" & ExamIdTemp & "'")
                    ' Now we are executing a stored procedure GetExamNameForGivenExamID

                    If (dsExamname.Tables(0).Rows.Count > 0) Then
                        hrefHelp.Visible = True
                        hrefHelp.HRef = "http://www.quizmine.com/help.aspx?ExamId=" & ExamId & "&HelpId=" & dsExamname.Tables(1).Rows(0).Item(0).ToString
                    End If
                End If
            End If
        Else
            If ExamId <> "" Then
                dsExamname = GetDataSet("GetExamNameForGivenExamID '" & ExamId & "'")
                If (dsExamname.Tables(0).Rows.Count > 0) Then
                    hrefHelp.Visible = True
                    '                hrefHelp.HRef = dsExamname.Tables(0).Rows(0).Item(0).ToString.Replace(" ", "") & "_help.aspx"
                    hrefHelp.HRef = "http://www.quizmine.com/help.aspx?ExamId=" & ExamId & "&HelpId=" & dsExamname.Tables(1).Rows(0).Item(0).ToString
                End If
            End If
        End If

        'DONEE
        If (Not IsNothing(ExamIdTemp)) Then
            If (ExamIdTemp <> "") Then
                Dim dsForumid As DataSet
                If (IsNothing(ExamId)) Then
                    dsForumid = GetDataSet("GetForumId'" & ExamIdTemp & "'")
                Else
                    dsForumid = GetDataSet("GetForumId'" & ExamId & "'")
                End If

                If (dsForumid.Tables(0).Rows.Count > 0) Then

                    ' hrefComunity.Visible = True
                    hrefComunity.HRef = "PopForums/feature/default.aspx?mode=topics&ForumId=" & dsForumid.Tables(0).Rows(0).Item(0)
                End If

                'work around for forum cobination
                If (dsExamname.Tables(0).Rows.Count > 0) Then

                    If (dsExamname.Tables(0).Rows(0).Item(0).ToString.ToLower.IndexOf("wasl") > -1) Then
                        ' hrefComunity.Visible = True
                        hrefComunity.HRef = "PopForums/feature/default.aspx?mode=topics&ForumId=3"
                    End If
                    If (dsExamname.Tables(0).Rows(0).Item(0).ToString.ToLower.IndexOf("bitsat") > -1) Then
                        '    hrefComunity.Visible = True
                        hrefComunity.HRef = "PopForums/feature/default.aspx?mode=topics&ForumId=1"
                    End If

                    If (dsExamname.Tables(0).Rows(0).Item(0).ToString.ToLower.IndexOf("aieee") > -1) Then
                        '  hrefComunity.Visible = True
                        hrefComunity.HRef = "PopForums/feature/default.aspx?mode=topics&ForumId=1"
                    End If
                End If

                'end of work around
            End If
        End If


        If Not Page.IsPostBack Then

            'If Not IsNothing(Request.Cookies("StudentId")) Then
            '    If (Request.Cookies("StudentId").Value <> "") Then
            '        hrefComunity.HRef = "PopForums/feature/default.aspx?mode=topics&ForumID=3"
            '    Else
            '        hrefComunity.HRef = "PopForums/feature/default.aspx?mode=topics&ForumID=3"
            '    End If
            'Else
            '    hrefComunity.HRef = "PopForums/feature/default.aspx"
            'End If

            'USER LOGGED IN
            If Not IsNothing(Request.Cookies("UserName")) Then
                If (Request.Cookies("UserName").Value <> "") Then
                    Signout.Visible = True
                    'SubQue.Visible = True
                    referFriend.Visible = True
                    ChangePassword.Visible = True
                    divMarketingLinks.Visible = False
                    If Not IsNothing(Request.Cookies("UserName")) Then
                        If Request.Cookies("UserName").Value <> "" Then
                            ' lbllogin.Text = "Welcome " & Request.Cookies("UserName").Value
                            lbllogin.InnerText = "Welcome " & Request.Cookies("UserName").Value & " |"
                            'lbllogin.CssClass = "frmtxt"
                            lbllogin.Attributes.Add("class", "frmtxt")
                            lbllogin.Visible = True
                        Else
                            lbllogin.Visible = False
                        End If
                    Else
                        lbllogin.Visible = False
                    End If

                    If Not IsNothing(Request.Cookies("StudentMode")) Then
                        If Request.Cookies("StudentMode").Value <> "" Then
                            If Not IsNothing(Session("Mode")) Then
                                If Session("Mode") <> "" Then
                                    Response.Cookies("StudentMode").Value = Session("Mode").ToString
                                    Response.Cookies("Mode").Value = Session("Mode").ToString
                                    Session("Mode") = ""
                                    'Response.Cookies("StudentMode").Value = Session("Mode").ToString
                                End If
                            End If
                            If Not IsNothing(ExamId) Then
                                If (ExamId <> "") Then
                                    Dim GetStudentPoints As DataSet

                                    If (Request.Cookies("StudentId").Value <> "") Then
                                        If Not IsNothing(ExamId) Then
                                            If ExamId.ToString <> "" Then
                                                GetStudentPoints = GetDataSet("GetVerificationfromStudentExam '" & Request.Cookies("StudentId").Value.ToString & "','" & ExamId.ToString & "'")
                                            Else
                                                GetStudentPoints = GetDataSet("GetVerificationfromStudentExam '" & Request.Cookies("StudentId").Value.ToString & "','" & ExamId.ToString & "'")
                                            End If
                                        Else
                                            GetStudentPoints = GetDataSet("GetVerificationfromStudentExam '" & Request.Cookies("StudentId").Value.ToString & "','" & ExamId.ToString & "'")
                                        End If
                                    End If

                                    If (Request.Cookies("StudentId").Value.ToString <> "") Then
                                        If GetStudentPoints.Tables(1).Rows.Count > 0 Then
                                            TotalPoints = System.Convert.ToInt32(GetStudentPoints.Tables(1).Rows(0).Item(0))
                                        Else
                                            'if LOGGED-IN USER is Accessing Unregistered exam then SET PREVIEW MODE
                                            referFriend.Visible = True
                                            Login.Visible = False
                                            anchRegistration.Visible = True
                                            lblSeperator.Visible = True
                                            ChangePassword.Visible = True
                                            StudyMode.HRef = ""
                                            StudyMode.InnerHtml = "<font color=black>You are in <b>Preview Mode</b> |</font>"
                                            StudyMode.Visible = True
                                            anchRegistration.Visible = False
                                            StudyMode.Attributes.Add("class", "frmtxt")
                                            CoachingMode.InnerHtml = " Upgrade to <b>Free Mode</b>"
                                            CoachingMode.Attributes.Add("class", "frmtxtForHeader")
                                            CoachingMode.Visible = True
                                            CoachingMode.HRef = "http://www.quizmine.com/EditAccount.aspx"
                                            CoachingMode.Title = "Please add exam in your account."
                                            'CoachingMode.HRef = "Purchase.aspx?Mode=Preview"
                                            Response.Cookies("StudentId").Value = Request.Cookies("StudentId").Value.ToString
                                            lblSeperator.Visible = False
                                            Exit Sub
                                        End If
                                    Else
                                        referFriend.Visible = True
                                        Login.Visible = False
                                        anchRegistration.Visible = True
                                        lblSeperator.Visible = True
                                        ChangePassword.Visible = True
                                        StudyMode.HRef = ""
                                        StudyMode.InnerHtml = "<font color=black>You are in <b>Preview Mode</b> |</font>"
                                        StudyMode.Visible = True
                                        anchRegistration.Visible = False
                                        StudyMode.Attributes.Add("class", "frmtxt")
                                        CoachingMode.InnerHtml = " Upgrade to <b>Free Mode |</b>"
                                        CoachingMode.Attributes.Add("class", "frmtxtForHeader")
                                        CoachingMode.Visible = True
                                        CoachingMode.HRef = "http://www.quizmine.com/EditAccount.aspx"
                                        CoachingMode.Title = "Please add exam in your account."
                                        'CoachingMode.HRef = "Purchase.aspx?Mode=Preview"
                                        Response.Cookies("StudentId").Value = Request.Cookies("StudentId").Value.ToString
                                        lblSeperator.Visible = False
                                        If Request.Url.ToString.ToLower.IndexOf("login.aspx") > -1 Then 'Or Request.Url.ToString.ToLower.IndexOf("viewpreview.aspx") > -1 Then
                                            Login.Visible = False
                                            anchRegistration.Visible = False
                                            lblSeperator.Visible = False
                                            lblGuest.Visible = False
                                            Response.Cookies("StudentId").Value = ""
                                            divOfModes.Visible = False
                                            ' Response.Write("")
                                        End If
                                        ProgressReport.Visible = True
                                        If IsNothing(ExamIdTemp) Then
                                            ProgressReport.Visible = False
                                        End If
                                        EnableStudentSuccess.Visible = False
                                        If Request.Url.ToString.ToLower.IndexOf("default.aspx") > -1 Or Request.Url.ToString.ToLower.IndexOf("registration.aspx") > -1 Or Request.Url.ToString.ToLower.IndexOf("login.aspx") > -1 Then
                                            ProgressReport.Visible = False
                                            StudyMode.Visible = False
                                            CoachingMode.Visible = False
                                            ExamMode.Visible = False
                                            referFriend.Visible = False
                                            hrefComunity.Visible = False
                                            hrefHelp.Visible = False

                                            ' EnableStudentSuccess.Visible = True

                                        End If
                                        Exit Sub
                                    End If

                                    GetStudentPoints.Dispose()
                                    GetStudentPoints = Nothing
                                End If

                            End If

                            Dim strMode As String
                            If Request.Cookies("StudentMode").Value = "Exam" Then
                                ExamMode.Visible = True
                                CoachingMode.Visible = True
                                If (Not IsNothing(Request.Cookies("Mode"))) Then
                                    If Request.Cookies("Mode").Value = "Exam" Then
                                        ExamMode.Attributes.Add("class", "frmtxt")
                                        ExamMode.HRef = ""

                                        If System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("BasicModePoints") And System.Convert.ToInt32(TotalPoints) < (System.Configuration.ConfigurationManager.AppSettings("AdvancedModePoints")) Then
                                            strMode = "Basic Paid Mode "

                                        ElseIf System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("AdvancedModePoints") And System.Convert.ToInt32(TotalPoints) < (System.Configuration.ConfigurationManager.AppSettings("LifeTimeModePoints")) Then
                                            strMode = "Premium Paid Mode "


                                        ElseIf System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("LifeTimeModePoints") Then
                                            strMode = "LifeTime Mode "

                                        ElseIf System.Convert.ToInt32(TotalPoints) < System.Configuration.ConfigurationManager.AppSettings("BasicModePoints") Then
                                            strMode = "Free Mode" 'added on 1/12/2005

                                        End If
                                        ExamMode.InnerHtml = "<font color=black>You are in <b> " & strMode & " </b> "
                                        CoachingMode.HRef = Request.Url.ToString()
                                        CoachingMode.Visible = False
                                        referFriend.Attributes.Add("class", "frmtxtForHeader")
                                        referFriend.Visible = False
                                        If Request.Url.ToString.ToLower.IndexOf("default.aspx") > -1 Then
                                            divOfModes.Visible = False
                                            hrefHelp.Visible = False
                                        End If
                                    Else
                                        CoachingMode.Attributes.Add("class", "frmtxt")
                                        ExamMode.HRef = Request.Url.ToString()
                                        CoachingMode.HRef = ""
                                    End If

                                End If

                                'ExamMode.HRef = "xyz.aspx"
                                'CoachingMode.HRef = "abc.aspx"
                            ElseIf Request.Cookies("StudentMode").Value = "Coaching" Then
                                ExamMode.Visible = True
                                CoachingMode.Visible = True
                                CoachingMode.Attributes.Add("class", "frmtxt")
                                CoachingMode.HRef = ""
                                If System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("BasicModePoints") And System.Convert.ToInt32(TotalPoints) < (System.Configuration.ConfigurationManager.AppSettings("AdvancedModePoints")) Then
                                    strMode = "Basic Paid Mode "

                                ElseIf System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("AdvancedModePoints") Then
                                    strMode = "Premium Paid Mode "

                                ElseIf System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("LifeTimeModePoints") Then
                                    strMode = "LifeTime Mode "


                                ElseIf System.Convert.ToInt32(TotalPoints) < System.Configuration.ConfigurationManager.AppSettings("BasicModePoints") Then
                                    strMode = "Free Mode" 'added on 1/12/2005

                                End If
                                CoachingMode.InnerHtml = "<font color=black size=1>You are in <b> " & strMode & " </b> "
                                'CoachingMode.Attributes.Add("align", "left")
                                ProgressReport.InnerHtml = "<b>My Arithmetic Report</b>"

                                'dhamaka
                                If System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("BasicModePoints") And System.Convert.ToInt32(TotalPoints) < (System.Configuration.ConfigurationManager.AppSettings("AdvancedModePoints")) Then
                                    ExamMode.InnerHtml = "Upgrade to <b>Premium Paid Mode </b>"
                                End If

                                If System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("AdvancedModePoints") And System.Convert.ToInt32(TotalPoints) < (System.Configuration.ConfigurationManager.AppSettings("LifeTimeModePoints")) Then
                                    ExamMode.InnerHtml = "Upgrade to <b>Lifetime Mode </b>"
                                End If

                                ExamMode.Attributes.Add("class", "frmtxtForHeader")
                                ExamMode.HRef = "http://www.quizmine.com/Purchase.aspx?Mode=Basic"
                                referFriend.Attributes.Add("class", "frmtxtForHeader")
                                If Request.Url.ToString.ToLower.IndexOf("default.aspx") > -1 Then
                                    divOfModes.Visible = False
                                    hrefHelp.Visible = False
                                End If
                            ElseIf Request.Cookies("StudentMode").Value = "Study" Then
                                ' StudyMode.Attributes.Add("class", "frmtxt")
                                StudyMode.HRef = ""
                                If System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("BasicModePoints") And System.Convert.ToInt32(TotalPoints) < (System.Configuration.ConfigurationManager.AppSettings("AdvancedModePoints")) Then
                                    strMode = "Basic Paid Mode "

                                ElseIf System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("AdvancedModePoints") Then
                                    strMode = "Premium Paid Mode "

                                ElseIf System.Convert.ToInt32(TotalPoints) >= System.Configuration.ConfigurationManager.AppSettings("LifeTimeModePoints") Then
                                    strMode = "LifeTime Mode "

                                ElseIf System.Convert.ToInt32(TotalPoints) < System.Configuration.ConfigurationManager.AppSettings("BasicModePoints") Then
                                    strMode = "Free Mode" 'added on 1/12/2005

                                End If
                                StudyMode.InnerHtml = "<font color=black>You are in <b>" & strMode & "</b> "
                                StudyMode.Visible = True
                                StudyMode.Attributes.Add("class", "frmtxt")
                                ' ExamMode.Visible = True
                                CoachingMode.InnerHtml = "Upgrade to <b>Basic Paid Mode </b>"
                                CoachingMode.Visible = True
                                CoachingMode.Attributes.Add("class", "frmtxtForHeader")
                                ' ExamMode.HRef = "Purchase.aspx"
                                CoachingMode.HRef = "http://www.quizmine.com/Purchase.aspx?Mode=Study"
                                'ProgressReport.Disabled = True 'added on 12th of August 
                                ProgressReport.HRef = ""
                                'ProgressReport.Title = "This feature is available in Basic Paid Mode  only."
                                referFriend.Attributes.Add("class", "frmtxtForHeader")
                                If Request.Url.ToString.ToLower.IndexOf("default.aspx") > -1 Then
                                    divOfModes.Visible = False
                                    hrefHelp.Visible = False
                                End If
                            ElseIf Request.Cookies("StudentMode").Value = "Preview" Then
                                Signout.Visible = False
                                referFriend.Visible = False
                                Login.Visible = True
                                anchRegistration.Visible = True
                                lblSeperator.Visible = True
                                ChangePassword.Visible = False
                            End If
                        End If
                    End If

                Else
                    'i.e. if Preview Mode then :start
                    ' If (Request.Url.ToString.ToLower.IndexOf("login.aspx") <= -1) Then
                    StudyMode.HRef = ""
                    StudyMode.InnerHtml = "<font color=black>You are in <b>Preview Mode</b> |</font>"
                    Response.Cookies("StudentMode").Value = "Preview" 'newly added line
                    StudyMode.Visible = True
                    StudyMode.Attributes.Add("class", "frmtxt")
                    ' ExamMode.Visible = True
                    'If Not IsNothing(ExamId) Then
                    '    If ExamId <> "" Then
                    '        CoachingMode.InnerHtml = " Upgrade to <b><u>Self-Study Mode (Free)</u>|</b>"
                    '    Else
                    '        CoachingMode.InnerHtml = " Upgrade to <b><u>Self-Study Mode (Free)</u></b>"
                    '    End If
                    'Else
                    '    CoachingMode.InnerHtml = " Upgrade to <b><u>Self-Study Mode (Free)</u></b>"
                    'End If
                    CoachingMode.InnerHtml = " Upgrade to <b>Free Mode |</b>"
                    CoachingMode.Attributes.Add("class", "frmtxtForHeader")
                    divForLoginStudent.Visible = False
                    If Request.Url.ToString.ToLower.IndexOf("default.aspx") > -1 Then
                        CoachingMode.InnerHtml = "Upgrade to <b><u>Free Mode</u> </b>"
                        divOfModes.Visible = False
                        hrefHelp.Visible = False
                    End If
                    CoachingMode.Visible = True
                    ' ExamMode.HRef = "Purchase.aspx"
                    CoachingMode.HRef = "http://www.quizmine.com/Registration.aspx"
                    Signout.Visible = False
                    'SubQue.Visible = False
                    referFriend.Visible = False
                    Login.Visible = True
                    anchRegistration.Visible = True
                    lblSeperator.Visible = True
                    lblGuest.InnerHtml = "Welcome Guest! |"
                    'lbllogin.CssClass = "frmtxt"
                    lblGuest.Attributes.Add("class", "frmtxt")
                    lblGuest.Visible = True
                End If
            Else ' If  IsNothing(Request.Cookies("StudentId")) Then
                'i.e. if Preview Mode then :start
                ' If (Request.Url.ToString.ToLower.IndexOf("login.aspx") <= -1) Then
                StudyMode.HRef = ""
                StudyMode.InnerHtml = "<font color=black>You are in <b>Preview Mode</b> |</font>"
                Response.Cookies("StudentMode").Value = "Preview" 'newly added line
                StudyMode.Visible = True
                StudyMode.Attributes.Add("class", "frmtxt")
                CoachingMode.InnerHtml = "Upgrade to <b>Free Mode |</b>"
                CoachingMode.Attributes.Add("class", "frmtxtForHeader")
                divForLoginStudent.Visible = False
                If Request.Url.ToString.ToLower.IndexOf("default.aspx") > -1 Then
                    CoachingMode.InnerHtml = "Upgrade to <b><u>Free Mode</u> </b>"
                    divOfModes.Visible = False
                    hrefHelp.Visible = False
                End If
                CoachingMode.Visible = True
                CoachingMode.HRef = "http://www.quizmine.com/Registration.aspx"
                Signout.Visible = False
                referFriend.Visible = False
                Login.Visible = True
                anchRegistration.Visible = True
                lblSeperator.Visible = True
                lblGuest.InnerHtml = "Welcome Guest! |"
                lblGuest.Attributes.Add("class", "frmtxt")
                lblGuest.Visible = True
            End If
        End If
        'Response.Write(Request.Url.ToString.ToLower.IndexOf("login.aspx"))
        'If Request.Url.ToString.IndexOf("StudyN.aspx") > -1 Then
        '    If (Not IsNothing(Request.Cookies("StudentMode"))) Then
        '        'If Request.Cookies("StudentMode").Value.ToLower <> "study" And Request.Cookies("StudentMode").Value.ToLower <> "coaching" And Request.Cookies("StudentMode").Value.ToLower <> "exam" And Request.Cookies("StudentMode").Value <> "" Then
        '        If Request.Cookies("StudentMode").Value.ToLower = "preview" Then
        '            StudyMode.HRef = ""
        '            StudyMode.InnerHtml = "<font color=black>You are in <b>Preview Mode</b> |</font>"
        '            StudyMode.Visible = True
        '            StudyMode.Attributes.Add("class", "frmtxt")
        '            ' ExamMode.Visible = True
        '            CoachingMode.InnerHtml = "Upgrade to <b><u>Self-Study Mode (Free)</u> |</b>"
        '            CoachingMode.Visible = True
        '            ' ExamMode.HRef = "Purchase.aspx"
        '            CoachingMode.HRef = "Purchase.aspx?Mode=Preview"
        '            ': End
        '            'End If
        '            Signout.Visible = False
        '            'SubQue.Visible = False
        '            referFriend.Visible = False
        '            Login.Visible = True
        '            anchRegistration.Visible = True
        '            lblSeperator.Visible = True
        '            lblGuest.InnerHtml = "Welcome Guest! |"
        '            'lbllogin.CssClass = "frmtxt"
        '            lblGuest.Attributes.Add("class", "frmtxt")
        '            lblGuest.Visible = True
        '        End If
        '    End If

        'End If


        If Request.Url.ToString.ToLower.IndexOf("login.aspx") > -1 Then 'Or Request.Url.ToString.ToLower.IndexOf("viewpreview.aspx") > -1 Then
            Login.Visible = False
            anchRegistration.Visible = False
            lblSeperator.Visible = False
            lblGuest.Visible = False
            Response.Cookies("StudentId").Value = ""
            divOfModes.Visible = False
            ' Response.Write("")
        End If
        ProgressReport.Visible = True
        If IsNothing(ExamIdTemp) Then
            ProgressReport.Visible = False
            anchRegistration.Visible = False
            lblSeperator.Visible = False
        Else
            If ExamIdTemp <> "" Then
                If anchRegistration.Visible = True Then
                    If ExamId <> "" And Request.Url.ToString.ToLower.IndexOf("categories.aspx") > -1 Then
                        anchRegistration.HRef = "http://www.quizmine.com/Registration.aspx?ExamId=" & ExamId
                        Login.HRef = "http://www.quizmine.com/login.aspx?EId=" & ExamId
                    Else
                        anchRegistration.HRef = "http://www.quizmine.com/Registration.aspx?ExamId=" & ExamIdTemp
                        Login.HRef = "http://www.quizmine.com/login.aspx?EId=" & ExamIdTemp
                    End If

                End If
            End If
        End If
        EnableStudentSuccess.Visible = False
        If Request.Url.ToString.ToLower.IndexOf("default.aspx") > -1 Or Request.Url.ToString.ToLower.IndexOf("registration.aspx") > -1 Or Request.Url.ToString.ToLower.IndexOf("login.aspx") > -1 Then
            ProgressReport.Visible = False
            StudyMode.Visible = False
            CoachingMode.Visible = False
            ExamMode.Visible = False
            referFriend.Visible = False
            hrefComunity.Visible = False
            hrefHelp.Visible = False
            '            EnableStudentSuccess.Visible = True

        End If
        If (Request.Url.ToString.ToLower.IndexOf("registration.aspx") > -1) Then
            divForLoginStudent.Visible = False
            divOfModes.Visible = False
            anchRegistration.Visible = False
            lblSeperator.Visible = False
        End If
        If (Not IsNothing(Request.Cookies("StudentId"))) Then
            If Request.Cookies("StudentId").Value <> "" Then

            Else
                If (Request.Url.ToString.ToLower.IndexOf("default.aspx") > -1) Then
                    'divForLoginStudent.Visible = False
                    lblGuest.Visible = True
                    anchRegistration.Visible = True
                    lblSeperator.Visible = True
                    Login.Visible = True
                    hrefHelp.Visible = False
                End If
            End If
        Else
            If (Request.Url.ToString.ToLower.IndexOf("default.aspx") > -1) Then
                'divForLoginStudent.Visible = False
                lblGuest.Visible = True
                anchRegistration.Visible = True
                lblSeperator.Visible = True
                Login.Visible = True
                hrefHelp.Visible = False
            End If
        End If



        '##kj start




        '##kj start


        ' VBScript source code
        'Dim ds2KJ, dsExamNewKJ As DataSet

        ''' KJ Examid Fix for navigation

        'If Not IsNothing(ExamId) Then

        '    If ExamId <> "" Then




        '        Dim dsExamNew As DataSet = GetDataSet("GetExamIdforQuizId '" & ExamId & "'")
        '        Dim Examid As String
        '        Dim ExamName As String
        '        If (dsExamNew.Tables(0).Rows.Count > 0) Then
        '            Examid = dsExamNew.Tables(0).Rows(0).Item(0).ToString
        '            ExamName = dsExamNew.Tables(0).Rows(0).Item(1).ToString
        '            Response.Cookies("ExamIdTemp").Value = Examid
        '            Response.Cookies("ExamId").Value = Examid


        '    End If


        '    ds2KJ = GetDataSet("GetExamNameForGivenExamID '" & ExamId & "'")


        '    If ds2KJ.Tables(0).Rows.Count > 0 Then
        '        'pgTitle.InnerText = "Quiz and Exams for " & System.Convert.ToString(ds2KJ.Tables(0).Rows(0).Item(0)).ToUpper
        '        Response.Cookies("ExamName").Value = System.Convert.ToString(ds2KJ.Tables(0).Rows(0).Item(0)).ToUpper
        '        ds2KJ.Dispose()
        '        ds2KJ = Nothing

        '    End If

        'End If

        'End If

        '' KJ SubjectId Fix for navigation

        'If Not IsNothing(Request.QueryString("SubjectId")) Then

        '    If Request.QueryString("SubjectId") <> "" Then

        '        dsExamNewKJ = GetDataSet("GetExamIdbySubjectId '" & Request.QueryString("SubjectId").ToString & "'")

        '        If dsExamNewKJ.Tables(0).Rows.Count > 0 Then

        '            Response.Cookies("ExamIdTemp").Value = dsExamNewKJ.Tables(0).Rows(0).Item(2).ToString()
        '            Response.Cookies("ExamId").Value = dsExamNewKJ.Tables(0).Rows(0).Item(2).ToString()
        '            Response.Cookies("SubjectId").Value = Request.QueryString("SubjectId")

        '        End If
        '        If dsExamNewKJ.Tables(1).Rows.Count > 0 Then

        '            Response.Cookies("ExamName").Value = dsExamNewKJ.Tables(1).Rows(0).Item(0).ToString()

        '        End If

        '        dsExamNewKJ.Dispose()
        '        dsExamNewKJ = Nothing

        '    End If

        'End If

        '' Fix for query string


        'If Not IsNothing(Request.QueryString("quizId")) Then

        '    If Request.QueryString("quizId") <> "" Then



        '        Dim dsExamNew As DataSet = GetDataSet("GetExamIdforQuizId '" & Request.QueryString("quizId") & "'")
        '        Dim Examid As String
        '        Dim ExamName As String
        '        If (dsExamNew.Tables(0).Rows.Count > 0) Then
        '            Examid = dsExamNew.Tables(0).Rows(0).Item(0).ToString
        '            ExamName = dsExamNew.Tables(0).Rows(0).Item(1).ToString
        '            Response.Cookies("ExamIdTemp").Value = Examid
        '            Response.Cookies("ExamId").Value = Examid
        '            Response.Cookies("ExamName").Value = ExamName
        '        End If

        '        dsExamNew.Dispose()
        '        dsExamNew = Nothing


        '    End If

        'End If


        '##kj end


        '## kj end

    End Sub

    Private Sub Signout_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Signout.ServerClick
        Response.Cookies("StudentId").Value = ""
        Response.Cookies("StudentId").Expires = Now.AddDays(-1)
        Response.Cookies("StudentMode").Value = ""
        Response.Cookies("Mode").Value = ""
        Response.Cookies("UserName").Value = ""
        Signout.Visible = False
        If (Not IsNothing(Request.Cookies("UserEmail"))) Then

            Response.Cookies("UserEmail").Expires = Now.AddDays(-1)
        End If


        'If Not IsNothing(Request.Cookies("QuizStuId")) Then
        '    Response.Cookies("QuizStuId").Expires = Now.AddDays(-1)
        'End If
        Response.Redirect("http://www.quizmine.com/Login.aspx")

    End Sub

    Private Function GetDataSet(ByVal SQL As String) As DataSet


        Dim ConnectString As String
        Dim ds As DataSet
        Dim da As SqlDataAdapter

        ConnectString = System.Configuration.ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
        Try
            ds = New DataSet()
            da = New SqlDataAdapter(SQL, ConnectString)

            da.Fill(ds)

            Return ds

        Catch ex As Exception
            Response.Redirect("http://www.quizmine.com/")

        End Try
        Return Nothing

    End Function


End Class
