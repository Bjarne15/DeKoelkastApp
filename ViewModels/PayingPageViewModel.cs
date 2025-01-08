using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public class PayingPageViewModel : BaseViewModel
    {
        public ICommand OkCommand { get; }

        public PayingPageViewModel()
        {
            OkCommand = new Command(OnOkButtonClicked);
        }

        private async void OnOkButtonClicked()
        {
            // Navigatie logica
            await App.Current.MainPage.Navigation.PushAsync(new MainMenuPage());
        }
    }
}