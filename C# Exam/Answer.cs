using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Exam
{
    internal class Answer
    {
        #region Properties
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }
        #endregion

        #region Constructor
        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }

        #endregion
      
        #region Override Methods
        public override string ToString() => $"Answer : {AnswerId} )  {AnswerText}";

        #endregion
    }
}
