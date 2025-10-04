using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class FinalExam : Exam
    {
        public FinalExam(Subject s, QuestionList q, TimeSpan t) : base(s, q, t) { }

        public override void ShowExam()
        {
            Start();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== FINAL EXAM ===");
            Console.ResetColor();

            double totalScore = 0, totalMarks = QuestionListForExam.Sum(q => q.Mark);

            foreach (var q in QuestionListForExam)
            {
                q.ShowQuestion();
                Console.Write("Your answer: ");
                string input = Console.ReadLine() ?? "";
                if (q.CheckValue(input)) totalScore += q.Mark;
                Console.WriteLine();
            }

            Finished();
            double percent = (totalScore / totalMarks) * 100;
            Console.WriteLine($"Your total score: {totalScore}/{totalMarks} ({percent:F2}%)");
            File.AppendAllText("Results.txt", $"[Final] {SubjectForExam.Name}: {totalScore}/{totalMarks} ({percent:F2}%)\n");
        }
    }
}
