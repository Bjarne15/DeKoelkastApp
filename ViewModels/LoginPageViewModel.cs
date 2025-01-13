using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Supabase;
using DeKoelkastApp.Models;
using DeKoelkastApp.Services;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public partial class LoginPageViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private bool _isBusy;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => await LoginUserAsync(), () => !IsBusy);
        }

        private async Task LoginUserAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Fout", "Vul zowel gebruikersnaam als wachtwoord in.", "OK");
                return;
            }

            try
            {
                IsBusy = true;

                // Supabase initialiseren
                await SupabaseService.InitializeAsync();

                // Gebruiker ophalen
                var response = await SupabaseService.SupabaseClient.From<User>()
                    .Filter("username", Supabase.Postgrest.Constants.Operator.Equals, Username)
                    .Filter("password", Supabase.Postgrest.Constants.Operator.Equals, Password) // Zonder passwordHash
                    .Get();

                var user = response.Models.FirstOrDefault();

                if (user != null)
                {
                    // Opslaan van sessiegegevens (optioneel)
                    Preferences.Set("user_id", user.Id);

                    // Navigeren naar de volgende pagina
                    await App.Current.MainPage.Navigation.PushAsync(new FridgeSelectionPage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Fout", "Gebruikersnaam of wachtwoord is onjuist.", "OK");
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Fout", $"Er ging iets mis: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
