﻿namespace MonkeysApp;

using MonkeysApp.Services;
using MonkeysApp.ViewModels;
using MonkeysApp.Views;

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

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
        builder.Services.AddSingleton<IMap>(Map.Default);

        builder.Services.AddSingleton<MonkeyService>();
        builder.Services.AddSingleton<MonkeyViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<MonkeyDetailsViewModel>();
        builder.Services.AddTransient<DetailsView>();
        builder.Services.AddTransient<MonkeysView>();


        return builder.Build();
	}
}
