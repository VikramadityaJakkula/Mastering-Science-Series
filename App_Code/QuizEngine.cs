using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ArithmeticHelper
{
    
    public class QuizEngine
    {
        Quiz quiz;
        QuizIdentifier quizIdentifier;

        public QuizEngine()
        {
            quizIdentifier = new QuizIdentifier();
            quiz = null;
        }

        public QuizPaper generateQuizPaper(String quizID,int numberOfQuestions)
        {
            quiz = quizIdentifier.identifiedQuiz(@quizID);
            quiz.setNumberOfQuestions(numberOfQuestions);
            quiz.setQuizID(@quizID);
            quiz.prepareQuizPaper();
            return quiz.getQuizPaper();
        }

        enum QuizID
         {
             AdditionSingleDigit = 101,
             AdditionDoubleDigitWithoutCarry,
             AdditionDoubleDigitWithCarry,
             AdditionThreeDigitWithoutCarry,
             AdditionThreeDigitWithCarry,

             SubtractionSingleDigit = 201,
             SubtractionDoubleDigitWithoutBorrow ,
             SubtractionDoubleDigitWithBorrow ,
             SubtractionTripleDigitWithoutBorrow ,
             SubtractionTripleDigitWithBorrow ,

             MultiplicationSingleDigit = 301,
             MultiplictaionDoubleDigitTimesSingleDigit ,
             MultiplicationDoubleDigit,
             MultiplicationTripleDigit,

             DivisionOneDigitWithOneDigitNoRemainder = 401,
             DivisionOneDigitWithOneDigitWithRemainder ,
             DivisionOneDigitWithTwoDigitNoRemainder,
             DivisionOneDigitWithTwoDigitWithRemainder,
             DivisionOneDigitWithThreeDigitNoRemainder,
             DivisionOneDigitWithThreeDigitWithRemainder,
             DivisionTwoDigitWithTwoDigitNoRemainder,
             DivisionTwoDigitWithTwoDigitWithRemainder,
             DivisionTwoDigitWithThreeDigitNoRemainder,
             DivisiontwoDigitWithThreeDigitWithRemainder,
         }


    }
    
}
