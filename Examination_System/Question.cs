using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public abstract class Question : ICloneable, IComparable<Question>
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Marks { get; set; }
        public AnswerList Answers { get; set; }
        public Question() : this("Default Header", "Default Body", 1) { }
        public Question( string header , string body , int marks)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Answers = new AnswerList();
        }
        public abstract void Display(bool showCorrectAnswers = false);
        public abstract object Clone();
        public int CompareTo(Question other)
        {
            if (other == null) return 1;
            int byMarks = Marks.CompareTo(other.Marks);
            if (byMarks != 0) return -byMarks;
            return string.Compare(Header, other.Header, StringComparison.Ordinal);
        }

        public abstract string GetQuestion();
        public override string ToString()
        {
            return $"{Header}-  {Body} ({Marks} marks)";
        }

        public override bool Equals(object obj)
        {
            if (obj is Question q)
            {
                return Header == q.Header &&
                       Body == q.Body &&
                       Marks == q.Marks &&
                       Answers.SequenceEqual(q.Answers);
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + (Header?.GetHashCode() ?? 0);
                hash = (hash * 23) + (Body?.GetHashCode() ?? 0);
                hash = (hash * 23) + Marks.GetHashCode();
                foreach (var a in Answers)
                    hash = (hash * 31) + (a?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}
