using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace DeKoelkastApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            // Hier de logica om in te loggen, bijv. API-call
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                // Navigeren naar de FridgeSelectionPage
                await Shell.Current.GoToAsync("//FridgeSelectionPage");
            }
            else
            {
                // Foutmelding tonen
                await Application.Current.MainPage.DisplayAlert(
                    "Fout",
                    "Gebruikersnaam of wachtwoord mag niet leeg zijn.",
                    "OK");
            }
        }
    }
}