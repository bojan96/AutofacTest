using System.Threading;
using System.Threading.Tasks;
using AutofacTest.MediatR.Request;
using AutofacTest.MediatR.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AutofacTest.MediatR.Behavior
{
    public class LogIpInfoResponseBehavior : IPipelineBehavior<IpInfoRequest, IpInfoResponse>
    {
        private readonly ILogger<LogIpInfoResponseBehavior> _logger;
        public LogIpInfoResponseBehavior(ILogger<LogIpInfoResponseBehavior> logger)
            => _logger = logger;
        public async Task<IpInfoResponse> Handle(IpInfoRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<IpInfoResponse> next)
        {
            IpInfoResponse response = await next();
            _logger.LogInformation($"{request.IpAddress} location: {response.City}, {response.Country}");
            return response;
        }
    }
}
