using SIMSWeb.Model.Models;
using SIMSWeb.Model.ViewModels.TeachersModels;

namespace SIMSWeb.Business.IService
{
    public interface ITeacherService
    {
        Task<List<Teacher>> GetTeachers();
        Task AddTeacher(Teacher teacher);
        Task UpdateTeacher(TeacherViewModel teacher);
        Task DeleteTeacher(Teacher teacher);
        Task<Teacher> GetTeacherById(int id);
    }
}
