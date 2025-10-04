using System.Collections.Generic;

namespace UniversitySystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ManagerName { get; set; }

        // Navigation
        public ICollection<Course>? Courses { get; set; }
        public ICollection<Student>? Students { get; set; }
        public ICollection<Instructor>? Instructors { get; set; }
    }
}
