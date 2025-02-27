﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DeKoelkastApp.Models;
using DeKoelkastApp.Services;
using Supabase;
using Supabase.Postgrest;
using Supabase.Postgrest.Attributes;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public partial class FridgeSelectionPageViewModel : ObservableObject
    {
        // Eigenschap voor ingevoerde naam
        [ObservableProperty]
        private string fridgeName;

        // Eigenschap voor foutmeldingen
        [ObservableProperty]
        private string errorMessage;

        // Geeft aan of de foutmelding zichtbaar is
        [ObservableProperty]
        private bool isErrorVisible;

        public FridgeSelectionPageViewModel()
        {
            // Command voor selectie
            SelectFridgeCommand = new AsyncRelayCommand(SelectFridgeAsync);

            NavigateToSettingsCommand = new RelayCommand(() => NavigateToSettings());
            LogoutCommand = new RelayCommand(() => Logout());
        }

        public IAsyncRelayCommand SelectFridgeCommand { get; }
        public IRelayCommand NavigateToSettingsCommand { get; }
        public IRelayCommand LogoutCommand { get; }

        private async Task SelectFridgeAsync()
        {
            if (string.IsNullOrWhiteSpace(fridgeName))
            {
                ErrorMessage = "Voer een geldige koelkastnaam in.";
                IsErrorVisible = true;
                return;
            }
            try
            {
                // Initialiseer Supabase
                await SupabaseService.InitializeAsync();

                // Zoek naar koelkast op basis van naam
                var response = await SupabaseService.SupabaseClient
                    .From<Models.Fridge>()
                    .Filter("name", Supabase.Postgrest.Constants.Operator.Equals, FridgeName)
                    .Single();

                if (response != null)
                {
                    // Als de koelkast wordt gevonden
                    ErrorMessage = string.Empty;
                    IsErrorVisible = false;

                    await App.Current.MainPage.DisplayAlert("Succes", $"Koelkast '{fridgeName}' geselecteerd!", "OK");

                    // Navigeren naar de MainMenuPage met de geselecteerde fridgeId
                    int selectedFridgeId = response.Id;
                    await App.Current.MainPage.Navigation.PushAsync(new MainMenuPage(selectedFridgeId));
                }
                else
                {
                    // Geen koelkast gevonden
                    ErrorMessage = "Geen koelkast gevonden met deze naam.";
                    IsErrorVisible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Er is een fout opgetreden: {ex.Message}";
                IsErrorVisible = true;
            }
        }

        private async void NavigateToSettings()
        {
            // Logica voor navigeren naar instellingen
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }

        private async void Logout()
        {
            // Logica voor uitloggen
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}