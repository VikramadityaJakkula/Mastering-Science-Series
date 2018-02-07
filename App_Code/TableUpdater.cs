using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ArithmeticHelper
{
    public class TableUpdater
    {
        SqlConnection connection;
        Evaluator ev;
        SqlDataReader reader = null;

        public TableUpdater(Evaluator e)
        {
            ev = e;
            connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }

        public void insertResult()
        {
            String query=null;
           
            SqlCommand cmd=null;
            
            try
            {
                if (connection != null)
                {
                    connection.Open();

                    //insert result in individual quiz table
                    if(ev.userID!=System.Configuration.ConfigurationManager.AppSettings["AnonymousUser"])
                        insertResultInQuizzesTaken();

                    //updates main table
                    query = String.Format(@"SELECT  numberOfQuestions, correctQuestions, percentageCorrect, averageTime, attemptedQuestions
                              FROM            ArithmeticHelperTable
                              WHERE        (userID = '{0}') AND (quizID = '{1}')", ev.userID, ev.quizID);

                    cmd = new SqlCommand(query, connection);
                    reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        reader.Close();
                        insertNewResultInMainTable();
                    }
                    else
                    {
                        updateResultInMainTable();
                    }
                }
            }
            finally
            {
                if ( reader != null)
                {
                    reader.Close();
                }
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void insertResultInQuizzesTaken()
        {
            String query;
            SqlCommand cmd;
            query = String.Format(@"INSERT INTO QuizzesTaken
                         (userID, quizID, numberOfQuestions, correctQuestions, percentageCorrect, averageTime, attemptedQuestions, dateTaken)
                          VALUES ('{0}','{1}',{2},{3},{4},{5},{6},'{7}')", ev.userID, ev.quizID, ev.numberOfQuestions, ev.correctAnswers,
                                                                     ev.percentageCorrect, ev.averageTime, ev.attemptedQuestions, DateTime.Now);
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();

        }

        private void insertNewResultInMainTable()
        {
            String query;
            SqlCommand cmd;

            query = String.Format(@"INSERT INTO ArithmeticHelperTable
                         (userID, quizID, numberOfQuestions, correctQuestions, percentageCorrect, averageTime, attemptedQuestions)
                      VALUES ('{0}','{1}',{2},{3},{4},{5},{6})", ev.userID, ev.quizID, ev.numberOfQuestions,
                        ev.correctAnswers, ev.percentageCorrect, ev.averageTime,ev.attemptedQuestions);

            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }

        private void updateResultInMainTable()
        {
            String query;
            SqlCommand cmd;

            reader.Read();
            ev.numberOfQuestions += (int)reader[0];
            ev.correctAnswers += (int)reader[1];
            ev.percentageCorrect = (float)(ev.correctAnswers*100)/ev.numberOfQuestions;
            ev.averageTime = (float)(ev.averageTime * ev.attemptedQuestions + (int)reader[4]* Convert.ToDouble(reader[3])) / (float)(ev.attemptedQuestions + (int)reader[4]);
            ev.attemptedQuestions += (int)reader[4];

            query = String.Format(@"UPDATE       ArithmeticHelperTable
                       SET numberOfQuestions = {2}, correctQuestions = {3}, percentageCorrect = {4} , averageTime = {5} , attemptedQuestions = {6}
                       WHERE (userID = '{0}') AND (quizID = '{1}')",ev.userID,ev.quizID,ev.numberOfQuestions,ev.correctAnswers,
                                                                   ev.percentageCorrect,ev.averageTime,ev.attemptedQuestions);
            reader.Close();
            cmd = new SqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
    }
}
