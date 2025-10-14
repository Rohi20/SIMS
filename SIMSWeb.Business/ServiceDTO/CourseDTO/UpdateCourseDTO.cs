using SIMSWeb.Business.ServiceDTO.StudentDTO;
using SIMSWeb.Model.ViewModels.Course;
using SIMSWeb.Model.ViewModels.TeachersModels;

namespace SIMSWeb.Business.ServiceDTO.CourseDTO
{

    public class UpdateCourseVM
    {
        public CourseViewModel Course { get; set; }
        public List<TeacherSelect>? TeachersList { get; set; }
        public List<StudentSelect>? StudentList { get; set; }

    }
}
