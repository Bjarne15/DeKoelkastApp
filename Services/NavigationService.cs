using System.Threading.Tasks;

namespace DeKoelkastApp.Services
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToAsync(Page page)
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PushAsync(page);
            }
        }
    }
}
