using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Grade { get; set; }

        public int DeptId { get; set; }
        public Department? Department { get; set; }

        // Navigation
        public ICollection<CourseStudents>? CourseStudents { get; set; }
    }
}
