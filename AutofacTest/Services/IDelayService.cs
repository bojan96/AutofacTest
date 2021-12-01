using System.Threading.Tasks;

namespace AutofacTest.Services
{
    public interface IDelayService
    {
        Task Delay(int delay);
    }
}
