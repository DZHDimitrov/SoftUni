using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace SharedTrip.Controllers
{

    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index()
        {
            var user = User.IsAuthenticated;

            return this.View(new { IsAuthenticated = User.IsAuthenticated });
        }
    }
}