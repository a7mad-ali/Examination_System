using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class AnswerList : List<Answer>, ICloneable
    {

        public object Clone()
        {
            var copy = new AnswerList();
            foreach (var answer in this)
                copy.Add((Answer)answer.Clone());
            return copy;
        }
        public override string ToString()
        {
            string result = "";
            foreach (var answer in this)
            { 
                result += answer.ToString()+ Environment.NewLine;
            }
            return result;
        }
    }
}
