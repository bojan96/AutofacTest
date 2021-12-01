using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutofacTest.MediatR.Request;
using AutofacTest.MediatR.Response;
using MediatR;

namespace AutofacTest.MediatR.Handler
{
    public class IpInfoHandler : IRequestHandler<IpInfoRequest, IpInfoResponse>
    {
        private readonly HttpClient _httpClient;

        public IpInfoHandler(IHttpClientFactory factory)
            => _httpClient = factory.CreateClient("IpInfo");
        public async Task<IpInfoResponse> Handle(IpInfoRequest request, CancellationToken cancellationToken)
        {
            HttpResponseMessage msg = await _httpClient.GetAsync($"json/{request.IpAddress}");
            string body = await msg.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IpInfoResponse>(body,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
