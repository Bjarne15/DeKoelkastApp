using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Supabase;
using DeKoelkastApp.Models;


namespace DeKoelkastApp.Services
{
    public static class SupabaseService
    {
        public static Client SupabaseClient { get; private set; }

        public static async Task InitializeAsync()
        {
            if (SupabaseClient == null)
            {
                var options = new Supabase.SupabaseOptions
                {
                    AutoConnectRealtime = true
                };

                SupabaseClient = new Supabase.Client(
                    "https://sntqwfvigxjyhpzvrbco.supabase.co",
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InNudHF3ZnZpZ3hqeWhwenZyYmNvIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzMyMjk4NjMsImV4cCI6MjA0ODgwNTg2M30.AwM9u7UdtHFB6NhNFtXUhnVqRXxPM4NHuzBeXTYpW4Q",
                    options
                );
                await SupabaseClient.InitializeAsync();
            }
        }

        public static async Task<Fridge> GetFridgeByNameAsync(string fridgeName)
        {
            var result = await SupabaseClient
                .From<Fridge>()
                .Filter("name", Supabase.Postgrest.Constants.Operator.Equals, fridgeName)
                .Single();
            return result;
        }

        public static async Task<List<(Product, int)>> GetProductsByFridgeAsync(int fridgeId)
        {
            var fridgeStocks = await SupabaseClient
                .From<Fridge>()
                .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, fridgeId)
                .Get();

            var productsWithStock = new List<(Product, int)>();

            foreach (var fridgeStock in fridgeStocks.Models)
            {
                var product = await SupabaseClient
                    .From<Product>()
                    .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, fridgeStock.ProductId)
                    .Single();

                productsWithStock.Add((product, fridgeStock.Stock));
            }

            Console.WriteLine($"Fetched {productsWithStock.Count} products for fridge ID {fridgeId}");
            return productsWithStock;
        }
    }
}