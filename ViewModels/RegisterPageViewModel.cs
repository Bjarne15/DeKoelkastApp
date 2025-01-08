using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        public ICommand AcceptCommand { get; }

        public RegisterPageViewModel()
        {
            AcceptCommand = new AsyncRelayCommand(OnAcceptAsync);
        }

        private async Task OnAcceptAsync()
        {
            // Navigatie naar de volgende pagina
            await Shell.Current.GoToAsync(nameof(FridgeSelectionPage));
        }
    }
}
