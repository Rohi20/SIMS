using SIMSWeb.Business.ServiceDTO.StudentDTO;
using SIMSWeb.Model.ViewModels.StudentsModels;

namespace SIMSWeb.Business.ServiceDTO.SubmissionDTO
{
    public class UpdateSubmissionDTO
    {
        public SubmissionViewModel Submission { get; set; }
        public List<StudentSelect>? StudentList { get; set; }
    }
}
