using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public class DrinksPageViewModel : BaseViewModel
    {
        public ICommand ReturnToMainMenuCommand { get; }

        public DrinksPageViewModel()
        {
            ReturnToMainMenuCommand = new Command(async () => await NavigateToMainMenu());
        }

        private async Task NavigateToMainMenu()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MainMenuPage());
        }
    }
}