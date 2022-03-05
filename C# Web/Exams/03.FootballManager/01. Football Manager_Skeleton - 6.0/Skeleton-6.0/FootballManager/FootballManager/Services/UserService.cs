namespace FootballManager.Services
{
    using FootballManager.Data.Common;
    using FootballManager.Data.Models;

    using FootballManager.Interfaces;

    using FootballManager.ViewModels;

    using System.Security.Cryptography;
    using System.Text;

    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(IRepository _repo, IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo
                .All<User>()
                .Where(u => u.Username == model.Username && u.Password == HashPassword(model.Password))
                .FirstOrDefault();

            return user?.Id;
        }

        public bool Register(RegisterViewModel model)
        {
            bool isSuccessfullyRegistered = true;

            var isValid = validationService.ValidateModel(model);

            if (!isValid)
            {
                return false;
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password),
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                isSuccessfullyRegistered = false;
            }

            return isSuccessfullyRegistered;

        }

        private string HashPassword(string password)
        {
            byte[] byteArr = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(byteArr));
            }
        }
    }
}
