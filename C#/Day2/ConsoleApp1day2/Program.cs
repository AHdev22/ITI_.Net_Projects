struct Time
{
    public int Hours;
    public int Minutes;
    public int Seconds;

    // Constructor
    public Time(int h, int m, int s)
    {
        Hours = h;
        Minutes = m;
        Seconds = s;
    }

    // Method to print time in required format
    public void Print()
    {
        Console.WriteLine($"{Hours}H:{Minutes}M:{Seconds}S");
    }
}
class Program
{
    static void Main()
    {
        // 1- we need to store student names ,take num of student and names from user print names
        Console.WriteLine("Enter the number of students: ");
        int studentNumber = int.Parse(Console.ReadLine());

        string[] student = new string[studentNumber];

        for (int i = 0; i < studentNumber; i++)
        {
            student[i] = Console.ReadLine();
        }

        Console.WriteLine("\nStudent Names:");
        for (int i = 0; i < studentNumber; i++)
        {
            Console.WriteLine($"- {student[i]}");
        }


        // 2- we need to store student age for many tracks take num of student and tracks from user
        // enter student ages and print it - calc age avg foreach track
        Console.Write("Enter number of students: ");
        int numStudents = int.Parse(Console.ReadLine());

        Console.Write("Enter number of tracks: ");
        int numTracks = int.Parse(Console.ReadLine());

        // 2D array: rows = students, columns = tracks
        int[,] ages = new int[numStudents, numTracks];

        // input ages
        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"\nEnter ages for student {i + 1}:");
            for (int j = 0; j < numTracks; j++)
            {
                Console.Write($"  Track {j + 1} age: ");
                ages[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // print ages
        Console.WriteLine("\nAll Student Ages:");
        for (int i = 0; i < numStudents; i++)
        {
            Console.Write($"Student {i + 1}: ");
            for (int j = 0; j < numTracks; j++)
            {
                Console.Write(ages[i, j] + " ");
            }
            Console.WriteLine();
        }

        // calculate average for each track
        Console.WriteLine("\nAverage Age for Each Track:");
        for (int j = 0; j < numTracks; j++)
        {
            int sum = 0;
            for (int i = 0; i < numStudents; i++)
            {
                sum += ages[i, j];
            }
            double avg = (double)sum / numStudents;
            Console.WriteLine($"Track {j + 1}: {avg:F2}");
        }

        //3-  create variable from Time
        Time t1 = new Time(22, 33, 11);

        // print time
        t1.Print();
    }
}






