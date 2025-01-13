using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class PayingPage : ContentPage
    {
        private PayingPageViewModel _viewModel;

        public PayingPage(int fridgeId)
        {
            InitializeComponent();
            _viewModel = new PayingPageViewModel(fridgeId);
            BindingContext = _viewModel;
        }
    }
}