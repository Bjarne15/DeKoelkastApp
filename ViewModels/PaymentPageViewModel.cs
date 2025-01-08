﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeKoelkastApp.Views;

namespace DeKoelkastApp.ViewModels
{
    public class PaymentPageViewModel : BaseViewModel
    {
        public ICommand PaymentOptionCommand { get; }

        public PaymentPageViewModel()
        {
            PaymentOptionCommand = new Command<string>(OnPaymentOptionSelected);
        }

        private async void OnPaymentOptionSelected(string option)
        {
            // Hier kun je logica toevoegen afhankelijk van de geselecteerde betaaloptie
            if (option == "Bank")
            {
                await Application.Current.MainPage.Navigation.PushAsync(new PayingPage());
            }
            else
            {
                // Andere logica voor andere opties
            }
        }
    }
}