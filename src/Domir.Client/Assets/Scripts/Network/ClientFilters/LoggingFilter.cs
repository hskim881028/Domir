using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Domir.Client.Infrastructure;
using MagicOnion.Client;

namespace Domir.Client.Network.ClientFilters
{
    public class LoggingFilter : IClientFilter
    {
        public async ValueTask<ResponseContext> SendAsync(
            RequestContext context,
            Func<RequestContext, ValueTask<ResponseContext>> next)
        {
            ZLog.Request(context);
            var sw = Stopwatch.StartNew();
            var response = await next(context);
            sw.Stop();
            ZLog.Response(context.MethodPath, sw.Elapsed.TotalMilliseconds, response);
            return response;
        }
    }
}