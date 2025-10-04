using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class PracticeExam : Exam
    {
        public PracticeExam(int id, TimeSpan duration, Subject subject)
            : base(id, duration, subject) { }

        public override void ShowExam()
        {
            Console.WriteLine("=== PRACTICE EXAM ===");
            foreach (var q in Questions)
            {
                q.Display(true); 
                Console.WriteLine();
            }

            Console.WriteLine(" Correct answers are shown for practice.\n");
        }
    }
}
