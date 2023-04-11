using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Hosting;
using ViewModel;

namespace MyfirstMauiApp;

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

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<MainPage>();


		return builder.Build();
	}
}
