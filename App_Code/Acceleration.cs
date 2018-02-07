using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace ArithmeticHelper
{
     class Acceleration : Quiz
    {
        protected int MaxCount, Start_Speed, End_Speed, Time_Taken, Distance_Traveled, Travel_Acceleration;
        protected int Answer, QnsNo;
        protected XmlDocument objDoc;
        protected XmlNode ObjXml;
        protected XmlNode nd;

        protected XmlNodeList lst;
        public Acceleration()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {

            string s;

            s = createQns(); //questionPrototype.ElementAt(QnsNo);
            StringBuilder question = new StringBuilder(s);

            Travel_Acceleration = generateTravel_Acceleration();
            Time_Taken = generateTime_Taken();
            Start_Speed = generateStart_Speed();
            End_Speed = CalculateEnd_Speed();
            Distance_Traveled = CalculateDistance_Traveled();

            question.Replace("Start_Speed", Start_Speed.ToString());
            question.Replace("End_Speed", End_Speed.ToString());
            question.Replace("Travel_Acceleration", Travel_Acceleration.ToString());
            question.Replace("Time_Taken", Time_Taken.ToString());
            question.Replace("Distance_Traveled", Distance_Traveled.ToString());

            return question.ToString();
        }

        protected string createQns()
        {

            MaxCount = objDoc.SelectNodes("Questions//Acceleration//Qns").Count;
            QnsNo = randomDigit(0, MaxCount);
            lst = objDoc.SelectNodes("Questions//Acceleration//Qns");

            int ObjCount, QnsCount;
            //int QusNo = randomDigit(0, Max);
            string s, strObject1;


            nd = lst.Item(QnsNo);

            s = nd.Attributes["Question"].Value;

            QnsCount = nd.ChildNodes.Count -2;

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





        protected int generateStart_Speed()
        {
            int Number1;
            Number1 = randomDigit(0, 6) * 5;
            return Number1;
        }

        protected int generateTravel_Acceleration()
        {
            int Number1;
            Number1 = randomDigit(1, 4) * 5;
            return Number1;
        }
        protected int generateTime_Taken()
        {
            return randomDigit(1, 6) * 2;
        }
        protected int CalculateTraveled_Speed()
        {
            return Travel_Acceleration * Time_Taken;
        }
        protected int CalculateEnd_Speed()
        {
            return Start_Speed + (Travel_Acceleration * Time_Taken);
        }



        protected int CalculateDistance_Traveled()
        {
            return Start_Speed * Time_Taken + (Travel_Acceleration * Time_Taken * Time_Taken) / 2;

        }



        protected override string createAnswer()
        {

            switch (nd.SelectSingleNode("Answer").InnerText)
            {
                case "End_Speed":
                    Answer = End_Speed;
                    break;
                case "Start_Speed":
                    Answer = Start_Speed;
                    break;
                case "Time_Taken":
                    Answer = Time_Taken;
                    break;
                case "Travel_Acceleration":
                    Answer = Travel_Acceleration;
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
            s.Replace("Start_Speed", Start_Speed.ToString());
            s.Replace("End_Speed", End_Speed.ToString());
            s.Replace("Travel_Acceleration", Travel_Acceleration.ToString());
            s.Replace("Time_Taken", Time_Taken.ToString());
            s.Replace("Distance_Traveled", Distance_Traveled.ToString());
            return s.ToString();


            //StringBuilder s = new StringBuilder(4000);
            //s.AppendFormat("<b>Detailed Solution:</b><br>");

            //s.AppendFormat("<br> Sales Amount:${0}", Sales_Amt);
            //s.AppendFormat("<br> Commission Percent:{0}%", Commission_Percent);
            //s.AppendFormat("<br><br><b>Step 1: Form problem statement:</b>");
            //s.AppendFormat("<br> What is {0}% of {1}?", Commission_Percent, Sales_Amt);
            //s.AppendFormat("<br> So x = ({0}%) ({1})", Commission_Percent, Sales_Amt);
            //s.AppendFormat("<br><br><b>Step 2: Calculate x:</b>");
            //s.AppendFormat("<br> x = ({0}/100) ({1}) = {2}", Commission_Percent, Sales_Amt, Answer);


            //s.AppendFormat("<br><br><b> Answer :</b>");
            //s.AppendFormat("${0}", Answer);

            //return s.ToString();

        }

    }


}
