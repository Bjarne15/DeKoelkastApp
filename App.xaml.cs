using DeKoelkastApp.Views;

namespace DeKoelkastApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage()); // Startpagina als eerste pagina instellen.
        }
    }
}
