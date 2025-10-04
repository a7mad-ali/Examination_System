using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class TrueOrFalse : Question
    {


        public TrueOrFalse(string header, string body, int marks)
           : base(header, body, marks)
        {
            InitializeAnswers();
        }
        private void InitializeAnswers()
        {
            Answers.Clear();
            Answers.Add(new Answer("True"));
            Answers.Add(new Answer("False"));
        }
        public override void Display(bool showCorrectAnswers = false)
        {
            Console.WriteLine(ToString());
            for (int i = 0; i < Answers.Count; i++)
            {
                var ans = Answers[i];
                Console.WriteLine($"{i + 1}. {ans.Body}" +
                    (showCorrectAnswers && ans.IsCorrect ? "  <-- correct" : ""));
            }
        }
        public override string GetQuestion()
        {
            return $"{Header} \n {Body} \n 1.True \n 2.False";
        }
        public override object Clone()
        {
            var clone = new TrueOrFalse(Header, Body, Marks);
            clone.Answers = (AnswerList)Answers.Clone();
            return clone;
        }
    }
}
