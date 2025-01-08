using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public class FridgeSelectionPageViewModel : BaseViewModel
    {
        public ICommand NavigateToFridgeCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }
        public ICommand NavigateToLogoutCommand { get; }

        public FridgeSelectionPageViewModel()
        {
            NavigateToFridgeCommand = new Command(async () => await NavigateToFridgeAsync());
            NavigateToSettingsCommand = new Command(async () => await NavigateToSettingsAsync());
            NavigateToLogoutCommand = new Command(async () => await NavigateToLogoutAsync());
        }

        private async Task NavigateToFridgeAsync()
        {
            await Shell.Current.GoToAsync(nameof(MainMenuPage));
        }

        private async Task NavigateToSettingsAsync()
        {
            await Shell.Current.GoToAsync(nameof(SettingsPage));
        }

        private async Task NavigateToLogoutAsync()
        {
            await Shell.Current.GoToAsync(nameof(StartPage));
        }
    }
}