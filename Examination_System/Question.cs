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
        public int Mark { get; set; }
        public AnswerList AnsList { get; set; }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnsList = new AnswerList();
        }

        public abstract void ShowQuestion();
        public abstract bool CheckValue(string input);

        public override string ToString() => $"{Header}: {Body} ({Mark} mark)";

        public override bool Equals(object? obj)
            => obj is Question q && Header == q.Header && Body == q.Body && Mark == q.Mark;

        public override int GetHashCode() => HashCode.Combine(Header, Body, Mark);

        public virtual object Clone()
        {
            Question clone = (Question)MemberwiseClone();
            clone.AnsList = new AnswerList();
            foreach (Answer ans in AnsList)
                clone.AnsList.Add(new Answer(ans.Body, ans.IsCorrect));
            return clone;
        }

        public int CompareTo(Question? other)
            => other == null ? 1 : Mark.CompareTo(other.Mark);
    }
}
