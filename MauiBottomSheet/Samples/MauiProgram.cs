using MauiBottomSheet;
using Microsoft.Extensions.Logging;
using Samples.Views.BottomSheet;
using Simple.MauiBottomSheet;

#if IOS
using MauiBottomSheet.Platforms.iOS;
#elif ANDROID
using MauiBottomSheet.Platforms.Droid;
#endif

namespace Samples;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseBottomSheet()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).RegisterViews();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainPage>();
        mauiAppBuilder.Services.AddTransient<PurshaseBottomSheet>(); // Pages must be registered as transient
        mauiAppBuilder.Services.AddTransient<NotAllowedBottomSheet>(); // Pages must be registered as transient

        return mauiAppBuilder;
    }
}

