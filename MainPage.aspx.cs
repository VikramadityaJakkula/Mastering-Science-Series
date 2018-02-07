using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class MainPage : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
        {
        if (Request.Cookies["StudentMode"] == null)
            Response.Cookies["StudentMode"].Value = "Preview";

        if (Request.Cookies["StudentMode"] != null)
        {
            if (Request.Cookies["StudentMode"].Value == "Preview" || Request.Cookies["StudentMode"].Value == "Study")
                previewLink.Visible = true;
        }
        else
            Response.Redirect("EnableCookie.aspx");

    }

    private String quizTypeProperty;

    public string quizType
    {
        set
        {
            quizTypeProperty = value;
        }
        get
        {
            return quizTypeProperty;
        }
    }


    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        String quizID;
        if (Request.Cookies["StudentMode"] != null)
        {
            quizType = QuizMenu.SelectedNode.Text;
            quizID = QuizMenu.SelectedNode.Value;

            if (quizID =="F808776C-D798-4948-AD15-65A5DA5B4679" || quizID=="11DFFFDA-581E-4917-AB4B-AD1686FAB065" || quizID=="490EA2BE-2D24-422e-85E2-FF68CAC89519"
                || quizID=="55B1ED06-8BF1-4ec2-8B2C-C5BFE6090EB5")
                  Response.Redirect("ConfigureQuiz.aspx?q=" + System.Guid.NewGuid() + "&QuizId=" + quizID, true);

                //quizID =="80826568-BAAD-4327-B79E-49068F05DAD3" || quizID=="BB6B6730-CA4F-4f43-BE12-6FC9BD0402A7" || quizID=="AE88C8DC-74AB-42c4-B591-05274860F50D" || quizID=="C623FE9F-4D6B-471b-8029-8D2D497D188B" ||
                
                //quizID == "9371C7DB-A24B-4be1-9FEE-6B7A85DB400B" || quizID == "F7AB6F95-69D3-4611-BED8-362857A3A65C" || quizID == "768022B5-9141-4574-9EB1-72D185F0FAF6"
                //|| quizID == "832A7AEC-5E92-42d7-BC76-CCFAE786D9A5" || quizID == "86E245E0-C54E-4ada-AF27-B9044ADC08F2" || quizID == "781F7BEE-DA32-4555-9F26-1C618E31E3EA"
                //|| quizID == "0134BBB6-EA9E-4556-8313-987B84C03F70" || quizID == "CB6BD55A-C356-4ff7-AB5E-10D471A64492" || quizID == "0EB2C22A-DDF4-4565-B97D-293795C31655")


            //if (quizID == "76F8CD7A-4BF6-49b6-A440-1C2D87CA2DCE" || quizID == "573ACD8A-F063-4119-8DB5-08E5D7B7F095" || quizID == "4268C829-71F0-4541-BECC-0788904230B8" ||
            //    quizID == "C44C06C6-A9F9-473b-9523-A4CFBEDD0AC7" || quizID == "26C7E609-D0A5-4912-9858-4706DF85AEAB" || quizID == "C85C4AA1-E053-4541-AC41-CDBF9F03EEB4" ||
            //    quizID == "781F7BEE-DA32-4555-9F26-1C618E31E3EA" || quizID == "6C514174-186D-42b0-9836-7F4A685B5983" || quizID == "5D1D8CE1-3DD5-4354-900C-4D69202EBF1A" ||
            //    quizID == "0EB2C22A-DDF4-4565-B97D-293795C31655" || quizID == "CB6BD55A-C356-4ff7-AB5E-10D471A64492" || quizID == "0134BBB6-EA9E-4556-8313-987B84C03F70" ||
            //    quizID == "75DD4361-B58B-4cc9-8572-00E0F7809F78" || quizID == "9371C7DB-A24B-4be1-9FEE-6B7A85DB400B" || quizID == "FF6D685A-ECE6-4c0c-A946-A22F3323ACAD" || quizID == "8629C229-097B-450e-B152-B6FBCD580C6A" ||
            //    quizID == "F7AB6F95-69D3-4611-BED8-362857A3A65C" || quizID == "C850925C-A661-4990-93F3-2365988C8DFC" || quizID == "BA16694F-3034-49b2-B339-DB32AC84B674" ||
            //    quizID == "768022B5-9141-4574-9EB1-72D185F0FAF6" || quizID == "14E4FDF1-D8C9-4a95-A3E0-F856A2958330" || quizID == "E53B688A-37B4-4fa1-92C1-92BA6E80304F" ||
            //    quizID == "832A7AEC-5E92-42d7-BC76-CCFAE786D9A5" || quizID == "F4FC1BB7-6CFC-439a-9B8A-261251124622" || quizID == "CFA6B36D-95F3-4641-BFC7-D1C5C50068BC" ||
            //    quizID == "5968EB4B-C486-435e-B3A2-DEE504E6EFC9" || quizID == "E9AE0DB9-AD58-43e2-AFCD-7E407A549A75" ||
            //    quizID == "66DD0945-258B-4016-B341-779496328F6D" || quizID == "86E245E0-C54E-4ada-AF27-B9044ADC08F2" || quizID == "498B1CD1-6F5B-4766-A08E-56EC007B8FF5" || quizID == "3F691386-6107-4166-B5CF-F48532F1A6C7"
            //    || quizID == "5cb3961b-511e-4262-90c0-478824a44a31" || quizID == "b45bddfb-944f-46ff-b98b-213298a5677e"
            //    || quizID == "b8708d2c-935d-48e3-861d-0a664db56b1c" || quizID == "62ac9f7a-fa94-4b2a-b249-f2c6377d4ee7")
          
            if (Request.Cookies["StudentMode"].Value == "Preview" || Request.Cookies["StudentMode"].Value == "Study")
                Server.Transfer("PreviewQuizzes.aspx");
            else
                Response.Redirect("ConfigureQuiz.aspx?q=" + System.Guid.NewGuid() + "&QuizId=" + quizID, true);

        }
        else
            Response.Redirect("EnableCookie.aspx");

    }
}
