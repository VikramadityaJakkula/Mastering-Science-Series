using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace ArithmeticHelper
{
     class Velocity : Quiz
    {
        protected int MaxCount, Travel_Speed, Time_Taken, Distance_Traveled, Dist_Loc1, Dist_Loc2;
        protected int Answer, QnsNo;
        //   protected string AnswerFormat;
       // abstract protected int generateTravel_Speed();
        //abstract protected int generateTime_Taken();
        //abstract protected int generateDist_Loc1();
        //abstract protected int CalculateDistance_Traveled();
        //abstract protected int CalculateDist_Loc2();
        protected XmlDocument objDoc;
        protected XmlNode ObjXml;
        protected XmlNode nd;

        protected XmlNodeList lst;
        public Velocity()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {

            string s;

            s = createQns(); //questionPrototype.ElementAt(QnsNo);
            StringBuilder question = new StringBuilder(s);

            Travel_Speed = generateTravel_Speed();
            Time_Taken = generateTime_Taken();
            Distance_Traveled = CalculateDistance_Traveled();
            Dist_Loc1 = generateDist_Loc1();
            Dist_Loc2 = CalculateDist_Loc2();

            question.Replace("Travel_Speed", Travel_Speed.ToString());
            question.Replace("Dist_Loc1", Dist_Loc1.ToString());
            question.Replace("Dist_Loc2", Dist_Loc2.ToString());
            question.Replace("Time_Taken", Time_Taken.ToString());
            question.Replace("Distance_Traveled", Distance_Traveled.ToString());

            return question.ToString();
        }

        protected string createQns()
        {

            MaxCount = objDoc.SelectNodes("Questions//Velocity//Qns").Count;
            QnsNo = randomDigit(0, MaxCount);
            lst = objDoc.SelectNodes("Questions//Velocity//Qns");

            int ObjCount, QnsCount;
            //int QusNo = randomDigit(0, Max);
            string s, strObject1;


            nd = lst.Item(QnsNo);

            s = nd.Attributes["Question"].Value;

            QnsCount = nd.ChildNodes.Count-2;

            for (int i = 0; i < QnsCount; i++)
            {

                ObjXml = nd.ChildNodes[i];
                ObjCount = randomDigit(0, ObjXml.ChildNodes.Count);
                strObject1 = ObjXml.ChildNodes[ObjCount].InnerXml;
                s = s.Replace("Object" + (i + 1).ToString(), strObject1);

            }

            return s;
        }
        protected override void createQuestionPrototype()
        {
            objDoc = new XmlDocument();
            objDoc.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QuestionPrototype.xml"));



            //questionPrototype.Add("<b> Evaluate :<br>&nbsp;A car's meter reads Dist_Loc1km at the start of a trip and Dist_Loc2km at the end. The trip took Time_Takenh. Calculate Travel_Speed?</b>");
        }




        protected  int generateTravel_Speed()
        {
            int Number1;
            Number1 = randomDigit(1, 12) * 10;
            return Number1;
        }
        protected  int generateTime_Taken()
        {
            return randomDigit(1, 6);
        }
        protected  int CalculateDistance_Traveled()
        {
            return Travel_Speed * Time_Taken;
        }
        protected  int generateDist_Loc1()
        {
            return 2000 + randomDigit(10, 100);
        }
        protected  int CalculateDist_Loc2()
        {
            return Dist_Loc1 + Distance_Traveled;
        }

        protected override  string createAnswer()
        {

            switch (nd.SelectSingleNode("Answer").InnerText)
            {
                case "Travel_Speed":
                    Answer = Travel_Speed;
                    break;
                case "Dist_Loc1":
                    Answer = Dist_Loc1;
                    break;
                case "Dist_Loc2":
                    Answer = Dist_Loc2;
                    break;
                case "Time_Taken":
                    Answer = Time_Taken;
                    break;
                case "Distance_Traveled":
                    Answer = Distance_Traveled;
                    break;
            }
            return Answer.ToString();
        }

        protected override List<String> createOptions()
        {
            List<String> options = new List<String>();
            int type1, type2;
            string[] temp = new string[2];
            temp = Answer.ToString().Split('.');
            int count = temp[0].Length - 1;
            int Num = 1;
            for (int i = count; i > 0; i--)
                Num = Num * 10;

            type1 = (randomDigit(1, 3) == 1) ? 1 : -1;
            type2 = (randomDigit(1, 3) == 1) ? 2 : -2;
            type1 = type1 * Num;
            type2 = type2 * Num;

            type2 = (Answer + type2) > 1 ? type2 : -type2;

            options.Add(Answer.ToString());
            options.Add((Answer + type1).ToString());
            options.Add((Answer + type2).ToString());
            options.Add((Answer + type2 + type1).ToString());
            return options;
        }

        protected override String createSolution()
        {

            return buildSolution();

        }

        protected String buildSolution()
        {
            StringBuilder s = new StringBuilder(4000);
            s.AppendFormat(nd.SelectSingleNode("Soln").InnerText);
            s.Replace("Travel_Speed", Travel_Speed.ToString());
            s.Replace("Dist_Loc1", Dist_Loc1.ToString());
            s.Replace("Dist_Loc2", Dist_Loc2.ToString());
            s.Replace("Time_Taken", Time_Taken.ToString());
            s.Replace("Distance_Traveled", Distance_Traveled.ToString());



            return s.ToString();






        }

    }


}
