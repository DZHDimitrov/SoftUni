namespace SharedTrip.Interfaces
{
    using SharedTrip.ViewModels;
    using System.Collections.Generic;

    public interface IUserService
    {
        public (bool isRegistered, IEnumerable<ErrorViewModel> errors) Register(RegisterViewModel model);

        public string Login(LoginViewModel model);
    }
}
