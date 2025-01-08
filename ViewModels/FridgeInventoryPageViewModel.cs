using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DeKoelkastApp.ViewModels
{
    public class FridgeInventoryViewModel : INotifyPropertyChanged
    {
        private string _welcomeText = "Welcome to .NET MAUI!";

        public string WelcomeText
        {
            get => _welcomeText;
            set
            {
                _welcomeText = value;
                OnPropertyChanged();
            }
        }

        public FridgeInventoryViewModel()
        {
            // Initialiseer hier eventuele logica of data
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}