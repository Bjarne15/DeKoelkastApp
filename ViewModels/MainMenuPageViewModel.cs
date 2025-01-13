using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public class MainMenuPageViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; } // Navigation-property wordt hier ingesteld

        private int _fridgeId;

        public ICommand OpenDrinksPageCommand { get; }
        public ICommand OpenAddDrinkPageCommand { get; }
        public ICommand OpenBillPageCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ChooseOtherFridgeCommand { get; }
        public ICommand ShowInventoryCommand { get; }

        public MainMenuPageViewModel(int fridgeId)
        {
            _fridgeId = fridgeId;
            OpenDrinksPageCommand = new Command(async () => await NavigateToDrinksPage());
            OpenAddDrinkPageCommand = new Command(async () => await NavigateToAddDrinkPage());
            OpenBillPageCommand = new Command(async () => await NavigateToBillPage());
            LogoutCommand = new Command(async () => await Logout());
            ChooseOtherFridgeCommand = new Command(async () => await ChooseOtherFridge());
            ShowInventoryCommand = new Command(async () => await ShowInventory());
        }

        private async Task NavigateToDrinksPage()
        {
            if (Navigation != null)
                await Navigation.PushAsync(new DrinksPage(_fridgeId));
        }

        private async Task NavigateToAddDrinkPage()
        {
            if (Navigation != null)
                await Navigation.PushAsync(new AddDrinkPage());
        }

        private async Task NavigateToBillPage()
        {
            if (Navigation != null)
                await Navigation.PushAsync(new BillPage());
        }

        private async Task Logout()
        {
            if (Navigation != null)
                await Navigation.PopToRootAsync();
        }

        private async Task ChooseOtherFridge()
        {
            if (Navigation != null)
                await Navigation.PopAsync();
        }

        private async Task ShowInventory()
        {
            if (Navigation != null)
                await Navigation.PushAsync(new FridgeInventoryPage());
        }
    }
}