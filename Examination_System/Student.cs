using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Student
    {
        public string FullName { get; set; }

        public Student(string name)
        {
            FullName = name;
        }

        public void OnExamStarted(object sender, ExamArgs e)
        {
            Console.WriteLine($" {FullName} notified: Exam for {e.Exam.SubjectForExam.Name} has started!");
        }
    }
}
