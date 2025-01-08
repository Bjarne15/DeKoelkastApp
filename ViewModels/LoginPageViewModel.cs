using System.Windows.Input;

namespace DeKoelkastApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            // Controleer of een NavigationPage wordt gebruikt
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                // Navigeren naar de MainMenuPage
                await navigationPage.PushAsync(new Views.FridgeSelectionPage());
            }
        }
    }
}
