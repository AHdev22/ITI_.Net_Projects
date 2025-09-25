// Program.cs
using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqDay1
{
    class Subject { public int Code { get; set; } public string? Name { get; set; } }
    class Student { public int ID { get; set; } public string? FirstName { get; set; } public string? LastName { get; set; } public Subject[] Subjects { get; set; } }

    class Program
    {
        static void Main()
        {
            // PART 1
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };

            // Query1: distinct and sorted
            var q1 = numbers.Distinct().OrderBy(n => n).ToList();
            Console.WriteLine("Part1 - Query1 (Distinct & Sorted):");
            Console.WriteLine(string.Join(", ", q1));


            // Query2: using Query1 result and show multiplication tables 1..10 for each number
            // (Assumption: "it's multiplication" → multiplication table; change range if you want a single factor)
            var mult = q1
                .SelectMany(n => Enumerable.Range(1, 10), (n, m) => new { Number = n, Multiplier = m, Product = n * m })
                .GroupBy(x => x.Number);
            Console.WriteLine("\nPart1 - Query2 (Multiplication tables 1..10):");
            foreach (var g in mult)
            {
                Console.WriteLine($"{g.Key}: {string.Join(", ", g.Select(x => $"{x.Number}x{x.Multiplier}={x.Product}"))}");
            }

            // PART 2
            string[] names = { "Tom", "Dick", "Harry", "MARY", "Jay" };

            // Query1: names length == 3 (Query expression)
            var q2_1_query = from name in names where name.Length == 3 select name;
            Console.WriteLine("\nPart2 - Query1 (Query expression) length==3:");
            Console.WriteLine(string.Join(", ", q2_1_query));

            // Query1: names length == 3 (Method expression)
            var q2_1_method = names.Where(n => n.Length == 3);
            Console.WriteLine("\nPart2 - Query1 (Method expression) length==3:");
            Console.WriteLine(string.Join(", ", q2_1_method));

            // Query2: contains 'a' (case-insensitive) then sort by length
            var q2_2 = names.Where(n => n.ToLower().Contains("a")).OrderBy(n => n.Length);
            Console.WriteLine("\nPart2 - Query2 (contains 'a', order by length):");
            Console.WriteLine(string.Join(", ", q2_2));

            // Query3: first 2 names
            var q2_3 = names.Take(2);
            Console.WriteLine("\nPart2 - Query3 (first 2 names):");
            Console.WriteLine(string.Join(", ", q2_3));

            // PART 3 - Students and Subjects
            var students = new List<Student>
            {
                new Student { ID = 1, FirstName = "Ali",  LastName = "Mohammed", Subjects = new Subject[] { new Subject { Code = 22, Name = "EF" }, new Subject { Code = 33, Name = "UML" } } },
                new Student { ID = 2, FirstName = "Mona", LastName = "Gala",     Subjects = new Subject[] { new Subject { Code = 22, Name = "EF" }, new Subject { Code = 34, Name = "XML" }, new Subject { Code = 25, Name = "JS" } } },
                new Student { ID = 3, FirstName = "Yara", LastName = "Yousf",    Subjects = new Subject[] { new Subject { Code = 22, Name = "EF" }, new Subject { Code = 25, Name = "JS" } } },
                new Student { ID = 4, FirstName = "Ali",  LastName = "Ali",      Subjects = new Subject[] { new Subject { Code = 33, Name = "UML" } } }
            };

            // Query1: Full name and number of subjects
            Console.WriteLine("\nPart3 - Query1 (Full name and number of subjects):");
            var s_q1 = students.Select(s => new { FullName = s.FirstName + " " + s.LastName, Count = (s.Subjects ?? new Subject[0]).Length });
            foreach (var item in s_q1) Console.WriteLine($"{item.FullName} - Subjects: {item.Count}");

            // Query2: Order by FirstName desc then LastName asc, show only names
            Console.WriteLine("\nPart3 - Query2 (Order FirstName desc, LastName asc):");
            var s_q2 = students.OrderByDescending(s => s.FirstName).ThenBy(s => s.LastName).Select(s => new { s.FirstName, s.LastName });
            foreach (var item in s_q2) Console.WriteLine($"{item.FirstName} {item.LastName}");

            // Query3: Display each student and their subjects (SelectMany)
            Console.WriteLine("\nPart3 - Query3 (Student - Subject pairs using SelectMany):");
            var s_q3 = students.SelectMany(s => s.Subjects, (s, sub) => new { Student = s.FirstName + " " + s.LastName, Subject = sub.Name });
            foreach (var item in s_q3) Console.WriteLine($"{item.Student} - {item.Subject}");

            // BONUS: GroupBy subject name and list students in each subject
            Console.WriteLine("\nPart3 - BONUS (GroupBy subject):");
            var bonus = students
                .SelectMany(s => s.Subjects, (s, sub) => new { Student = s.FirstName + " " + s.LastName, Subject = sub.Name })
                .GroupBy(x => x.Subject);
            foreach (var g in bonus) Console.WriteLine($"{g.Key}: {string.Join(", ", g.Select(x => x.Student))}");
        }
    }
}
