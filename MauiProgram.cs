using Microsoft.Extensions.Logging;
using DeKoelkastApp.Views;
using DeKoelkastApp.Services;

namespace DeKoelkastApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Registratie van Services
            builder.Services.AddSingleton<StartPage>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
