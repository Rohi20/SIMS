namespace SIMSWeb.Model.ViewModels.StudentsModels
{
    public class SubmissionViewModel
    {
        public int Id { get; set; }

        public int AssignmentId { get; set; }

        public string? AssignmentName { get; set; }

        public int StudentId { get; set; }

        public string? StudentName { get; set; } = string.Empty;

        public double Score { get; set; }
        public string? Feedback { get; set; } = string.Empty;
        public DateTime SubmittedAt { get; set; }
    }
}
