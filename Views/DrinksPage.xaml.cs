using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class DrinksPage : ContentPage
    {
        private DrinksPageViewModel _viewModel;

        public DrinksPage(int fridgeId)
        {
            InitializeComponent();
            _viewModel = new DrinksPageViewModel(fridgeId);
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadProductsCommand.Execute(null);
        }
    }
}