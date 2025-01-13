using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class PaymentPage : ContentPage
    {
        private PaymentPageViewModel _viewModel;

        public PaymentPage(int fridgeId)
        {
            InitializeComponent();
            _viewModel = new PaymentPageViewModel(fridgeId);
            BindingContext = _viewModel;
        }
    }
}