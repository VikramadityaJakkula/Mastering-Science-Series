using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace ArithmeticHelper
{
     class Force : Quiz
    {
        protected int MaxCount, Travel_Acceleration, Object_Mass, Force_Applied;
        protected int Answer, QnsNo;
        protected XmlDocument objDoc;
        protected XmlNode ObjXml;
        protected XmlNode nd;

        protected XmlNodeList lst;
        public Force()
        {
            createQuestionPrototype();
        }
        protected override String createQuestion()
        {

            string s;

            s = createQns(); //questionPrototype.ElementAt(QnsNo);
            StringBuilder question = new StringBuilder(s);

            Travel_Acceleration =  generateTravel_Acceleration();
                Object_Mass = generateMass();
Force_Applied = CalculateForce();
            

            question.Replace("Travel_Acceleration", Travel_Acceleration.ToString());
            question.Replace("Object_Mass", Object_Mass.ToString());
            question.Replace("Force_Applied", Force_Applied.ToString());
           
            return question.ToString();
        }

        protected string createQns()
        {

            MaxCount = objDoc.SelectNodes("Questions//Force//Qns").Count;
            QnsNo = randomDigit(0, MaxCount);
            lst = objDoc.SelectNodes("Questions//Force//Qns");

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
        protected int generateMass()
        {
            int Number1;
            Number1 = randomDigit(0, 11);
            return Number1;
        }

        protected int generateTravel_Acceleration()
        {
            int Number1;
            Number1 = randomDigit(1, 4) * 5;
            return Number1;
        }
   
        protected int CalculateForce()
        {
            return Travel_Acceleration * Object_Mass;
        }
  
        protected override string createAnswer()
        {

            switch (nd.SelectSingleNode("Answer").InnerText)
            {
                case "Travel_Acceleration":
                    Answer = Travel_Acceleration;
                    break;
                case "Object_Mass":
                    Answer = Object_Mass;
                    break;
                case "Force_Applied":
                    Answer = Force_Applied;
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
            s.Replace("Travel_Acceleration", Travel_Acceleration.ToString());
            s.Replace("Object_Mass", Object_Mass.ToString());
            s.Replace("Force_Applied", Force_Applied.ToString());
         
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
