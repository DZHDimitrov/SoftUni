using SUHttpServer.HTTP;
using SUHttpServer.Responses;

namespace SUHttpServer
{
    public class Startup
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
    Name: <input type='text' name='Name'>
    Age: <input type='number' name='Age'>
    <input type='submit' value='Save'>
    </form>";

        public static void Main()
        {
            new HttpServer(routes => routes
            .MapGet("/", new TextResponse("Hello from the server"))
            .MapGet("/HTML", new HtmlResponse(Startup.HtmlForm))
            .MapGet("/Redirect", new RedirectResponse("https://softuni.org/"))
            .MapPost("/HTML",new TextResponse("",Startup.AddFormDataAction))
            )
                .Start();
        }

        private static void AddFormDataAction(Request request,Response response)
        {
            response.Body = "";

            foreach (var (key,value) in request.Form)
            {
                response.Body += $"{key} - {value}";
                response.Body += Environment.NewLine;
            }
        }
    }
}
