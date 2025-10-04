using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class QuestionList : List<Question>
    {
        private readonly string _filePath;

        public QuestionList(string filePath)
        {
            _filePath = filePath;
            var dir = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        public new void Add(Question q)
        {
            base.Add(q);
            using var sw = new StreamWriter(_filePath, true);
            sw.WriteLine($"[{DateTime.Now}] {q}");
            foreach (var a in q.AnsList)
                sw.WriteLine($"    - {a.Body} | Correct: {a.IsCorrect}");
            sw.WriteLine("--------------------------------------------------");
        }
    }

}
