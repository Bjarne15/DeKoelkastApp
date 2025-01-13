using DeKoelkastApp.Views;
using DeKoelkastApp.Services;

namespace DeKoelkastApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage()); // Startpagina als eerste pagina instellen.
        }
        protected override async void OnStart()
        {
            await SupabaseService.InitializeAsync();
        }

    }
}
