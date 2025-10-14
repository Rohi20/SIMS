namespace SIMSWeb.Model.ViewModels.TeachersModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public DateTime HireDate { get; set; }
        public string? Department { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}
