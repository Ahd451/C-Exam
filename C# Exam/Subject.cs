using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C__Exam
{
    enum User
    {
        Instructor = 1,
        Student = 2
    }
    internal class Subject
    {
        #region Properties
        public string? SubjectID { get; set; }
        public string? SubjectName { get; set; }
        public Exam Exam { get; set; }

        User user { get; set; }

        #endregion
        
        #region Constructor
        public Subject(string Id, string Name)
        {
            SubjectID = Id;
            SubjectName = Name;
            User temp;
            Console.WriteLine("Are you Instructor or Student ??");
            do
            {
                Console.WriteLine("Please Enter Your Role :\n1 for Instructor \n2: Student");
            } while (!Enum.TryParse(Console.ReadLine(), out temp) || ( temp != User.Instructor && temp!= User.Student ) );
            
            user = temp;
        }
        #endregion
        
        #region Method
        public void CreateExam()
        {
            if (user != User.Instructor)
            {
                Console.WriteLine("You Don't Have a Permission to Create an Exam!!!");
                return;
            }


            HelperMethods.CheckPositiveInput("Please Choose the type of the Exam you want to Create : \n1 For Practical Exam\n2 For Final Exam ", out int type, 2);

            Exam = type == 1 ? new PracticalExam() : new FinalExam();
            Exam.CreateExam();

        } 
        #endregion

    }
}
