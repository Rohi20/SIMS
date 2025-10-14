namespace SIMSWeb.Model.ViewModels.Course
{
    public class DeleteCourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? TeacherId { get; set; }
        public string? TeacherName { get; set; }
    }
}
