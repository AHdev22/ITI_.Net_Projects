namespace UniversitySystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public int DeptId { get; set; }
        public Department? Department { get; set; }

        public int CrsId { get; set; }
        public Course? Course { get; set; }
    }
}
