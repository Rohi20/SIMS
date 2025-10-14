namespace SIMSWeb.Model.ViewModels.StudentsModels
{
    public class EnrollmentViewModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int Term { get; set; }
        public double Marks { get; set; }
        public string Comments { get; set; } = string.Empty;
    }
}
