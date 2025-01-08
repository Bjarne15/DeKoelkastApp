using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public class GroceryPageViewModel : BaseViewModel
    {
        public ICommand OKCommand { get; }

        public GroceryPageViewModel()
        {
            OKCommand = new Command(OnOKClicked);
        }

        private async void OnOKClicked()
        {
            // Navigatie terug naar het hoofdmenu
            await Shell.Current.GoToAsync("//MainMenuPage");
        }
    }
}