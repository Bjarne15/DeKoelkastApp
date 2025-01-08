using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DeKoelkastApp.ViewModels
{
    public partial class DrinkAddedConfirmationViewModel : ObservableObject
    {
        public DrinkAddedConfirmationViewModel()
        {
            // Constructor voor eventuele initialisatie
        }

        [RelayCommand]
        private async Task GoToMainMenu()
        {
            // Navigatie naar het hoofdmenu
            await App.Current.MainPage.Navigation.PushAsync(new Views.MainMenuPage());
        }
    }
}