using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class FinalExam : Exam
    {
        public FinalExam(int id, TimeSpan duration, Subject subject)
            : base(id, duration, subject) { }

        public override void ShowExam()
        {
            Console.WriteLine("=== FINAL EXAM ===");
            foreach (var q in Questions)
            {
                q.Display(false);
                Console.WriteLine();
            }

            Console.WriteLine(" Correct answers are hidden until results are published.\n");
        }
    }
}
