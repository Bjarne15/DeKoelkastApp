using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class FridgeSelectionPage : ContentPage
    {
        public FridgeSelectionPage()
        {
            InitializeComponent();
            BindingContext = new FridgeSelectionPageViewModel();
        }
    }
}