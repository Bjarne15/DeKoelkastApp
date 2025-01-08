using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace DeKoelkastApp.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public ICommand LogoutCommand { get; }
        public ICommand BackToFridgeSelectionCommand { get; }

        public SettingsPageViewModel()
        {
            LogoutCommand = new Command(OnLogout);
            BackToFridgeSelectionCommand = new Command(OnBackToFridgeSelection);
        }

        private async void OnLogout()
        {
            // Navigatie naar StartPage
            await Application.Current.MainPage.Navigation.PushAsync(new Views.StartPage());
        }

        private async void OnBackToFridgeSelection()
        {
            // Navigatie naar FridgeSelectionPage
            await Application.Current.MainPage.Navigation.PushAsync(new Views.FridgeSelectionPage());
        }
    }
}
