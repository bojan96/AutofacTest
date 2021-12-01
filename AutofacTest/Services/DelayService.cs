using System.Threading.Tasks;

namespace AutofacTest.Services
{
    public class DelayService : IDelayService
    {
        public async Task Delay(int delay)
        {
            await Task.Delay(delay);
        }
    }
}
