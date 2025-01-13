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
        private int _fridgeId;

        public ICommand OkCommand { get; }

        public PayingPageViewModel(int fridgeId)
        {
            _fridgeId = fridgeId;
            OkCommand = new Command(OnOkButtonClicked);
        }

        private async void OnOkButtonClicked()
        {
            // Navigatie logica
            await App.Current.MainPage.Navigation.PushAsync(new MainMenuPage(_fridgeId));
        }
    }
}