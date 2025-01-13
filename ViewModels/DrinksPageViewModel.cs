using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DeKoelkastApp.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeKoelkastApp.Services;

namespace DeKoelkastApp.ViewModels
{
    public class DrinksPageViewModel : ObservableObject
    {
        public ObservableCollection<(Product, int)> ProductsWithStock { get; set; } = new ObservableCollection<(Product, int)>();

        private int _fridgeId;

        public DrinksPageViewModel()
        {
            LoadProductsCommand = new AsyncRelayCommand(LoadProducts);
        }

        public DrinksPageViewModel(int fridgeId) : this()
        {
            _fridgeId = fridgeId;
        }

        public IAsyncRelayCommand LoadProductsCommand { get; }

        private async Task LoadProducts()
        {
            await SupabaseService.InitializeAsync();
            var productsWithStock = await SupabaseService.GetProductsByFridgeAsync(_fridgeId);
            ProductsWithStock.Clear();
            foreach (var productWithStock in productsWithStock)
            {
                ProductsWithStock.Add(productWithStock);
            }
            Console.WriteLine($"Loaded {ProductsWithStock.Count} products into the view model");
        }
    }
}