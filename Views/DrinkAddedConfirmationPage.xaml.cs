using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class DrinkAddedConfirmationPage : ContentPage
    {
        private DrinkAddedConfirmationViewModel _viewModel;

        public DrinkAddedConfirmationPage(int fridgeId)
        {
            InitializeComponent();
            _viewModel = new DrinkAddedConfirmationViewModel(fridgeId);
            BindingContext = _viewModel;
        }
    }
}