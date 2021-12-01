using System.Threading;
using System.Threading.Tasks;
using AutofacTest.MediatR.Request;
using AutofacTest.Services;
using MediatR;

namespace AutofacTest.MediatR.Handler
{
    public class DelayHandler : AsyncRequestHandler<DelayRequest>
    {
        private readonly IDelayService _delayService;

        public DelayHandler(IDelayService delayService)
            => _delayService = delayService;

        protected async override Task Handle(DelayRequest request, CancellationToken cancellationToken)
        {
            await _delayService.Delay(request.Delay);
        }
    }
}
