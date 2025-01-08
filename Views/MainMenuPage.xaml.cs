using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
            var viewModel = new MainMenuPageViewModel();
            viewModel.Navigation = this.Navigation; // Stel de Navigation-property in
            BindingContext = viewModel;
        }
    }
}