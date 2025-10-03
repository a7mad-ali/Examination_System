using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class QuestionList : List<Question>
    {
        private string logFilePath;

        public QuestionList(string fileName)
        {
            logFilePath = fileName;
        }

        public new void Add(Question q)
        {
            base.Add(q);

            using (StreamWriter writer = new StreamWriter(logFilePath, true)) 
            {
                writer.WriteLine(DateTime.Now + " => " + q.ToString());
            }
        }
    }
}
