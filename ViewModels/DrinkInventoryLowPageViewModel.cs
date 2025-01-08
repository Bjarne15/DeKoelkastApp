using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DeKoelkastApp.ViewModels
{
    public partial class DrinkInventoryLowPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string notificationMessage;

        public DrinkInventoryLowPageViewModel()
        {
            // Stel de standaard melding in
            NotificationMessage = "De betreffende drank is bijna op! Hiervan moet bijgevuld worden.";
        }

        [RelayCommand]
        private async Task NavigateToMainMenu()
        {
            // Navigatie naar het hoofdmenu
            await Shell.Current.GoToAsync("//MainMenuPage");
        }
    }
}