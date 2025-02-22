using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam
{
    
    internal class Question
    {
        
        #region Feilds
        string? body;
        int mark;
        Answer? answer;
        string[]? choices; 
        #endregion

        #region Properties
        public int Mark 
        { 
            set { mark = value; } 
            get { return mark;  } 
        }
        public Answer Answer 
        {
            get { return answer; } 
            set {  answer = value; }
        }
        public string[] Choices
        {
            get { return choices; }
            set {  choices = value; } 
        }
        #endregion
      
        #region Override Method

        public override string ToString() => $" {body}";

        #endregion

        #region Helper Methods
        void QuestionBody_MarkInput(int QuestionNumber, out string body, out int mark)
        {
            HelperMethods.CheckInputNull($"Please Enter the body of the Question{QuestionNumber}", out body);

            HelperMethods.CheckPositiveInput($"Please Enter the Marks of Question {QuestionNumber} : ", out mark);
        }
        void Mcq(int QuestionNumber, out string body, out int mark, out Answer answer, out string[] choices)
        {
            Console.WriteLine("MCQ Question");

            QuestionBody_MarkInput(QuestionNumber, out body, out mark);

            choices = new string[4];
            for (int ch = 0; ch < 4; ++ch)
            {
                HelperMethods.CheckInputNull($"Please Enter the Choice {ch + 1} : ", out choices[ch]);
            }

            HelperMethods.CheckPositiveInput($"Please Enter the Answer of Question {QuestionNumber} : ", out int answerId, 4);

            answer = new Answer(answerId, choices[answerId - 1]);
        }
        void TrueFalse(int QuestionNumber, out string body, out int mark, out Answer answer, out string[] choices)
        {
            Console.WriteLine("TrueFalse Questions");
            QuestionBody_MarkInput(QuestionNumber, out body, out mark);

            HelperMethods.CheckPositiveInput($"Please Enter the Answer of Question {QuestionNumber} [1 For True \t 2 For False] : ", out int answerId, 2);

            answer = new Answer(answerId, answerId == 1 ? "True" : "False");
            choices = ["True", "False"];
        }

        #endregion
        public void InputQuestion (int QuestionNumber , bool Final = true )
        {
            int typeQ = 1; 
            
            if ( Final )
                HelperMethods.CheckPositiveInput($"Please Enter Type Of the Question {QuestionNumber}\n1 for MCQ\n2 for True or False", out typeQ, 2);

            if (typeQ == 1)
                Mcq(QuestionNumber, out body, out mark, out answer, out choices);

            else
                TrueFalse(QuestionNumber, out body, out mark, out answer, out choices);
        }

       
        

    }



}
