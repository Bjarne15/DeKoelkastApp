using DeKoelkastApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DeKoelkastApp.ViewModels
{
    public class BillPageViewModel : BaseViewModel
    {
        public ICommand PayBillCommand { get; }
        public ICommand PostponeBillCommand { get; }

        public BillPageViewModel()
        {
            Title = "Rekening bekijken";

            // Commands initialiseren
            PayBillCommand = new Command(OnPayBill);
            PostponeBillCommand = new Command(OnPostponeBill);
        }

        private async void OnPayBill()
        {
            // Navigatie naar betalingspagina
            await Shell.Current.GoToAsync(nameof(PaymentPage));
        }

        private async void OnPostponeBill()
        {
            // Navigatie naar uitstelpagina
            await Shell.Current.GoToAsync(nameof(BillPostponePage));
        }
    }
}
