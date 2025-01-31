using Microsoft.Extensions.Logging;
using System.Net.Http;
using BadgerClanControls.ViewModels;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Maui;
using BadgerClanControls.Services;

namespace BadgerClanControls
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).UseMauiCommunityToolkit()
            .RegisterViewModels();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            string baseAddress = "http://localhost:5160";
            builder.Services.AddSingleton<IApiService, ApiService>();
            builder.Services.AddHttpClient("GameControllerApi", client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            });
            return builder.Build();
        }
        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainViewModel>();
            return builder;
        }
    }
}