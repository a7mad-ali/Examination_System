using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    public class Subject : ICloneable, IComparable<Subject>
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }

        public Subject() : this(0, "Unknown") { }

        public Subject(int id, string name)
        {
            SubjectId = id;
            Name = name;
        }

        public object Clone()
        {
            return new Subject(SubjectId, Name);
        }
        public int CompareTo(Subject other)
        {
            return string.Compare(Name, other?.Name, StringComparison.OrdinalIgnoreCase);
        }
        public override string ToString()
        {
            return $"Subject ID: {SubjectId}, Name: {Name}";
        }
        public override bool Equals(object obj)
        {
            if (obj is Subject other)
                return SubjectId == other.SubjectId && Name == other.Name;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SubjectId, Name);
        }
    }
}
