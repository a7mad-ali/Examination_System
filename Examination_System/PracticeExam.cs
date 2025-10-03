using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class PracticeExam : Exam
    {
        public PracticeExam(TimeSpan Time , Subject Subj) : base(Time , Subj) { }
        
        public override void ShowExam()
        {
            Console.WriteLine("==== Practice Exam ====");
            foreach(var keyvaluepair in Questions)
            {
                keyvaluepair.Key.GetQuestion();
                Console.WriteLine("Correct Answes :");
                foreach (var answer in keyvaluepair.Value)
                {
                    if (answer.IsCorrect)
                        Console.WriteLine(answer);
                }
                Console.WriteLine("===========================================================================");
            }
        }
    }
}
