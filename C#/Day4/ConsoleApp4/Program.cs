using System;
using System.Collections.Generic;

// ---------- Static ID Generator ----------
public static class IdGenerator
{
    private static int _idCounter = 1;
    public static int GenerateId() => _idCounter++;
}

// ---------- Base Person ----------
public abstract class Person
{
    public int Id { get; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Id = IdGenerator.GenerateId();
        Name = name;
        Age = age;
    }

    public abstract void Introduce();
}

// ---------- Student ----------
public class Student : Person
{
    public List<Course> EnrolledCourses { get; } = new List<Course>();
    public List<Grade> Grades { get; } = new List<Grade>();

    public Student(string name, int age) : base(name, age) { }

    public void RegisterCourse(Course course)
    {
        EnrolledCourses.Add(course);
        Console.WriteLine($"{Name} registered for {course.Title} ({course.Level})");
        switch (course.Level)
        {
            case CourseLevel.Beginner:
                Console.WriteLine("Good luck starting out!");
                break;
            case CourseLevel.Intermediate:
                Console.WriteLine("Keep improving your skills!");
                break;
            case CourseLevel.Advanced:
                Console.WriteLine("This will be challenging!");
                break;
        }
    }

    public override void Introduce()
    {
        Console.WriteLine($"Hi, I'm {Name}, a learner (Student).");
    }
}

// ---------- Instructor ----------
public class Instructor : Person
{
    public List<Course> TaughtCourses { get; } = new List<Course>();

    public Instructor(string name, int age) : base(name, age) { }

    public void TeachCourse(Course course)
    {
        course.Instructor = this;
        TaughtCourses.Add(course);
        Console.WriteLine($"{Name} is now teaching {course.Title}");
    }

    public override void Introduce()
    {
        Console.WriteLine($"Hello, I'm {Name}, and I teach courses.");
    }
}

// ---------- Course ----------
public class Course
{
    public string Title { get; set; }
    public CourseLevel Level { get; set; }
    public Instructor Instructor { get; set; }

    public Course(string title, CourseLevel level)
    {
        Title = title;
        Level = level;
    }
}

// ---------- Enum for Course Level ----------
public enum CourseLevel
{
    Beginner,
    Intermediate,
    Advanced
}

// ---------- Grade ----------
public class Grade
{
    public int Value { get; set; }
    public Grade(int value) => Value = value;

    public static Grade operator +(Grade g1, Grade g2)
        => new Grade(g1.Value + g2.Value);

    public static bool operator ==(Grade g1, Grade g2)
        => g1.Value == g2.Value;

    public static bool operator !=(Grade g1, Grade g2)
        => g1.Value != g2.Value;

    public override bool Equals(object obj)
        => obj is Grade g && Value == g.Value;

    public override int GetHashCode() => Value.GetHashCode();
}

// ---------- Employee ----------
public class Employee
{
    public string Name { get; set; }
    public List<Course> Courses { get; } = new List<Course>();

    public Employee(string name)
    {
        Name = name;
    }

    public void AddCourse(Course c) => Courses.Add(c);
}

// ---------- Department ----------
public class Department
{
    public string Name { get; set; }
    public List<Employee> Employees { get; } = new List<Employee>();

    public Department(string name)
    {
        Name = name;
    }

    public void AddEmployee(Employee e) => Employees.Add(e);
}

// ---------- Company ----------
public class Company
{
    public string Name { get; set; }
    public List<Department> Departments { get; } = new List<Department>();

    public Company(string name)
    {
        Name = name;
    }

    public void AddDepartment(Department d) => Departments.Add(d);
}

// ---------- Engine & Car (Composition) ----------
public class Engine
{
    public int HorsePower { get; set; }
    public Engine(int hp) => HorsePower = hp;
}

public class Car
{
    private Engine engine; // Composition
    public Car(int hp)
    {
        engine = new Engine(hp);
    }

    public void ShowCar()
    {
        Console.WriteLine($"Car with {engine.HorsePower} HP engine.");
    }
}

// ---------- Abstract Shape ----------
public abstract class Shape : IDrawable
{
    public abstract double Area();
    public abstract void Draw();
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public Circle(double r) => Radius = r;

    public override double Area() => Math.PI * Radius * Radius;

    public override void Draw()
    {
        Console.WriteLine("Drawing a Circle: ( )");
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public Rectangle(double w, double h) { Width = w; Height = h; }

    public override double Area() => Width * Height;

    public override void Draw()
    {
        Console.WriteLine("Drawing a Rectangle: [----]");
    }
}

// ---------- Drawable Interface ----------
public interface IDrawable
{
    void Draw();
}

// ---------- Main Simulation ----------
public class Program
{
    public static void Main()
    {
        // Company setup
        Company company = new Company("TechCorp");
        Department devDept = new Department("Development");
        Department hrDept = new Department("HR");
        company.AddDepartment(devDept);
        company.AddDepartment(hrDept);

        Employee emp1 = new Employee("Alice");
        Employee emp2 = new Employee("Bob");
        devDept.AddEmployee(emp1);
        hrDept.AddEmployee(emp2);

        Course csharp = new Course("C# Basics", CourseLevel.Beginner);
        Course oop = new Course("Advanced OOP", CourseLevel.Advanced);

        emp1.AddCourse(csharp);
        emp2.AddCourse(oop);

        // Instructors & Students
        Instructor inst1 = new Instructor("Dr. John", 45);
        Student st1 = new Student("Amr", 22);
        Student st2 = new Student("Sara", 20);

        inst1.TeachCourse(csharp);
        inst1.TeachCourse(oop);

        st1.RegisterCourse(csharp);
        st2.RegisterCourse(oop);

        // Grades
        st1.Grades.Add(new Grade(85));
        st1.Grades.Add(new Grade(90));

        Grade totalGrade = st1.Grades[0] + st1.Grades[1];

        // Shapes (Polymorphism)
        List<Shape> shapes = new List<Shape>
        {
            new Circle(5),
            new Rectangle(4,6)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Area: {shape.Area()}");
            shape.Draw();
        }

        // Reports
        Console.WriteLine("\n--- Report ---");

        foreach (var student in new List<Student> { st1, st2 })
        {
            Console.WriteLine($"Student: {student.Name}");
            foreach (var course in student.EnrolledCourses)
            {
                Console.WriteLine($"   Course: {course.Title} ({course.Level})");
            }

            if (student.Grades.Count > 0)
            {
                Grade total = new Grade(0);
                foreach (var g in student.Grades) total += g;
                Console.WriteLine($"   Total Grades: {total.Value}");
            }
        }

        Console.WriteLine($"\nInstructor: {inst1.Name}");
        foreach (var course in inst1.TaughtCourses)
        {
            Console.WriteLine($"   Teaches: {course.Title}");
        }

        Console.WriteLine("\nDepartments:");
        foreach (var dept in company.Departments)
        {
            Console.WriteLine($"{dept.Name} has {dept.Employees.Count} employees");
        }
    }
}
