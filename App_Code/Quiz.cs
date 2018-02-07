using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace ArithmeticHelper
{

    public abstract class Quiz
    {
        // protected int number_1, number_2;
        protected int numberOfQuestions;
        protected QuizPaper quizPaper;
        protected Random r;
        protected List<String> questionPrototype;

        abstract protected List<String> createOptions();
        abstract protected String createAnswer();
        abstract protected void createQuestionPrototype();
        //abstract protected int generateNumber_1();
        //abstract protected int generateNumber_2(int number_1);
        abstract protected String createSolution();
        abstract protected String createQuestion();


        //protected String createQuestion(int number_1, int number_2)
        //{
        //    String s = questionPrototype.ElementAt(0);
        //    StringBuilder question = new StringBuilder(s);
        //    question.Replace("number_1", number_1.ToString());
        //    question.Replace("number_2", number_2.ToString());
        //    return question.ToString();
        //}

        protected int randomDigit(int min, int max)
        {
            int p = 10000000;
            return r.Next(min * p, max * p) / p;
        }

        protected void prepareQuestions()
        {

            ArrayList Questions = new ArrayList();

            string Qns;
            while (quizPaper.questionaire.Count < numberOfQuestions)
            {
                Question q = new Question();

                Qns = createQuestion();
                if (!(Questions.Contains(Qns)))
                 {
                q.question = Qns;
                q.answer = createAnswer();
                q.options = createOptions();
                q.shuffleOptions(r);
                q.solution = createSolution();
                q.assignDefaults();
                quizPaper.questionaire.Add(q);
                Questions.Add(Qns);
              }



            }
            Console.Write("\n");
        }

        public Quiz()
        {
            quizPaper = new QuizPaper();
            numberOfQuestions = 1;

            r = new Random();
            questionPrototype = new List<String>();
        }

        public void prepareQuizPaper()
        {
            this.prepareQuestions();
        }

        public QuizPaper getQuizPaper()
        {
            return quizPaper;
        }

        public void setNumberOfQuestions(int n)
        {
            numberOfQuestions = n;
        }

        public void setQuizID(String id)
        {
            quizPaper.quizID = id;
        }
    }

    [Serializable]
    public class QuizPaper
    {
        public List<Question> questionaire;
        public int marks;
        public int presentQuestion;
        public String quizID;
        public System.Diagnostics.Stopwatch stopWatch;
        public int questionsAnswered;

        public QuizPaper()
        {
            questionsAnswered = 0;
            questionaire = new List<Question>();
            marks = 0;
            presentQuestion = 0;
            stopWatch = new System.Diagnostics.Stopwatch();
        }
    }

    [Serializable]
    public struct Question
    {
        public String question;
        public String answer;
        public List<String> options;
        public String solution;
        public int selectedOption;
        public bool markedForReview;
        public int time;
        public int correct;

        public void shuffleOptions(Random r)
        {
            List<String> randomList = new List<String>();
            int randomIndex = 0;
            while (options.Count > 0)
            {
                randomIndex = r.Next(0, options.Count); //Choose a random object in the list
                randomList.Add(options[randomIndex]); //add it to the new, random list<
                options.RemoveAt(randomIndex); //remove to avoid duplicates
            }
            options = randomList;

        }

        public void assignDefaults()
        {
            correct = 2;
            markedForReview = false;
            selectedOption = -1;
            time = 0;

        }

        public void setSelectedOption(int o)
        {
            selectedOption = o;
        }
    }

    public struct Evaluator
    {
        public int numberOfQuestions;
        public int correctAnswers;
        public int attemptedQuestions;
        private QuizPaper quiz;
        public float percentageCorrect;
        public String quizID;
        public float averageTime;
        public String userID;

        public Evaluator(QuizPaper q)
        {
            this.quiz = q;
            numberOfQuestions = 0;
            correctAnswers = 0;
            attemptedQuestions = 0;
            percentageCorrect = 0;
            quizID = null;
            averageTime = 0;
            userID = null;
            evaluateQuiz();

        }

        private void evaluateQuiz()
        {
            quizID = quiz.quizID;
            foreach (Question q in quiz.questionaire)
            {
                if (q.correct != 2)
                {
                    if (q.correct == 1)
                        correctAnswers++;
                    attemptedQuestions++;
                }
                averageTime += q.time;
            }
            percentageCorrect = (float)(100.0 * correctAnswers) / quiz.questionaire.Count;
            numberOfQuestions = quiz.questionaire.Count;
            if (attemptedQuestions != 0)
                averageTime = (Int16)averageTime / attemptedQuestions;

        }
    }
}
