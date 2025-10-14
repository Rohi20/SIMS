using SIMSWeb.Business.ServiceDTO.User;
using SIMSWeb.Model.Models;
using SIMSWeb.Model.ViewModels.UserModels;

namespace SIMSWeb.Business.IService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers(string userRole, string searchText, int skip, int pageSize);
        Task AddUser(UserModel user);
        Task<UpdateResponseDTO> UpdateUser(ManageUsersModel user);
        Task DeleteUser(int id);
        Task<User> AuthenticateUser(string email, string password);
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<int> GetUserCount(string userRole, string searchText);
       
    }
}
