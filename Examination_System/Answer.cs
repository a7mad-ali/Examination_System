using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{

    public class Answer
    {
        public string Body { get; set; }
        public bool IsCorrect { get; set; }

        public Answer(string body, bool isCorrect = false)
        {
            Body = body;
            IsCorrect = isCorrect;
        }

        public override string ToString()
        {
            return $"{Body}{(IsCorrect ? " correct" : "")}";
        }
    }

   
}
