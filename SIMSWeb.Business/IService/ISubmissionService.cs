using SIMSWeb.Model.Models;
using SIMSWeb.Model.ViewModels.StudentsModels;

namespace SIMSWeb.Business.IService
{
    public interface ISubmissionService
    {
        Task<List<Submission>> GetSubmissionByAssignmentId(int assignmentId);
        Task<Submission> GetSubmissionById(int id);
        Task AddSubmission(SubmissionViewModel submission);
        Task UpdateSubmission(SubmissionViewModel submission);
        // Task DeleteAssignment(Assignment assignment);
    }
}
