using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        performancereport.NavigateUrl = "PerformanceReport.aspx";
        if (PreviousPage != null && IsPostBack == false)
        {

            ArithmeticHelper.Evaluator ev = PreviousPage.evaluator;
            numberOfQuestions.Text = ev.numberOfQuestions.ToString();
            attemptedQuestions.Text = ev.attemptedQuestions.ToString();
            correctQuestions.Text = ev.correctAnswers.ToString();
            averageTime.Text = ev.averageTime.ToString() + " sec ";
            percentage.Text = (ev.percentageCorrect).ToString();

            if (Request.Cookies["StudentMode"] != null)
            {
                if (Request.Cookies["StudentMode"].Value == "Preview" || Request.Cookies["StudentMode"].Value == "Study")
                    performancereport.Visible = false;
                else
                {
                    subscribe.Visible = false;
                    subscribelabel.Visible = false;
                }
                if (ev.attemptedQuestions != 0)
                {
                    try
                    {
                       new ArithmeticHelper.TableUpdater(ev).insertResult();
                    }
                    catch (SystemException)
                    {
                        Response.Redirect("Error.aspx");
                    }
                }
                else
                    reportTitle.Text = " Quiz Cancelled ";
            }
            else
                Response.Redirect("EnableCookie.aspx");


        }
        else
            Response.Redirect("MainPage.aspx");

    }
}
