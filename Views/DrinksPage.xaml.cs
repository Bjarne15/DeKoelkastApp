using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class DrinksPage : ContentPage
    {
        public DrinksPage()
        {
            InitializeComponent();
            BindingContext = new DrinksPageViewModel();
        }
    }
}