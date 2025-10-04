using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{

    public enum ExamMode { Queued, Starting, Finished }

    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public int ExamId { get; set; }
        public TimeSpan Duration { get; set; }
        public Subject Subject { get; set; }
        public QuestionList Questions { get; set; }
        public Dictionary<Question, AnswerList> QuestionAnswers { get; set; }
        public ExamMode Mode { get; private set; }

        public event Action<string> ExamStarted;

        public Exam() : this(0, TimeSpan.Zero, null) { }

        public Exam(int examId, TimeSpan duration, Subject subject)
        {
            ExamId = examId;
            Duration = duration;
            Subject = subject;
            Questions = new QuestionList();
            QuestionAnswers = new Dictionary<Question, AnswerList>();
            Mode = ExamMode.Queued;
        }

        public void StartExam()
        {
            Mode = ExamMode.Starting;
            ExamStarted?.Invoke($"Exam for {Subject?.Name} has started!");
        }

        public void FinishExam()
        {
            Mode = ExamMode.Finished;
        }

        public abstract void ShowExam();

        public object Clone()
        {
            var copy = (Exam)MemberwiseClone();
            copy.Questions = (QuestionList)Questions;
            copy.Subject = (Subject)Subject.Clone();
            return copy;
        }

        public int CompareTo(Exam other)
        {
            return Duration.CompareTo(other?.Duration);
        }

        public override string ToString()
        {
            return $"Exam ID: {ExamId}, Subject: {Subject?.Name}, Duration: {Duration}, Mode: {Mode}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Exam other)
                return ExamId == other.ExamId;
            return false;
        }

        public override int GetHashCode()
        {
            return ExamId.GetHashCode();
        }
    }
}
