using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class QuestionList : List<Question>
    {
        private readonly string _logFilePath;

        public QuestionList()
        {
            string fileName = $"QuestionLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            _logFilePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        }

        public new void Add(Question question)
        {
            base.Add(question);
            LogQuestion(question);
        }

        private void LogQuestion(Question question)
        {
            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine("===================================");
                writer.WriteLine($"Added on: {DateTime.Now}");
                writer.WriteLine($"Header: {question.Header}");
                writer.WriteLine($"Body: {question.Body}");
                writer.WriteLine($"Marks: {question.Marks}");
                writer.WriteLine("Answers:");
                foreach (var ans in question.Answers)
                    writer.WriteLine($" - {ans.Body} (Correct: {ans.IsCorrect})");
                writer.WriteLine("===================================\n");
            }
        }
    }


}
