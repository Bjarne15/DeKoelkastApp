using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class FridgeSelectionPage : ContentPage
    {
        private FridgeSelectionPageViewModel _viewModel;

        public FridgeSelectionPage()
        {
            InitializeComponent();
            _viewModel = new FridgeSelectionPageViewModel();
            BindingContext = _viewModel;
        }
    }
}