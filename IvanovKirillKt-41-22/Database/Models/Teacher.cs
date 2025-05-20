namespace IvanovKirillKt_41_22.Database.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int ADId { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }

        public AcademicDegree AcademicDegree { get; set; }
        public Position Position { get; set; }
        public Department Department { get; set; }
    }
}
