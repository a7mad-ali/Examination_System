namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C# Programming");

            var q1 = new TrueOrFalse("Q1", "C# is a programming language.", 2);
            q1.Answers.Add(new Answer("True", true));
            q1.Answers.Add(new Answer("False"));

            var q2 = new ChooseOne("Q2", "Which company developed C#?", 3);
            q2.Answers.Add(new Answer("Google"));
            q2.Answers.Add(new Answer("Microsoft", true));
            q2.Answers.Add(new Answer("Apple"));

            var q3 = new ChooseAll("Q3", "Select OOP principles:", 4);
            q3.Answers.Add(new Answer("Encapsulation", true));
            q3.Answers.Add(new Answer("Inheritance", true));
            q3.Answers.Add(new Answer("Compilation"));

            Console.WriteLine("Select exam type:\n1. Practice Exam\n2. Final Exam");
            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            Exam exam;
            if (choice == 1)
                exam = new PracticeExam(100, TimeSpan.FromMinutes(30), subject);
            else
                exam = new FinalExam(200, TimeSpan.FromMinutes(60), subject);

            exam.ExamStarted += (msg) => Console.WriteLine($"\n📢 {msg}\n");

            exam.Questions.Add(q1);
            exam.Questions.Add(q2);
            exam.Questions.Add(q3);

            exam.StartExam();
            exam.ShowExam();

            exam.FinishExam();
            Console.WriteLine($"\nExam Finished. Mode: {exam.Mode}");
        }
    
    }
}
