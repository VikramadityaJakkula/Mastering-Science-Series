using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PreviewQuizzes : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (PreviousPage != null && PreviousPage.GetType().BaseType.FullName=="MainPage")
        {
            subscribe.Text = " Quiz on <span style=\"color:Green\">" + ((MainPage)PreviousPage).quizType + 
                "</span> is available only for Subscribed Users";
            subscribe.Visible = true;
            Label1.Visible = true;
        }
        if (Request.Cookies["StudentMode"] == null)
                  Response.Cookies["StudentMode"].Value = "Preview";
  
        if (Request.Cookies["StudentMode"] == null)
                       Response.Redirect("EnableCookie.aspx");

        
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (Request.Cookies["StudentMode"] != null)
                  Response.Redirect("ConfigureQuiz.aspx?q="+System.Guid.NewGuid()+"&QuizId="+ QuizMenu.SelectedNode.Value, true);
        else
            Response.Redirect("EnableCookie.aspx");

    }

    protected void dummyButton_Click(object sender, EventArgs e)
    {
        System.Windows.Forms.MessageBox.Show("HI");
        
        Page.ClientScript.RegisterStartupScript(this.GetType(), "clickButton", "clickButton()", true);
    }
}
