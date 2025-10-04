using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class ChooseOne : Question
    {
        public ChooseOne() : base() { }

        public ChooseOne(string header, string body, int marks)
            : base(header, body, marks) { }

        public override void Display(bool showCorrectAnswers = false)
        {
            Console.WriteLine(ToString());

            for (int i = 0; i < Answers.Count; i++)
            {
                var ans = Answers[i];
                Console.WriteLine($"{(char)('A' + i)}. {ans.Body}" +
                    (showCorrectAnswers && ans.IsCorrect ? "  <-- correct" : ""));
            }
        }

        public override object Clone()
        {
            var copy = new ChooseOne(Header, Body, Marks);
            copy.Answers = (AnswerList)Answers.Clone();
            return copy;
        }

        public override string GetQuestion()
        {
            throw new NotImplementedException();
        }
    }
}
