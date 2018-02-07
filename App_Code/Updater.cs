using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ArithmeticHelper
{
    public class Updater
    {
        SqlConnection connection;
        QuizEngine quizEngine;
        QuizPaper quizPaper;
        String selectQuestions;
        List<String> questionID;


        public Updater(String connectionString)
        {
            //connection = new SqlConnection(//Connection String
          //  @"Data Source=.\SQLEXPRESS;AttachDbFilename='C:\Users\Maruti\Documents\Visual Studio 2008\Projects\ArithmeticHelper\ArithmeticHelper\Database.mdf';Integrated Security=True;User Instance=True");
            // Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;User Instance=True
           
            connection = new SqlConnection(connectionString);
           
            quizEngine = new QuizEngine();
           
         }

        public void populateQuizWithQuestionIDS(String quizID)
        {
           String insertQuestionIDS;
            try
            {
                connection.Open();
                for (int order = 1; order <= 10; order++)
                {
                    insertQuestionIDS = @"INSERT INTO QuizQuestions (QOrder, QuizID) " +
                                         @"VALUES (" + @order + @",'" + @quizID + @"')";

                    SqlCommand cmd = new SqlCommand(insertQuestionIDS, connection);

                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }

        public void updateQuiz(String quizID)
        {
            String answer,questionid,questionText;
            Question question;
            List<String> option;
            
            quizPaper = quizEngine.generateQuizPaper(@quizID,1);
            
            selectQuestions = @"SELECT QuestionID FROM QuizQuestions WHERE (QuizID = '"+ @quizID +@"') ORDER BY QOrder";
            questionID = readQuestionID();

            for (int i = 0; i < questionID.Count; i++ )
            {
                questionid = questionID.ElementAt(i);
                question = quizPaper.questionaire.ElementAt(i);
                answer = question.answer;
                option = question.options;
                questionText = question.question;

                updateQuestionText(questionid, questionText);
                updateAnswer(questionid , answer);
                updateOptions(questionid, option);
            }
        }
        
        private List<String> readQuestionID()
        {
            SqlDataReader reader = null;
            List<String> questionID = new List<string>();
            SqlCommand command;
            try
            {
                connection.Open();
                command = new SqlCommand(selectQuestions, connection);

                reader = command.ExecuteReader();

                while (reader.Read())
                    questionID.Add(reader[0].ToString());
            }
            finally
            {
         
                if (reader != null)
                {
                    reader.Close();
                }

                if (connection != null)
                {
                    connection.Close();
                }
            }

            return questionID;
        }

        private void updateQuestionText(String questionid, String questionText)
        {
            String updateQuestionText;
            try
            {
                connection.Open();

                //to Insert data entries into question tale from quizquestions
             //   updateQuestionText = @"INSERT INTO Questions(QuestionID)SELECT QuestionID FROM QuizQuestions"
              //    + @" WHERE (QuestionID = '" + @questionid + @"' )" ;
               
               updateQuestionText = @"UPDATE Questions SET QuestionText = '"+ @questionText 
                  +@"' WHERE(QuestionID = '"+ @questionid +@"') ";

                SqlCommand cmd = new SqlCommand(updateQuestionText, connection);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void updateAnswer(String questionid , String answer)
        {
            String updateAnswers;
            try
            {
                connection.Open();

                //to insert questionids
             //  updateAnswers = @"INSERT INTO QuestionAnswers(QuestionID) SELECT QuestionID FROM QuizQuestions"
             //   + @" WHERE (QuestionID = '" + @questionid + @"' )";

                   updateAnswers = @"UPDATE QuestionAnswers
                           SET  Answer = '" + @answer +
                      @"' WHERE (QuestionID = '" + @questionid +@"')";
                
                SqlCommand cmd = new SqlCommand(updateAnswers,connection);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void updateOptions(String questionid, List<String> options)
        {
            String updateOption;
            String option;
            int order;

            for (int i = 0; i <options.Count; i++)
            {
                option = options.ElementAt(i);
                order=i+1;
                try
                {
                    connection.Open();
                    
                    //to insert
                //   updateOption = @"INSERT INTO QuestionOptions (QuestionID,[Order]) VALUES ('" 
                //       + @questionid +@"' , '" + @order + @"')";

                  updateOption =  @"UPDATE QuestionOptions SET OptionText = '" 
                        + @option +@"' WHERE (QuestionID = '"+ @questionid +@"') AND ([Order] = '"+ @order +@"') ";

                    SqlCommand cmd = new SqlCommand(updateOption, connection);

                    cmd.ExecuteNonQuery();

                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Close();
                    }
                }
            }
            
        }

        
    }
}
