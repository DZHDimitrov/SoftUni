using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Interfaces;
using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request,IUserService _userService) : base(request)
        {
            userService = _userService;
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new {IsAuthenticated = false});
        }

        public Response Register()
        {
            if(User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isValid,errors) = userService.Register(model);

            if (!isValid)
            {
                return View(new { Errors = errors }, "/Error");
            }

            return Redirect("/Users/Login");
        }

        [HttpPost]
        public Response Login (LoginViewModel model)
        {
            Request.Session.Clear();

            var userId = userService.Login(model);

            if (userId == null)
            {
                var error = new ErrorViewModel() { ErrorMessage = "Invalid username or password" };

                return View(new { Errors = new List<ErrorViewModel>() { error } },"/Error");
            }

            SignIn(userId);

            var cookiesCollection = new CookieCollection();
            cookiesCollection.Add(Session.SessionCookieName, Request.Session.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
