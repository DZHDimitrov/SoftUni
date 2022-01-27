using SUHttpServer.HTTP;
using SUHttpServer.Routing;
using SUHttpServer.Routing.interfaces;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SUHttpServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        private readonly RoutingTable routingTable;

        public HttpServer(string _ipAddress, int _port,Action<IRoutingTable> routingTableConfiguration)
        {
            this.ipAddress = IPAddress.Parse(_ipAddress);
            this.port = _port;

            serverListener = new TcpListener(ipAddress, port);

            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTable) : this("127.0.0.1", port, routingTable)
        {

        }

        public HttpServer(Action<IRoutingTable> routingTable) : this(5000, routingTable)
        {

        }

        public async Task Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server is listening on port {port}");
            Console.WriteLine("Listening for requests");

            while (true)
            {
                var connection = await serverListener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                {
                    var networkStream = connection.GetStream();

                    string strRequest = await ReadRequest(networkStream);


                    Console.WriteLine(strRequest);

                    var request = Request.Parse(strRequest);

                    var response = this.routingTable.MatchRequest(request);

                    if (response.PreRenderAction != null)
                    {
                        response.PreRenderAction(request, response);
                    }

                    AddSession(request, response);

                    await WriteResponse(networkStream, response);

                    connection.Close();
                });
            }
        }

        private async Task WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            byte[] buffer = new byte[1024];
            StringBuilder request = new StringBuilder();
            int totalBytes = 0;
            do
            {
                int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large");
                }

                request.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (networkStream.DataAvailable);

            return request.ToString();
        }

        private static void AddSession(Request request,Response response)
        {
            var sessionExists = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            if (!sessionExists)
            {
                request.Session[Session.SessionCurrentDateKey] = DateTime.Now.ToString();

                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);
            }
        }
    }
}
