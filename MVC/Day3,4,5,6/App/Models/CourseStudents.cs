namespace UniversitySystem.Models
{
    public class CourseStudents
    {
        public int Id { get; set; }
        public double Degree { get; set; }

        public int CrsId { get; set; }
        public Course? Course { get; set; }

        public int StdId { get; set; }
        public Student? Student { get; set; }
    }
}
