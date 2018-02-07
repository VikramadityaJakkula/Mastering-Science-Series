using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ArithmeticHelper
{
    public class QuizIdentifier
    {
        Hashtable quizIDTable;
        Quiz quiz;

        public QuizIdentifier()
        {
            quizIDTable = new Hashtable();
            populateHashTable();
        }

        public Quiz identifiedQuiz(String quizID)
        {
            int quizNumber = (int)quizIDTable[@quizID];
            identifyQuiz(quizNumber);
            return quiz;
        }

        void identifyQuiz(int quizID)
        {
            if (quizID / 100 == 1)
                identifyPhysicsFunction(quizID);
        }
        void identifyPhysicsFunction(int quizID)
        {
            if (quizID % 100 == 1)
                setQuiz((Quiz)new Velocity());
            if (quizID % 100 == 2)
                setQuiz((Quiz)new Acceleration());
            if (quizID % 100 == 3)
                setQuiz((Quiz)new Gravity());
            if (quizID % 100 == 4)
                setQuiz((Quiz)new Force());

        }




        void setQuiz(Quiz quiz)
        {
            this.quiz = quiz;
        }


        private void populateHashTable()
        {
            //physics problems
            quizIDTable.Add(@"F808776C-D798-4948-AD15-65A5DA5B4679", 101);
            quizIDTable.Add(@"11DFFFDA-581E-4917-AB4B-AD1686FAB065", 102);
            quizIDTable.Add(@"490EA2BE-2D24-422e-85E2-FF68CAC89519", 103);
            quizIDTable.Add(@"55B1ED06-8BF1-4ec2-8B2C-C5BFE6090EB5", 104);




        }

    }
}
