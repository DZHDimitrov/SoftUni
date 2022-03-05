namespace FootballManager.Interfaces
{

    using FootballManager.ViewModels;

    public interface IUserService
    {
        public bool Register(RegisterViewModel model);

        public string Login(LoginViewModel model);
    }
}
