using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class ChooseOne : Question
    {
        public ChooseOne(string header, string body, int mark)
            : base(header, body, mark) { }

        public override bool CheckValue(string input)
        {
            return int.TryParse(input, out int choice)
                && choice >= 1 && choice <= AnsList.Count
                && AnsList[choice - 1].IsCorrect;
        }

        public override void ShowQuestion()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[Choose One Answer] {Header} - {Body} ({Mark} Mark)");
            Console.ResetColor();
            for (int i = 0; i < AnsList.Count; i++)
                Console.WriteLine($"{i + 1}) {AnsList[i].Body}");
        }
    }

}
