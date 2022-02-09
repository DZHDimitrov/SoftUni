using SUHttpServer.Common;
using SUHttpServer.HTTP;
using SUHttpServer.Responses;
using SUHttpServer.Routing.interfaces;

namespace SUHttpServer.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<Method, Dictionary<string, Func<Request, Response>>> routes;

        public RoutingTable()
        {
            this.routes = new Dictionary<Method, Dictionary<string, Func<Request, Response>>>()
            {
                [Method.GET] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.POST] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.PUT] = new(StringComparer.InvariantCultureIgnoreCase),
                [Method.DELETE] = new(StringComparer.InvariantCultureIgnoreCase),
            };
        }

        public IRoutingTable Map(string url, Method method, Func<Request, Response> responseFunction)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][url] = responseFunction;

            return this;
        }

        public IRoutingTable MapGet(string url, Func<Request, Response> responseFunction) => Map(url, Method.GET, responseFunction);

        public IRoutingTable MapPost(string url, Func<Request, Response> responseFunction) => Map(url, Method.POST, responseFunction);

        public Response MatchRequest(Request request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Url;

            if(!this.routes.ContainsKey(requestMethod) || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[requestMethod][requestUrl];

            return responseFunction(request);
        }
    }
}
