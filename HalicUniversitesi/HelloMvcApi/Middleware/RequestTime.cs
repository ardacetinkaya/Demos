using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HelloMvcApi
{
    public class RequestTime
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestTime(RequestDelegate next, ILoggerFactory loggerFactory)
        {

            _next = next;
            _logger = loggerFactory.CreateLogger<RequestTime>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogDebug("[Custom MidlleWare]Handling request: " + context.Request.Path);
            var watch = new Stopwatch();
            watch.Start();

            await _next.Invoke(context);
            var milliSeconds = watch.ElapsedMilliseconds.ToString();
            _logger.LogDebug($"[Custom MidlleWare]Finished handling request. -> {milliSeconds}ms.");
        }
    }
}