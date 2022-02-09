using SUHttpServer.Controllers;
using SUHttpServer.HTTP;
using SUHttpServer.Responses;
using System.Text;
using System.Web;

namespace SUHttpServer
{
    public class Startup
    {

        public static async Task Main()
        {
            var server = new HttpServer(routes => routes.MapControllers());

            await server.Start();
        }
    }
}
