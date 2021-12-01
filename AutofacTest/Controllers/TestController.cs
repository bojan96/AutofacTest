using System.Threading.Tasks;
using AutofacTest.MediatR.Request;
using AutofacTest.MediatR.Response;
using AutofacTest.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutofacTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IDelayService _service;
        private readonly IMediator _mediator;

        public TestController(IDelayService service, IMediator mediator)
            => (_service, _mediator) = (service, mediator);

        [HttpGet("delay/{delay}")]
        public async Task<ActionResult> Delay(int delay)
        {
            await _mediator.Send(new DelayRequest { Delay = delay });
            return NoContent();
        }

        [HttpGet("{ipAddress}")]
        public async Task<IpInfoResponse> GetIpInfo(string ipAddress)
        {
            return await _mediator.Send(new IpInfoRequest { IpAddress = ipAddress });
        }
    }
}
