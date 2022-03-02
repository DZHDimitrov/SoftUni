using SMS.Models;

namespace SMS.Interfaces
{
    public interface IUserService
    {
        public (bool isRegistered, string error) Register(RegisterViewModel model);

        string Login(LoginViewModel model);

        string GetUsername(string userId);
    }
}
