using Microsoft.Extensions.Logging;
using FeelingCards.ViewModels;

namespace FeelingCards;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("DejaVuSans.ttf", "DejaVuSans");
				fonts.AddFont("DejaVuSans-Bold.ttf", "DejaVuSansBold");
			});

		builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
