using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class ConfigureQuiz : System.Web.UI.Page
{
    private int[] numbers;

    private void createArray()
    {
        if (Request.Cookies["StudentMode"] != null)
        {
            if (Request.Cookies["StudentMode"].Value == "Preview" || Request.Cookies["StudentMode"].Value == "Study")
            {
                numbers = new int[] { 20, 5, 10, 15, 25, 50, 100 };

            }
            else
                numbers = new int[] { 20, 5, 10, 15, 25, 50, 75, 100 };
        }
        else
            Response.Redirect("EnableCookie.aspx");

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["StudentMode"] == null)
            Response.Cookies["StudentMode"].Value = "Preview";

        String quiz;
        startButton.PostBackUrl = "Quiz.aspx";
        if (Page.IsPostBack == false)
        {

            if (Request.Cookies["StudentMode"] == null)
                Response.Redirect("MainPage.aspx");

            if (Request.QueryString["QuizId"] != null && Request.QueryString["QuizId"].ToString() != "")
            {
                quiz = Request.QueryString["QuizId"].ToString();

                if (System.Configuration.ConfigurationManager.AppSettings[quiz] != null)
                {
                    if (Request.Cookies["StudentMode"] != null && (Request.Cookies["StudentMode"].Value == "Preview" || Request.Cookies["StudentMode"].Value == "Study"))
                    {
                        if (!(quiz=="F808776C-D798-4948-AD15-65A5DA5B4679" || quiz =="11DFFFDA-581E-4917-AB4B-AD1686FAB065" || quiz=="490EA2BE-2D24-422e-85E2-FF68CAC89519"
                            || quiz=="55B1ED06-8BF1-4ec2-8B2C-C5BFE6090EB5"))
                            Response.Redirect("MainPage.aspx");
                    }
                    quizID.Text = quiz;
                    quizMenu.Text = " Quiz on " + System.Configuration.ConfigurationManager.AppSettings[quiz].ToString();
                    quizName.Text = System.Configuration.ConfigurationManager.AppSettings[quiz].ToString();
                    createArray();
                    numberOfQuestionsBox.Items.Clear();
                    numberOfQuestionsBox.DataSource = numbers;
                    numberOfQuestionsBox.DataBind();
                    numberOfQuestionsBox.SelectedIndex = 0;
                }
                else
                    Response.Redirect("Error.aspx");
            }
            else
                Response.Redirect("MainPage.aspx");


        }

    }

}
