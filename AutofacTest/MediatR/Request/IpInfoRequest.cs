using AutofacTest.MediatR.Response;
using MediatR;

namespace AutofacTest.MediatR.Request
{
    public class IpInfoRequest : IRequest<IpInfoResponse>
    {
        public string IpAddress { get; set; }
    }
}
