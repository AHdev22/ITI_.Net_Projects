
class Program
{
    static void Main(string[] args)
    {
        // Demo: create MCQ object and print
        string[] choices = { "Red", "Green", "Blue", "Yellow" };
        Question q = new MCQ("Color Question", "What is your favorite color?", 5, choices);
        q.Show();

        // Create array of MCQ, take data from user, and print
        Console.Write("How many MCQ questions? ");
        int n = int.Parse(Console.ReadLine() ?? "1");
        MCQ[] mcqs = new MCQ[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter data for MCQ #{i + 1}:");
            Console.Write("Header: ");
            string header = Console.ReadLine() ?? "";
            Console.Write("Body: ");
            string body = Console.ReadLine() ?? "";
            Console.Write("Mark: ");
            int mark = int.Parse(Console.ReadLine() ?? "1");
            Console.Write("Number of choices: ");
            int c = int.Parse(Console.ReadLine() ?? "1");
            string[] userChoices = new string[c];
            for (int j = 0; j < c; j++)
            {
                Console.Write($"Choice {j + 1}: ");
                userChoices[j] = Console.ReadLine() ?? "";
            }
            mcqs[i] = new MCQ(header, body, mark, userChoices);
        }

        Console.WriteLine("\nAll MCQ Questions:");
        foreach (var mcq in mcqs)
        {
            mcq.Show();
            Console.WriteLine();
        }

        // Bonus: Take answers and calculate result
        int totalScore = 0;
        int totalMark = 0;
        for (int i = 0; i < mcqs.Length; i++)
        {
            Console.Write($"Enter your answer for MCQ #{i + 1} (enter choice number): ");
            int ans = int.Parse(Console.ReadLine() ?? "1");
            // For demo, assume correct answer is always choice 1
            if (ans == 1)
            {
                totalScore += mcqs[i].Mark;
            }
            totalMark += mcqs[i].Mark;
        }
        Calc calc = new Calc();
        Console.WriteLine($"\nYour total score: {totalScore} out of {totalMark}");
        Console.WriteLine($"Percentage: {calc.Div(totalScore * 100, totalMark)}%");
    }
}

public class Calc
{
    // Sum Overloads
    public int Sum(int a, int b) => a + b;
    public double Sum(double a, double b) => a + b;
    public int Sum(int a, int b, int c) => a + b + c;

    // Sub Overloads
    public int Sub(int a, int b) => a - b;
    public double Sub(double a, double b) => a - b;

    // Mul Overloads
    public int Mul(int a, int b) => a * b;
    public double Mul(double a, double b) => a * b;

    // Div Overloads
    public int Div(int a, int b) => b != 0 ? a / b : throw new DivideByZeroException();
    public double Div(double a, double b) => b != 0 ? a / b : throw new DivideByZeroException();
}
public class Question
{
    public string? Header { get; set; }
    public string? Body { get; set; }
    public int Mark { get; set; }

    // Default constructor
    public Question() { }

    // Constructor with all properties
    public Question(string header, string body, int mark)
    {
        Header = header;
        Body = body;
        Mark = mark;
    }

    // Show method
    public virtual void Show()
    {
        Console.WriteLine($"Header: {Header}");
        Console.WriteLine($"Body: {Body}");
        Console.WriteLine($"Mark: {Mark}");
    }
}
public class MCQ : Question
{
    public string[] Choices { get; set; }

    // Default constructor
    public MCQ() : base()
    {
        Choices = Array.Empty<string>();
    }

    // Constructor with all properties
    public MCQ(string header, string body, int mark, string[] choices)
        : base(header, body, mark)
    {
        Choices = choices;
    }

    // Show override
    public override void Show()
    {
        base.Show();
        Console.WriteLine("Choices:");
        for (int i = 0; i < Choices.Length; i++)
        {
            Console.WriteLine($"  {i + 1}. {Choices[i]}");
        }
    }
}
// ...existing code...
