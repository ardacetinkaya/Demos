using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace HelloMvcApi
{
    public class CustomAuth
    {
        private readonly RequestDelegate _next;

        public CustomAuth(RequestDelegate next, ILoggerFactory loggerFactory)
        {

            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            

            if (context.Request.Headers.ContainsKey("CustomKey"))
            { 
                int number=3;
                var key = context.Request.Headers["CustomKey"];
                if (string.IsNullOrEmpty(key) || key != "HelloWorld")
                {
                    context.Response.StatusCode = 401; //Unauthorized
                    await context.Response.WriteAsync("You can not access this resource!");
                    return;
                }
            }

            await _next.Invoke(context);
  
        }
    }
}