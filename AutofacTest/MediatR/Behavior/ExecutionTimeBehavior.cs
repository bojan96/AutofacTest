using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AutofacTest.MediatR.Behavior
{
    public class ExecutionTimeBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ExecutionTimeBehavior<TRequest, TResponse>> _logger;

        public ExecutionTimeBehavior(ILogger<ExecutionTimeBehavior<TRequest, TResponse>> logger)
            => _logger = logger;
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            TResponse response = await next();
            _logger.LogInformation($"Elapsed time for {request.GetType().Name}: {stopwatch.ElapsedMilliseconds}ms");
            return response;
        }
    }
}
