using SIMSWeb.Model.Models;

namespace SIMSWeb.Model.ViewModels.UserModels
{
    public record class UserModel
    {
        public string Name { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string Role { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
