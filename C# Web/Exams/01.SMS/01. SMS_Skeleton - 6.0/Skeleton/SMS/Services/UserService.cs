using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Interfaces;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private IValidationService validationService;
        private IRepository repo;

        public UserService(IValidationService _validationService,IRepository _repo)
        {
            validationService = _validationService;
            repo = _repo;
        }

        public string GetUsername(string userId)
        {
            return repo
                .All<User>()
                .FirstOrDefault(u => u.Id == userId)?.Username;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo
                .All<User>()
                .Where(u => u.Username == model.Username && u.Password == HashPassword(model.Password))
                .FirstOrDefault();

            return user?.Id;
        }

        public (bool isRegistered, string error) Register(RegisterViewModel model)
        {
            bool registered = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (false, validationError);
            }

            Cart cart = new Cart();

            var user = new User()
            {
                Username = model.Username,
                Password = HashPassword(model.Password),
                CartId = cart.Id,
                Cart = cart,
                Email = model.Email,
            };


            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception e)
            {
                error = "Could not save in database";
            }

            return (registered, error);
        }

        private string HashPassword(string password)
        {
            byte[] passwordArr = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArr));
            }
        }
    }
}
