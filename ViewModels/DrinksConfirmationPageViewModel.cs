using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeKoelkastApp.ViewModels
{
    public class DrinksConfirmationPageViewModel : BaseViewModel
    {
        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public DrinksConfirmationPageViewModel()
        {
            OkCommand = new Command(async () => await OnOkClickedAsync());
            CancelCommand = new Command(async () => await OnCancelClickedAsync());
        }

        private async Task OnOkClickedAsync()
        {
            // Navigatie naar het hoofdmenu
            await Shell.Current.GoToAsync("//MainMenuPage");
        }

        private async Task OnCancelClickedAsync()
        {
            // Navigatie naar de drank keuze pagina
            await Shell.Current.GoToAsync("//DrinksPage");
        }
    }
}