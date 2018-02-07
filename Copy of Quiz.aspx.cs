using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Quiz : System.Web.UI.Page
{

    ArithmeticHelper.QuizPaper quiz;
    ArithmeticHelper.Evaluator evaluatorProperty;
    String userID;
    String[] ImageURLS = new String[3] { "Images/wrongImage.png", "Images/correctImage.png", "" };

    public ArithmeticHelper.Evaluator evaluator
    {
        get
        {
            return evaluatorProperty;
        }
    }

    public class questionProperty
    {
        public questionProperty(int n)
        {
            number = n.ToString();
        }
        public String number { get; set; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (PreviousPage != null && PreviousPage.IsCrossPagePostBack == true)
            {
                String quizID; int num;

                ContentPlaceHolder c = (ContentPlaceHolder)PreviousPage.Master.FindControl("PageArea");
                //System.Web.UI.WebControls.Panel c = (System.Web.UI.WebControls.Panel)PreviousPage.Master.FindControl("MainPanel");
                quizName.Text = ((System.Web.UI.WebControls.Label)c.FindControl("quizName")).Text;
                quizID = ((System.Web.UI.WebControls.Label)c.FindControl("quizID")).Text;

                num = Convert.ToInt16(((System.Web.UI.WebControls.DropDownList)c.FindControl("numberOfQuestionsBox")).SelectedValue);

                userID = Session.SessionID + (new Random().Next()).ToString();
                ViewState["userID"] = userID;
                if (quizID == "5968EB4B-C486-435e-B3A2-DEE504E6EFC9" || quizID == "E9AE0DB9-AD58-43e2-AFCD-7E407A549A75" || quizID == "66DD0945-258B-4016-B341-779496328F6D" || quizID == "86E245E0-C54E-4ada-AF27-B9044ADC08F2" || quizID == "3F691386-6107-4166-B5CF-F48532F1A6C7" || quizID == "498B1CD1-6F5B-4766-A08E-56EC007B8FF5")
                    ViewState["QuizType"] = "Time";

                else if (quizID == "75DD4361-B58B-4cc9-8572-00E0F7809F78" || quizID == "9371C7DB-A24B-4be1-9FEE-6B7A85DB400B" || quizID == "FF6D685A-ECE6-4c0c-A946-A22F3323ACAD" || quizID == "8629C229-097B-450e-B152-B6FBCD580C6A")
                    ViewState["QuizType"] = "Functions";

                else if (quizID == "F7AB6F95-69D3-4611-BED8-362857A3A65C" || quizID == "C850925C-A661-4990-93F3-2365988C8DFC" || quizID == "BA16694F-3034-49b2-B339-DB32AC84B674")
                    ViewState["QuizType"] = "Percentage";

                else if (quizID == "768022B5-9141-4574-9EB1-72D185F0FAF6" || quizID == "14E4FDF1-D8C9-4a95-A3E0-F856A2958330" || quizID == "E53B688A-37B4-4fa1-92C1-92BA6E80304F")
                    ViewState["QuizType"] = "Fractions";

                else if (quizID == "832A7AEC-5E92-42d7-BC76-CCFAE786D9A5" || quizID == "F4FC1BB7-6CFC-439a-9B8A-261251124622" || quizID == "CFA6B36D-95F3-4641-BFC7-D1C5C50068BC")
                    ViewState["QuizType"] = "Rounding";

                else if (quizID == "0EB2C22A-DDF4-4565-B97D-293795C31655")
                    ViewState["QuizType"] = "Discount";
                else
                    ViewState["QuizType"] = "Arithmetic";

                quiz = new ArithmeticHelper.QuizEngine().generateQuizPaper(quizID, num);
                previous.Enabled = false; previous0.Enabled = false;
                setLabels();
                setVisibility();

                quiz.stopWatch.Start();
                Cache[userID] = quiz;


            }
            else if (Page.IsPostBack)
            {
                userID = ViewState["userID"].ToString();
                quiz = (ArithmeticHelper.QuizPaper)Cache[userID];
                if (quiz == null)
                    throw new SystemException();
            }
            else
                Response.Redirect("MainPage.aspx");


            if (Request.Cookies["StudentMode"] == null)
            {
                Cache.Remove(userID);
                Response.Redirect("EnableCookie.aspx");
            }
        }
        catch (SystemException)
        {
            Response.Redirect("Error.aspx");
        }
    }


    private void setLabels()
    {
        questionNumber.Text = "Q." + (quiz.presentQuestion + 1).ToString();
        question.Text = quiz.questionaire.ElementAt(quiz.presentQuestion).question.ToString();

        options.Items.Clear();
        options.DataSource = quiz.questionaire.ElementAt(quiz.presentQuestion).options;
        options.DataBind();

        result.ImageUrl = ImageURLS[quiz.questionaire.ElementAt(quiz.presentQuestion).correct];
        time.Text = " Time : " + quiz.questionaire.ElementAt(quiz.presentQuestion).time + " (sec) ";
        string Question = quiz.questionaire.ElementAt(quiz.presentQuestion).question;
        Question = Question.Replace(" Evaluate :", "");
        Question = Question.Replace(" Convert :", "");
        if (ViewState["QuizType"].ToString() == "Time")
        {
            answer.Text = "<br>" + Question +
            "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;<br>&nbsp;&nbsp;&nbsp;" +
            quiz.questionaire.ElementAt(quiz.presentQuestion).answer +
            "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;";
        }
        else if (ViewState["QuizType"].ToString() == "Percentage")
        {
            answer.Text = "<br>" + Question +
   "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;<br>&nbsp;&nbsp;&nbsp;" +
   quiz.questionaire.ElementAt(quiz.presentQuestion).answer +
   "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;";
        }
        else if (ViewState["QuizType"].ToString() == "Functions")
        {
            answer.Text = "<br>" + Question +
   "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;<br>&nbsp;&nbsp;&nbsp;" +
   quiz.questionaire.ElementAt(quiz.presentQuestion).answer +
   "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;";
        }

        else if (ViewState["QuizType"].ToString() == "Fractions")
        {
            answer.Text = "<br>" + Question +
   "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;<br>&nbsp;&nbsp;&nbsp;" +
   quiz.questionaire.ElementAt(quiz.presentQuestion).answer +
   "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;";
        }

        else if (ViewState["QuizType"].ToString() == "Rounding")
        {
            answer.Text = "<br>" + Question +
   "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;<br>&nbsp;&nbsp;&nbsp;" +
   quiz.questionaire.ElementAt(quiz.presentQuestion).answer +
   "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;";
        }
            
         else if (ViewState["QuizType"].ToString() == "Discount")
        {
            answer.Text = "<br>" + Question +
          "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;<br>&nbsp;&nbsp;&nbsp;" +
          quiz.questionaire.ElementAt(quiz.presentQuestion).answer +
          "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;";
        }
        else if (ViewState["QuizType"].ToString() == "Arithmetic")
        {
            answer.Text = "<br>" + Question +
          "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;<br>&nbsp;&nbsp;&nbsp;" +
          quiz.questionaire.ElementAt(quiz.presentQuestion).answer +
          "<br>&nbsp;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;&mdash;";
        }
        setAnswerColor();
        solution.Text = quiz.questionaire.ElementAt(quiz.presentQuestion).solution;

    }

    private void setVisibility()
    {
        if (quiz.questionaire.ElementAt(quiz.presentQuestion).selectedOption == -1)
        {
            options.Enabled = true;
            solutionPanel.Visible = false;
            options.SelectedIndex = -1;
        }
        else
        {
            options.Enabled = false;
            options.SelectedIndex = quiz.questionaire.ElementAt(quiz.presentQuestion).selectedOption;
            solutionPanel.Visible = true;
        }
        dataBindQuestionList();
    }

    private void setAnswerColor()
    {
        if (quiz.questionaire.ElementAt(quiz.presentQuestion).correct == 0)
            answer.ForeColor = System.Drawing.Color.Red;
        else
            answer.ForeColor = System.Drawing.Color.Green;

    }

    protected void previous_Click(object sender, EventArgs e)
    {
        quiz = (ArithmeticHelper.QuizPaper)Cache[userID];
        setTime();

        next.Enabled = true; next0.Enabled = true;
        if (--quiz.presentQuestion == 0)
        { previous.Enabled = false; previous0.Enabled = false; }

        ArithmeticHelper.Question q = quiz.questionaire[quiz.presentQuestion];
        q.markedForReview = false;
        quiz.questionaire[quiz.presentQuestion] = q;


        setLabels();
        setVisibility();
        Cache[userID] = quiz;
    }

    protected void next_Click(object sender, EventArgs e)
    {
        quiz = (ArithmeticHelper.QuizPaper)Cache[userID];
        setTime();

        previous.Enabled = true; previous0.Enabled = true;
        if (++quiz.presentQuestion == (quiz.questionaire.Count - 1))
        { next.Enabled = false; next0.Enabled = false; }

        ArithmeticHelper.Question q = quiz.questionaire[quiz.presentQuestion];
        q.markedForReview = false;
        quiz.questionaire[quiz.presentQuestion] = q;

        setLabels();
        setVisibility();
        Cache[userID] = quiz;
    }

    protected void options_SelectedIndexChanged(object sender, EventArgs e)
    {
        quiz = (ArithmeticHelper.QuizPaper)Cache[userID];
        setTime();
        quiz.questionsAnswered++;
        ArithmeticHelper.Question q = quiz.questionaire[quiz.presentQuestion];
        q.setSelectedOption(options.SelectedIndex);
        if (q.selectedOption == q.options.IndexOf(q.answer))
            q.correct = 1;
        else
            q.correct = 0;
        quiz.questionaire[quiz.presentQuestion] = q;


        result.ImageUrl = ImageURLS[quiz.questionaire.ElementAt(quiz.presentQuestion).correct];
        time.Text = " Time : " + quiz.questionaire.ElementAt(quiz.presentQuestion).time + " (sec) ";
        setAnswerColor();
        setVisibility();
        Cache[userID] = quiz;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if ((ArithmeticHelper.QuizPaper)Cache[userID] != null)
            evaluatorProperty = new ArithmeticHelper.Evaluator((ArithmeticHelper.QuizPaper)Cache[userID]);
        else
        {
            Cache.Remove(userID);
            Response.Redirect("Error.aspx");
        }

        if (Request.Cookies["StudentMode"] != null)
        {
            if (Request.Cookies["StudentMode"].Value == "Preview")
                evaluatorProperty.userID = System.Configuration.ConfigurationManager.AppSettings["AnonymousUser"];
            else
            {
                if (Request.Cookies["StudentId"] != null)
                    evaluatorProperty.userID = Request.Cookies["StudentId"].Value;
                else
                    Response.Redirect("EnableCookie.aspx");
            }
        }
        else
        {
            Response.Redirect("EnableCookie.aspx");
        }
        Cache.Remove(userID);
        Server.Transfer("Report.aspx");

    }

    private bool checkIfMarkedForReview()
    {

        foreach (ArithmeticHelper.Question q in quiz.questionaire)
        {
            if (q.markedForReview == true)
                return true;
        }
        return false;
    }

    protected void setTime()
    {
        ArithmeticHelper.Question q;
        try
        {
            q = quiz.questionaire[quiz.presentQuestion];
            if (q.selectedOption == -1)
                q.time += (Int16)Math.Ceiling(((ArithmeticHelper.QuizPaper)Cache[userID]).stopWatch.Elapsed.TotalSeconds);
            quiz.questionaire[quiz.presentQuestion] = q;
            quiz.stopWatch.Reset();
            quiz.stopWatch.Start();
        }
        catch (SystemException)
        {
            Response.Redirect("Error.aspx");
        }
    }

    protected void dataBindQuestionList()
    {
        questionView.DataSource = null;
        List<questionProperty> questionList = new List<questionProperty>();
        int n = quiz.questionaire.Count;
        for (int i = 0; i < n; i++)
        {
            questionList.Add(new questionProperty(i + 1));
            if (quiz.questionaire[i].markedForReview == true)
                questionList[i].number = questionList[i].number + " * ";
        }
        questionView.DataSource = questionList;
        questionView.DataBind();
        for (int i = 0, j = questionView.PageSize * questionView.PageIndex; i < questionView.PageSize && j < n; i++, j++)
        {
            if (quiz.questionaire[j].correct == 0)
                questionView.Rows[i].ForeColor = System.Drawing.Color.Red;
            else if (quiz.questionaire[j].correct == 1)
                questionView.Rows[i].ForeColor = System.Drawing.Color.Green;
        }

        int k = quiz.presentQuestion - questionView.PageSize * questionView.PageIndex;
        if (0 <= k && k < questionView.PageSize)
            questionView.Rows[k].ForeColor = System.Drawing.Color.Brown;

        if (checkIfMarkedForReview())
            askConfirmation.Value = "true";
        else
            askConfirmation.Value = "false";

        if (quiz.questionsAnswered == quiz.questionaire.Count)
            askCompleteConfirmation.Value = "false";

    }

    protected void questionListPageChange(object sender, GridViewPageEventArgs e)
    {
        questionView.PageIndex = e.NewPageIndex;
        dataBindQuestionList();
    }

    protected void questionSelected(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "selected")
            return;
        quiz = (ArithmeticHelper.QuizPaper)Cache[userID];
        setTime();

        quiz.presentQuestion = Convert.ToInt16(e.CommandArgument) + questionView.PageIndex * questionView.PageSize;

        ArithmeticHelper.Question q = quiz.questionaire[quiz.presentQuestion];
        q.markedForReview = false;
        quiz.questionaire[quiz.presentQuestion] = q;

        if (quiz.presentQuestion == quiz.questionaire.Count - 1)
        {
            next.Enabled = false;
            next0.Enabled = false;
        }
        else
        {
            next0.Enabled = true;
            next.Enabled = true;
        }

        if (quiz.presentQuestion == 0)
        {
            previous0.Enabled = false;
            previous.Enabled = false;
        }
        else
        {
            previous.Enabled = true;
            previous0.Enabled = true;
        }

        setLabels();
        setVisibility();
        Cache[userID] = quiz;
    }

    protected void QuizLinkButton_Click(object sender, EventArgs e)
    {
        MainMultiView.SetActiveView(quizView);
    }

    protected void AnimationLinkButton_Click(object sender, EventArgs e)
    {
        /* if (Request.Cookies["StudentMode"] != null)
          {
              if (Request.Cookies["StudentMode"].Value == "Preview" || Request.Cookies["StudentMode"].Value == "Study")
              {
                  animationLabel.Visible = false;
                  anime.Attributes["src"] = "subscribe.htm";
                  MainMultiView.SetActiveView(animationView);
                  return;
              }
          }
          else
              return;
          */
        if (quizName.Text.Contains("Addition"))
            anime.Attributes["src"] = "Animations/Addition/anime.html";
        else if (quizName.Text.Contains("Subtraction"))
            anime.Attributes["src"] = "Animations/Subtraction/anime.html";
        else if (quizName.Text.Contains("Remainder"))
            anime.Attributes["src"] = "Animations/Division/anime.html";
        else
            anime.Attributes["src"] = "Animations/Multiplication/anime.html";
        MainMultiView.SetActiveView(animationView);
    }

    protected void tutorialLinkButton_Click(object sender, EventArgs e)
    {
        /* if(Request.Cookies["StudentMode"]!=null)
         {
             if (Request.Cookies["StudentMode"].Value == "Preview" || Request.Cookies["StudentMode"].Value == "Study")
             {
                // tutorial.Attributes["FrameBorder"] = "0";
                // tutorial.Attributes["src"] = "subscribe.htm";
                // MainMultiView.SetActiveView(tutorialView);
                 AnimationLinkButton_Click(sender, e);
                 return;
             }
         }
         else
             return;
        
         */
        if (quizName.Text.Contains("Addition"))
            tutorial.Attributes["src"] = "Tutorials/Addition.htm";
        else if (quizName.Text.Contains("Subtraction"))
            tutorial.Attributes["src"] = "Tutorials/Subtraction.htm";
        else if (quizName.Text.Contains("Remainder"))
            tutorial.Attributes["src"] = "Tutorials/Division.htm";
        else
            tutorial.Attributes["src"] = "Tutorials/Multiplication.htm";
        MainMultiView.SetActiveView(tutorialView);

    }

    protected void markForReview_Click(object sender, EventArgs e)
    {
        quiz = (ArithmeticHelper.QuizPaper)Cache[userID];
        try
        {
            ArithmeticHelper.Question q = quiz.questionaire[quiz.presentQuestion];
            q.markedForReview = true;
            quiz.questionaire[quiz.presentQuestion] = q;
            dataBindQuestionList();
            Cache[userID] = quiz;
        }
        catch (SystemException)
        {
            Response.Redirect("Error.aspx");
        }
    }



    protected void VideoLinkButton_Click(object sender, EventArgs e)
    {
        if (quizName.Text.Contains("Addition"))
            video.Attributes["src"] = "Videos/Addition/video.html";
        else if (quizName.Text.Contains("Subtraction"))
            video.Attributes["src"] = "Videos/Subtraction/video.html";
        else if (quizName.Text.Contains("Remainder"))
            video.Attributes["src"] = "Videos/Division/video.html";
        else
            video.Attributes["src"] = "Videos/Multiplication/video.html";
        MainMultiView.SetActiveView(videoView);
    }
}
