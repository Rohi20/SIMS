using SIMSWeb.Model.Models;

namespace SIMSWeb.Model.ViewModels.StudentsModels
{
    public class StudentViewModel
    {
        public DateTime EnrollmentDate { get; set; }

        public List<Enrollment> Enrollments { get; set; }

        public int UserId { get; set; }
    }
}
