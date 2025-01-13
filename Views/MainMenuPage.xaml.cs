using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class MainMenuPage : ContentPage
    {
        private MainMenuPageViewModel _viewModel;

        public MainMenuPage(int fridgeId)
        {
            InitializeComponent();
            _viewModel = new MainMenuPageViewModel(fridgeId);
            BindingContext = _viewModel;
            _viewModel.Navigation = Navigation;
        }
    }
}