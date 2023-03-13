using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VictorFrye.Coldfire.App.Characters;
using VictorFrye.Coldfire.Data.Characters;

namespace VictorFrye.Coldfire.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
#endif
            builder.Services.AddSingleton<IUserDialogService, UserDialogService>();
            builder.Services.AddSingleton<IRestService<Character>, CharacterService>();

            builder.Services.AddTransient<CharactersPage>();
            builder.Services.AddTransient<CharacterViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}