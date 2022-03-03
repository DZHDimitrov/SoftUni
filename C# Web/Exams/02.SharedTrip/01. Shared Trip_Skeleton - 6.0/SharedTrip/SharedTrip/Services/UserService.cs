using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Interfaces;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(IRepository _repo,IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo
                .All<User>()
                .FirstOrDefault(u => u.Username == model.Username && u.Password == HashPassword(model.Password));

            return user?.Id;
        }

        public (bool isRegistered, IEnumerable<ErrorViewModel> errors) Register(RegisterViewModel model)
        {
            var (isValid, errors) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (false, errors);
            }

            var user = new User()
            {
                Username = model.UserName,
                Password = HashPassword(model.Password),
                Email = model.Email,
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
            }
            catch (Exception)
            {
                return (false, new List<ErrorViewModel> { new ErrorViewModel { ErrorMessage = "Could not save user in database" } });
            }

            return (isValid, new List<ErrorViewModel>());
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
