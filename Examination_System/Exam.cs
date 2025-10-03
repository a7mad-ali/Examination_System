using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public enum ExamMode 
    {
        Queued,
        Starting,
        Finished
    }
    public abstract class Exam
    {
        public TimeSpan Time { get; set; }
        public Dictionary<Question, AnswerList> Questions { get; set; }
        public int NumberOfQuestion => Questions.Count;
        public Subject Subj {  get; set; }
        public ExamMode Mode { get; set; }
        public Exam(TimeSpan time , Subject subj)
        {
            Time = time;
            Subj = subj;
            Questions = new Dictionary<Question, AnswerList>();
            Mode = ExamMode.Queued;
        }
        public abstract void ShowExam();
        public void AddQuestion(Question ques)
        {
            Questions[ques] = ques.Answers;
        }

        public override string ToString()
        {
            return $"Exam for {Subj.Name} | Duration: {Time} | Questions: {NumberOfQuestion}";
        }

    }
}
