using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam
{
    abstract class Exam
    {
        #region Properties
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }

        public List<Question> Questions; 
        protected int TotalMarks { get; set; } = 0; 
        protected int Grade {  get; set; }
        #endregion
        
        #region Main Methods 
        public virtual void CreateExam()
        {
            HelperMethods.CheckPositiveInput("Please Enter the time of the Exam you want to Create in Minutes : ", out int temp);
            Time = temp;

            HelperMethods.CheckPositiveInput("Please Enter the Number of Questions in the Exam you want to Create : ", out temp);
            NumberOfQuestions = temp;

            Questions = new List<Question>(NumberOfQuestions);
            Console.Clear();
        }
        public virtual void ShowExam()
        {
            if (Questions == null || Questions.Count < 1)
            {
                Console.WriteLine("There is No Exams Yet");
                return;
            }

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"{i + 1} ) {Questions[i]}");

                for (int ch = 0; ch < Questions[i].Choices.Length; ch++)
                    Console.WriteLine($"{ch + 1} ) {Questions[i].Choices[ch]}");

                Console.WriteLine("\n---------------------------------------");

                HelperMethods.CheckPositiveInput("Please Enter The Correct Answer : ", out int answer, Questions[i].Choices.Length);

                if (answer == Questions[i].Answer.AnswerId)
                    Grade += Questions[i].Mark;
                Console.WriteLine("\n========================================\n");
            }
            Console.Clear();
        }

        #endregion
    }
    class PracticalExam : Exam
    {
        public override void CreateExam()
        {
            base.CreateExam();
            for (int i = 0; i < NumberOfQuestions; ++i)
            {
                Question Qi = new Question();
                Qi.InputQuestion(i+1,false);

                Questions.Add(Qi);
                Console.Clear();
            }

        }

        public override void ShowExam()
        {
            base.ShowExam();
            Console.WriteLine("The Correct answers : ");
            for ( int i =0;  i < NumberOfQuestions; ++i) 
                Console.WriteLine(Questions[i].Answer);
        }
    }

    class FinalExam : Exam
    {
        public override void CreateExam()
        {
            base.CreateExam();
            for (int i = 0; i < NumberOfQuestions; ++i)
            {
                Question Qi = new Question();
                Qi.InputQuestion(i+1);
                TotalMarks += Qi.Mark;
                Questions.Add(Qi); 
                Console.Clear();
            }
        }

        public override void ShowExam()
        {
            base.ShowExam();
            Console.WriteLine("The Correct answers : ");
            for (int i =0; i < NumberOfQuestions; i++) 
                Console.WriteLine($"{i+1} ) {Questions[i]}\n==> {Questions[i].Answer}");

            Console.WriteLine($"Your Exam Grade is {Grade} From {TotalMarks}");

        }

    }


}
