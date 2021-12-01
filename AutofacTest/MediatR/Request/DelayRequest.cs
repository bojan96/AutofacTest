using MediatR;

namespace AutofacTest.MediatR.Request
{
    public class DelayRequest : IRequest
    {
        public int Delay { get; set; }
    }
}
