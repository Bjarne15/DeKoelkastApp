using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace DeKoelkastApp.ViewModels
{
    public class BillPostponePageViewModel : BaseViewModel
    {
        public ICommand NavigateToMainMenuCommand { get; }

        public BillPostponePageViewModel()
        {
            NavigateToMainMenuCommand = new AsyncRelayCommand(NavigateToMainMenu);
        }

        private async Task NavigateToMainMenu()
        {
            // Navigatie naar MainMenuPage
            await Shell.Current.GoToAsync("//MainMenuPage");
        }
    }
}