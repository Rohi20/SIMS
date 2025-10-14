using SIMSWeb.Model.Models;

namespace SIMSWeb.Model.ViewModels.ProfileModels
{
    public class StudentProfileMetrics
    {
        public int ActiveCourses { get; set; }
        public int ActiveAssignments { get; set; }
        public int CompletedAssignmentsCount { get; set; }
        public double MaximumMarks { get; set; }

    }

    public class EnrolledCourses
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public List<string> AssignmentCreated { get; set; }
    }

    public class AssignmentProgress
    {
        public string CourseName { get; set; }
        public string AssignmentTitle { get; set; }
        public double Score { get; set; }
        public double MaxScore { get; set; }
        public string ProgressColor { get; set; }
    }

    public class StudentProfile
    {
        public StudentProfileMetrics StudentProfileMetrics { get; set; }
        public User User { get; set; }
        public List<EnrolledCourses> EnrolledCourses { get; set; }
        public List<AssignmentProgress> AssignmentProgress { get; set; }
    }
}
