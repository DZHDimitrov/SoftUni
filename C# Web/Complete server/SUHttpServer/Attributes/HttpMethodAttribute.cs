using SUHttpServer.HTTP;

namespace SUHttpServer.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class HttpMethodAttribute : Attribute
    {
        public Method HttpMethod { get; }

        protected HttpMethodAttribute(Method httpMethod)
            => this.HttpMethod = httpMethod;
    }
}
