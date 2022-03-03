namespace SharedTrip
{
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using SharedTrip.Data;
    using SharedTrip.Data.Common;
    using SharedTrip.Interfaces;
    using SharedTrip.Services;
    using System.Threading.Tasks;

    public class Startup
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
               .MapControllers()
               .MapStaticFiles());

            server.ServiceCollection
                .Add<ApplicationDbContext>()
                .Add<IValidationService, ValidationService>()
                .Add<IUserService, UserService>()
                .Add<IRepository,Repository>()
                .Add<ITripService,TripService>();

            await server.Start();
        }
    }
}
