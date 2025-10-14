using Microsoft.AspNetCore.Mvc.Rendering;
using SIMSWeb.Model.ViewModels.Course;
using SIMSWeb.Model.ViewModels.TeachersModels;

namespace SIMSWeb.Model.ViewModels.CourseModels
{

    public class AddCourseVM
    {
        public CourseViewModel CourseModel { get; set; }
        public List<TeacherSelect> TeacherListModel { get; set; }
    }
}
