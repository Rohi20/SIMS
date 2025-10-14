using SIMSWeb.Model.Models;

namespace SIMSWeb.Model.ViewModels.StudentsModels
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int MaxScore { get; set; }
        public DateTime DueDate { get; set; }

        public string? CourseName { get; set; } = string.Empty;
        public int CourseId { get; set; }

        public List<Submission>? Submissions { get; set; }
    }
}
