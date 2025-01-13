using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.ViewModels
{
    public class AddDrinkPageViewModel : BaseViewModel
    {
        private string _drinkName;
        public string DrinkName
        {
            get => _drinkName;
            set => SetProperty(ref _drinkName, value);
        }

        public ICommand AcceptCommand { get; }
        public ICommand CancelCommand { get; }

        public AddDrinkPageViewModel()
        {
            Title = "Drank toevoegen";

            // Initialiseer de commands
            AcceptCommand = new Command(OnAccept);
            CancelCommand = new Command(OnCancel);
        }

        private void OnAccept()
        {
            // Logica voor "Accepteren"
            if (!string.IsNullOrWhiteSpace(DrinkName))
            {
                // Bijvoorbeeld: voeg de drank toe aan een lijst of database
                Console.WriteLine($"Drank toegevoegd: {DrinkName}");
            }
        }

        private void OnCancel()
        {
            // Logica voor "Annuleren"
            Console.WriteLine("Actie geannuleerd");
        }
    }
}