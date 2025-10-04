using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class ChooseAll : Question
    {
        public ChooseAll(string header, string body, int mark)
            : base(header, body, mark) { }

        public override bool CheckValue(string input)
        {
            var answers = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => int.TryParse(x.Trim(), out int n) ? n : -1)
                               .Where(n => n > 0)
                               .ToHashSet();

            for (int i = 0; i < AnsList.Count; i++)
            {
                if (AnsList[i].IsCorrect != answers.Contains(i + 1))
                    return false;
            }
            return true;
        }

        public override void ShowQuestion()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[Choose Multiple Answers] {Header} - {Body} ({Mark} Mark)");
            Console.ResetColor();
            for (int i = 0; i < AnsList.Count; i++)
                Console.WriteLine($"{i + 1}) {AnsList[i].Body}");
            Console.WriteLine("Enter answers separated by commas (e.g., 1,3)");
        }
    }

}
