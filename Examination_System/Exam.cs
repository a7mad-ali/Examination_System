using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Examination_System
{

    public enum ExamMode { Queued, Started, Finished }
    public delegate void ExamStartedHandler(object sender, ExamArgs e);

    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public Subject SubjectForExam { get; set; }
        public QuestionList QuestionListForExam { get; set; }
        public TimeSpan DurationForExam { get; set; }
        public ExamMode ExamMode { get; set; } = ExamMode.Queued;
        public event ExamStartedHandler ExamStarted;

        private System.Timers.Timer? _timer;

        protected Exam(Subject subject, QuestionList questionList, TimeSpan duration)
        {
            SubjectForExam = subject;
            QuestionListForExam = questionList;
            DurationForExam = duration;
        }

        public abstract void ShowExam();

        public virtual void OnExamStarted(string msg)
        {
            ExamStarted?.Invoke(this, new ExamArgs(this, msg));
        }

        public virtual void Start()
        {
            ExamMode = ExamMode.Started;
            Console.WriteLine($"\n Exam For {SubjectForExam?.Name} started | Time limit: {DurationForExam.TotalMinutes} minutes\n");
            OnExamStarted("");

            _timer = new System.Timers.Timer(DurationForExam.TotalMinutes * 60 * 1000);
            _timer.Elapsed += (s, e) =>
            {
                _timer.Stop();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n Time's up! Exam will be auto-submitted.\n");
                Console.ResetColor();
                Finished();
                Environment.Exit(0);
            };
            _timer.Start();
        }

        public virtual void Finished()
        {
            ExamMode = ExamMode.Finished;
            Console.WriteLine("\nExam Finished ✅");
        }

        public object Clone()
        {
            Exam exam = (Exam)MemberwiseClone();
            exam.QuestionListForExam = new QuestionList($"{SubjectForExam.ID}.txt");
            foreach (var q in QuestionListForExam)
                exam.QuestionListForExam.Add((Question)q.Clone());
            return exam;
        }

        public int CompareTo(Exam? other)
        {
            if (other == null) return 1;
            int comp = QuestionListForExam.Count.CompareTo(other.QuestionListForExam.Count);
            return comp == 0 ? DurationForExam.CompareTo(other.DurationForExam) : comp;
        }

        public override string ToString()
            => $"Exam for {SubjectForExam?.Name} ({SubjectForExam?.ID}) | Questions: {QuestionListForExam?.Count} | Time: {DurationForExam.TotalMinutes} mins | Mode: {ExamMode}";
    }

}
