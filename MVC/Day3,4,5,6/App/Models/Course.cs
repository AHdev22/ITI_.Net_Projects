using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Degree { get; set; }
        public int MinimumDegree { get; set; }
        public int Hours { get; set; }

        public int DeptId { get; set; }
        public Department? Department { get; set; }

        // Navigation
        public ICollection<Instructor>? Instructors { get; set; }
        public ICollection<CourseStudents>? CourseStudents { get; set; }
    }
}
