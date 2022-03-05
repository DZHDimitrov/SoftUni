namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;

    using FootballManager.Interfaces;
    using FootballManager.ViewModels;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        public UsersController(Request request, IUserService _userService) : base(request)
        {
            userService = _userService;
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            var userId = userService.Login(model);

            if (userId == null)
            {
                return View(new { IsAuthenticated = false });
            }

            SignIn(userId);

            var cookieCollection = new CookieCollection();
            cookieCollection.Add(Session.SessionCookieName, Request.Session.Id);

            return Redirect("/Players/All");
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var isSuccessfullyRegistered = userService.Register(model);

            if (!isSuccessfullyRegistered)
            {
                return View(new { IsAuthenticated = false });
            }

            return Redirect("/Users/Login");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
