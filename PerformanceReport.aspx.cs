using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class PerformanceReport : System.Web.UI.Page
{
    List<benchmarkResult> benchmarkResultsList = new List<benchmarkResult>();
    List<performance> performanceList = new List<performance>();
    SqlConnection connection;
    String userID;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["StudentMode"] != null)
        {
            if ((Request.Cookies["StudentMode"].Value == "Preview" || Request.Cookies["StudentMode"].Value == "Study"))
                Response.Redirect("PreviewReports.aspx");
        }
        else
            Response.Redirect("MainPage.aspx");
        connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString+";MultipleActiveResultSets=True");
        if (Request.Cookies["StudentMode"] != null)
        {
            if (!(Request.Cookies["StudentMode"].Value == "Preview" || Request.Cookies["StudentMode"].Value == "Study"))
            {
                if (Request.Cookies["StudentId"] != null)
                    userID = Request.Cookies["StudentId"].Value;
                else
                    userID = "";
            }
            else
            {
                subscribePerformance.Visible = true;
                subscribeHistory.Visible = true;
                userID = "";
             }
            try
            {
                buildPerformanceAndBenchmarkLists();
                buildPerformanceTable();
                buildHistoryTable();
                buildBenchmarkTable();
            }
            catch (SystemException)
            {
                Response.Redirect("Error.aspx");
            }
        }
        else
            Response.Write("Sorry No Details Available!");
    }
 
    //build the two lists : performance and Benchmark List
    private void buildPerformanceAndBenchmarkLists()
    {
        SqlDataReader quizReader, resultReader1, resultReader2;
        SqlCommand listcommand, command1, command2;
        String query;
        benchmarkResult quizResult;
        performance perform;
        String quizID;

        try
        {
            connection.Open();

            query = @"SELECT quizID, quizType
                      FROM QuizList
                      ORDER BY [order]";

            listcommand = new SqlCommand(query, connection);
            quizReader = listcommand.ExecuteReader();

            while (quizReader.Read())
            {

                quizResult = new benchmarkResult();
                perform = new performance();
                quizResult.quizType = quizReader["quizType"].ToString();
                quizID = quizReader["quizID"].ToString();

                //calculation of benchmark
               // query = String.Format(@"SELECT  AVG(averageTime), SUM(numberOfQuestions) , SUM(correctQuestions)
                    //      FROM            ArithmeticHelperTable
                  //        GROUP BY quizID
                //          HAVING (quizID = '{0}')", quizID);

                query = String.Format(@"SELECT  Round(AVG(averageTime),2), SUM(attemptedQuestions) , SUM(correctQuestions)
                          FROM            ArithmeticHelperTable
                          GROUP BY quizID
                          HAVING (quizID = '{0}')", quizID);
                
                command2 = new SqlCommand(query, connection);
                resultReader2 = command2.ExecuteReader();
                if (resultReader2.HasRows)
                {
                    resultReader2.Read();
                    quizResult.timeBenchmark = (float)Convert.ToDouble(resultReader2[0]);
                    quizResult.numberOfQuestions = (int)resultReader2[1];
                    quizResult.percentageBenchmark = (float)((Convert.ToInt32(resultReader2[2]) * 100) / quizResult.numberOfQuestions);
                }
                if (resultReader2 != null)
                    resultReader2.Close();
                //add to list
                benchmarkResultsList.Add(quizResult);


                //get quiz performance attemptedQuestions
                //query = String.Format(@"SELECT  numberOfQuestions, correctQuestions, percentageCorrect, averageTime
                  //                     FROM   ArithmeticHelperTable
                    //                   WHERE  (userID = '{0}') AND (quizID = '{1}')", userID, quizID);
                query = String.Format(@"SELECT  attemptedQuestions, correctQuestions, percentageCorrect, averageTime
                                       FROM   ArithmeticHelperTable
                                       WHERE  (userID = '{0}') AND (quizID = '{1}')", userID, quizID);
                command1 = new SqlCommand(query, connection);
                resultReader1 = command1.ExecuteReader();
                //for that quiz record his results
                
                if (resultReader1.HasRows)
                {
                    resultReader1.Read();                    
                    perform.quizType = quizResult.quizType;
                    perform.numberOfQuestions = (int)(resultReader1["attemptedQuestions"]);
                    perform.percentage = (float)Convert.ToDouble(resultReader1["percentageCorrect"]);
                    perform.averageTime = (float)Convert.ToDouble(resultReader1["averageTime"]);
                    perform.grade = levels[Convert.ToInt16(Math.Floor(perform.percentage)) / 10];
                    perform.percentageBenchmark = quizResult.percentageBenchmark;
                    perform.timeBenchmark = quizResult.timeBenchmark;
                    performanceList.Add(perform);
                   }
                if (resultReader1 != null)
                    resultReader1.Close();

            }
        }
        finally
        {
            if (connection != null)
                connection.Close();
        }
    }

    //Create Performance table
    private class performance
    {
        public String quizType { get; set; }
        public int numberOfQuestions { get; set; }
        public float percentage { get; set; }
        public float percentageBenchmark { get; set; }
        public String grade { get; set; }
        public float averageTime { get; set; }
        public float timeBenchmark { get; set; }
   
    }
    private String[] levels = new String[] 
            {"Weak","Weak","Weak","Weak","Very Poor","Poor","Satisfactory","Good","Very Good","Excellent","Expert"};
    private System.Drawing.Color[] colors = new System.Drawing.Color[] 
            {Color.Red,Color.Red,Color.Red,Color.Red,Color.Tomato,Color.RoyalBlue,Color.MediumBlue,Color.LightGreen,Color.Green,Color.Goldenrod,Color.DarkGreen};
    private void buildPerformanceTable()
    {
        PerformanceTable.DataSource = performanceList;
        PerformanceTable.DataBind();
        PerformanceTable.Columns[1].ItemStyle.ForeColor = Color.Ivory;
        for (int i = 0,j=PerformanceTable.PageSize*PerformanceTable.PageIndex; i < PerformanceTable.PageSize && j<performanceList.Count;j++, i++)
        {
            PerformanceTable.Rows[i].Cells[1].BackColor = colors[Convert.ToInt16(Math.Floor(performanceList[j].percentage)) / 10];
        }
    }

    //Create Benchmark Table
    private class benchmarkResult
    {
        public String quizType { get; set; }
        public int numberOfQuestions { get; set; }
        public int correctQuestions { get; set; }//
        public float percentage { get; set; }
        public float averageTime { get; set; }
        public float percentageBenchmark { get; set; }
        public float timeBenchmark { get; set; }
    }
    private void buildBenchmarkTable()
    {
        BenchmarkTable.DataSource = benchmarkResultsList;
        BenchmarkTable.DataBind();

    }

    //Create History table
    private class historyResult
    {
        public DateTime time { get; set; }
        public String quizType{ get; set; }
        public int numberOfQuestions{ get; set; }
        public float percentage{ get; set; }
        public float averageTime { get; set; }
    }
    private void buildHistoryTable()
    {
        SqlDataReader reader;
        SqlCommand cmd;
        String query;
        List<historyResult> historyTableList = new List<historyResult>();
        historyResult tableEntry;
        
        try
        {
            connection.Open();

            query = String.Format(@"SELECT        QuizzesTaken.dateTaken, QuizList.quizType, QuizzesTaken.numberOfQuestions, QuizzesTaken.percentageCorrect, QuizzesTaken.averageTime
                      FROM            QuizzesTaken INNER JOIN
                         QuizList ON QuizzesTaken.quizID = QuizList.quizID
                      WHERE        (QuizzesTaken.userID = '{0}')
                      ORDER BY QuizzesTaken.dateTaken DESC",userID);
            cmd = new SqlCommand(query, connection);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tableEntry = new historyResult();
                tableEntry.time = Convert.ToDateTime(reader[0]);
                tableEntry.quizType = (String)reader[1];
                tableEntry.numberOfQuestions = (int)reader[2];
                tableEntry.percentage = (float)Convert.ToDouble(reader[3]);
                tableEntry.averageTime = (float)Convert.ToDouble(reader[4]);
                historyTableList.Add(tableEntry);
            }
            if (reader != null)
                reader.Close();
        }
        finally
        {
            if (connection != null)
                connection.Close();
        }

        HistoryTable.DataSource = historyTableList;
        HistoryTable.DataBind();

    }
   
    protected void ProgressButton_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(PerformanceView);
    }

    protected void HistoryButton_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(HistoryView);
    }

    protected void BenchmarButton_Click(object sender, EventArgs e)
    {
        MultiView1.SetActiveView(BenchmarkView);
    }

    public void pageChanged(object sender, GridViewPageEventArgs e)
    {
        GridView g;
        g = (GridView)sender;
        g.PageIndex = e.NewPageIndex;
        g.DataBind();
        if (g.Equals(PerformanceTable))
            buildPerformanceTable();
    }


}
