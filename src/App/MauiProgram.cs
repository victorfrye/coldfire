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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<CharactersPage>();
            builder.Services.AddTransient<CharacterViewModel>();
            builder.Services.AddSingleton<IService<Character>, CharacterService>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}