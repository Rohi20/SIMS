using SIMSWeb.Model.Models;
using SIMSWeb.Model.ViewModels.Common;
using SIMSWeb.Model.ViewModels.TeachersModels;

namespace SIMSWeb.Model.ViewModels.CourseModels
{
    public class ManageCourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; } = string.Empty;

        public Teacher Teacher { get; set; }
    }

    public class CourseFilterModel
    {
        public List<TeacherSelect> TeacherList { get; set; }
    }

    public class ManageCourseVM
    {
        public List<ManageCourseModel> Courses { get; set; }
        public CourseFilterModel FilterModel { get; set; }
        public PaginatedResult<ManageCourseModel> Paginations { get; set; }

    }
}
