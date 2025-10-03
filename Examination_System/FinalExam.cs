using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class FinalExam : Exam
    {
        public FinalExam(TimeSpan time, Subject subj) : base(time, subj) { }
    
        public override void ShowExam()
        {
            Console.WriteLine("********** Final Exam ***********");
            foreach(var KeyValuePair in Questions)
            {
                KeyValuePair.Key.GetQuestion();
                Console.WriteLine("--------------------");
            }
        }

    }
}
