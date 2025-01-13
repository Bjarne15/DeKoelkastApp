using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeKoelkastApp.Views;
using Microsoft.IdentityModel.Tokens;
using Supabase;
using DeKoelkastApp.Models;
using DeKoelkastApp.Services;

namespace DeKoelkastApp.ViewModels
{
    public partial class RegisterPageViewModel : INotifyPropertyChanged
    {
        private string _fullName;
        private string _username;
        private string _password;
        private bool _isBusy;

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

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

        public ICommand RegisterCommand { get; }

        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterUserAsync(), () => !IsBusy);
        }

        private async Task RegisterUserAsync()
        {
            if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await App.Current.MainPage.DisplayAlert("Fout", "Alle velden moeten worden ingevuld.", "OK");
                return;
            }

            try
            {
                IsBusy = true;

                // Initialiseer Supabase-service
                await SupabaseService.InitializeAsync();

                // Maak nieuwe gebruiker aan
                var newUser = new User
                {
                    FullName = FullName,
                    Username = Username,
                    Password = Password, // Overweeg wachtwoord-hashing voor veiligheid
                    CreatedAt = DateTime.UtcNow
                };

                // 1. Registreer de gebruiker
                await SupabaseService.SupabaseClient.From<User>().Insert(newUser);

                // 2. Toon een succesmelding
                await App.Current.MainPage.DisplayAlert("Succes", "Registratie voltooid!", "OK");

                // 3. Zoek de gebruiker die net is geregistreerd (automatisch inloggen)
                var loginResponse = await SupabaseService.SupabaseClient.From<User>()
                    .Filter("username", Supabase.Postgrest.Constants.Operator.Equals, Username)
                    .Filter("password", Supabase.Postgrest.Constants.Operator.Equals, Password) // Gebruik hashing!
                    .Get();

                var loginResult = loginResponse.Models.FirstOrDefault();



                if (loginResult != null)
                {
                    // 4. Opslaan van sessiegegevens (optioneel)
                    Preferences.Set("user_id", loginResult.Id);

                    // 5. Navigeer naar FridgeSelectionPage
                    await App.Current.MainPage.Navigation.PushAsync(new FridgeSelectionPage());
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Fout", "Inloggen mislukt. Probeer opnieuw.", "OK");
                }

                // Velden resetten na succesvolle registratie
                FullName = string.Empty;
                Username = string.Empty;
                Password = string.Empty;
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
