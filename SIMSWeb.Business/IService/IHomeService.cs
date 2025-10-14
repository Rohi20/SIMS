using SIMSWeb.Model.ViewModels.ProfileModels;

namespace SIMSWeb.Business.IService
{
    public interface IHomeService
    {
        Task<AdminProfile> GetAdminProfile();
        Task<TeacherProfile> GetTeacherProfile();
        Task<StudentProfile> GetStudentProfile();
    }
}
