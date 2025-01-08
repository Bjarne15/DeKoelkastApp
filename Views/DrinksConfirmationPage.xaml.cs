using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class DrinksConfirmationPage : ContentPage
    {
        public DrinksConfirmationPage()
        {
            InitializeComponent();
            BindingContext = new DrinksConfirmationPageViewModel();
        }
    }
}