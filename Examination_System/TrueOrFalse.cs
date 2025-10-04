using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{

    internal class TrueOrFalse : Question
    {
        public TrueOrFalse(string header, string body, int mark)
            : base(header, body, mark)
        {
            AnsList.Add(new Answer("True"));
            AnsList.Add(new Answer("False"));
        }

        public override bool CheckValue(string input)
        {
            return int.TryParse(input, out int choice)
                && (choice == 1 || choice == 2)
                && AnsList[choice - 1].IsCorrect;
        }

        public override void ShowQuestion()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n[True/False] {Header} - {Body} ({Mark} Mark)");
            Console.ResetColor();
            Console.WriteLine("1) True\n2) False");
        }
    }
}
