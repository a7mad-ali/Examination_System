using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class ExamArgs : EventArgs
    {
        public Exam Exam { get; }
        public string Message { get; }

        public ExamArgs(Exam exam, string message)
        {
            Exam = exam;
            Message = message;
        }
    }
}
