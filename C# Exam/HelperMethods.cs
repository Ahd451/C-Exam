using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam
{
    static class HelperMethods
    {
        public static void CheckInputNull(string msg, out string str)
        {
            do
            {
                Console.WriteLine(msg);
                str = Console.ReadLine()!;
            } while (string.IsNullOrEmpty(str));
        }
        public static void CheckPositiveInput(string msg, out int num, int limit = int.MaxValue)
        {
            do
            {
                Console.WriteLine(msg);
            }
            while (!int.TryParse(Console.ReadLine(), out num) || num <= 0 || num > limit);
        }


    }
}
