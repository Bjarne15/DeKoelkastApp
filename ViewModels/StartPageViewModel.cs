using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public class StartPageViewModel : BaseViewModel
    {
        public ICommand NavigateToRegisterPageCommand { get; }
        public ICommand NavigateToLoginPageCommand { get; }

        public StartPageViewModel()
        {
            NavigateToRegisterPageCommand = new Command(async () => await NavigateToRegisterPage());
            NavigateToLoginPageCommand = new Command(async () => await NavigateToLoginPage());
        }

        private async Task NavigateToRegisterPage()
        {
            // Navigatie naar de RegisterPage
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private async Task NavigateToLoginPage()
        {
            // Navigatie naar de LoginPage
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }
    }
}
