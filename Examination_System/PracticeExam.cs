using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(Subject s, QuestionList q, TimeSpan t) : base(s, q, t) { }

        public override void ShowExam()
        {
            Start();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== PRACTICE EXAM ===");
            Console.ResetColor();

            double totalScore = 0, totalMarks = QuestionListForExam.Sum(q => q.Mark);

            foreach (var q in QuestionListForExam)
            {
                q.ShowQuestion();
                Console.Write("Your answer: ");
                string input = Console.ReadLine() ?? "";

                bool correct = q.CheckValue(input);
                if (correct) totalScore += q.Mark;

                Console.WriteLine(correct ? "✅ Correct!" : "❌ Wrong!");
                Console.WriteLine("Correct answers:");
                foreach (var ans in q.AnsList.Where(a => a.IsCorrect))
                    Console.WriteLine($"  - {ans.Body}");
                Console.WriteLine("--------------------------------------");
            }

            Finished();
            double percent = (totalScore / totalMarks) * 100;
            Console.WriteLine($"Your final score: {totalScore}/{totalMarks} ({percent:F2}%)");
            File.AppendAllText("Results.txt", $"[Practice] {SubjectForExam.Name}: {totalScore}/{totalMarks} ({percent:F2}%)\n");
        }
    }
}
