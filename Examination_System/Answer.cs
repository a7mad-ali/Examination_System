using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{

    public class Answer : ICloneable
    {
        public string Body { get; set; }
        public bool IsCorrect { get; set; }

        public Answer() : this(string.Empty, false) { }

        public Answer(string body, bool isCorrect = false)
        {
            Body = body;
            IsCorrect = isCorrect;
        }

        public object Clone()
        {
            return new Answer(Body, IsCorrect);
        }

        public override string ToString()
        {
            return $"{Body} (Correct: {IsCorrect})";
        }

        public override bool Equals(object obj)
        {
            if (obj is Answer other)
                return Body == other.Body && IsCorrect == other.IsCorrect;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Body, IsCorrect);
        }
    }


}
