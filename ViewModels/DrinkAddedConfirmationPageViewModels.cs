using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public class DrinkAddedConfirmationViewModel : BaseViewModel
    {
        private int _fridgeId;

        public ICommand GoToMainMenuCommand { get; }

        public DrinkAddedConfirmationViewModel(int fridgeId)
        {
            _fridgeId = fridgeId;
            GoToMainMenuCommand = new Command(async () => await NavigateToMainMenu());
        }

        private async Task NavigateToMainMenu()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MainMenuPage(_fridgeId));
        }
    }
}