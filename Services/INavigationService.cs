using System.Threading.Tasks;

namespace DeKoelkastApp.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync(Page page);
    }
}
