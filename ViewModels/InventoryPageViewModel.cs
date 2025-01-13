using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeKoelkastApp.ViewModels
{
    public class InventoryPageViewModel : BaseViewModel
    {
        private string _welcomeText;

        public string WelcomeText
        {
            get => _welcomeText;
            set => SetProperty(ref _welcomeText, value);
        }

        public InventoryPageViewModel()
        {
            WelcomeText = "Welcome to .NET MAUI!";
        }
    }
}