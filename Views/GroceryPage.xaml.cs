

using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class GroceryPage : ContentPage
    {
        public GroceryPage()
        {
            InitializeComponent();
            BindingContext = new GroceryPageViewModel();
        }
    }
}