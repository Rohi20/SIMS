using SIMSWeb.Model.Models;
using SIMSWeb.Model.ViewModels.StudentsModels;

namespace SIMSWeb.Business.IService
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAssignments(int courseId);
        Task<Assignment> GetAssignmentById(int id);
        Task AddAssignment(AssignmentViewModel assignment);
        Task UpdateAssignment(Assignment assignment);
        // Task DeleteAssignment(Assignment assignment);
    }
}
