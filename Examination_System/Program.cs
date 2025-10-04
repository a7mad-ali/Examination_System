namespace Examination_System
{
    internal class Program
    {
        static void Main()
        {
            Console.Title = "Examination System v2.0";
            Console.WriteLine("=== Welcome to the Examination System ===\n");

            var subject = new Subject(100, "General Knowledge");

            string path = Path.Combine(Environment.CurrentDirectory, "QuestionLog.txt");
            var qList = new QuestionList(path);

            // create questions
            var q1 = new TrueOrFalse("Q1", "The Earth is round.", 2);
            q1.AnsList[0].IsCorrect = true;

            var q2 = new ChooseOne("Q2", "Which planet is known as the Red Planet?", 3);
            q2.AnsList.Add(new Answer("Earth"));
            q2.AnsList.Add(new Answer("Mars", true));
            q2.AnsList.Add(new Answer("Venus"));

            var q3 = new ChooseAll("Q3", "Select all prime numbers:", 5);
            q3.AnsList.Add(new Answer("2", true));
            q3.AnsList.Add(new Answer("3", true));
            q3.AnsList.Add(new Answer("4"));
            q3.AnsList.Add(new Answer("5", true));

            qList.Add(q1);
            qList.Add(q2);
            qList.Add(q3);

            var practice = new PracticeExam(subject, qList, TimeSpan.FromMinutes(10));
            var final = new FinalExam(subject, qList, TimeSpan.FromMinutes(15));

            var s1 = new Student("Ahmed");
            var s2 = new Student("Khaled");

            practice.ExamStarted += s1.OnExamStarted;
            practice.ExamStarted += s2.OnExamStarted;
            final.ExamStarted += s1.OnExamStarted;

            Console.WriteLine("\nChoose exam type:");
            Console.WriteLine("1) Practice Exam");
            Console.WriteLine("2) Final Exam");
            Console.Write("Your choice: ");
            string? choice = Console.ReadLine();

            Console.Clear();
            if (choice == "1")
                practice.ShowExam();
            else
                final.ShowExam();

            Console.WriteLine("\n Results saved in Results.txt");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
