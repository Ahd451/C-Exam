
using System.Diagnostics;

namespace C__Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject("14548", "Programming"); 

            sub1.CreateExam();

            Console.Clear();
            Console.WriteLine("Do You Want to Start the Exam ?? y / n ");
            if (char.TryParse(Console.ReadLine(), out char ch) && ch.ToString().ToLower() == "y")
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                if ( sub1.Exam is not null )
               
                    sub1.Exam.ShowExam();
                
                Console.WriteLine($"Time You Take for Finishing the Exam = {sw.Elapsed}");
            }
        }
    }
}
