using MauiBottomSheet;
using Microsoft.Extensions.Logging;
using Samples.Views.BottomSheet;

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
        mauiAppBuilder.Services.AddTransient<PurshaseBottomSheet>();
        mauiAppBuilder.Services.AddSingleton<IBottomSheetService, BottomSheetService>();

        return mauiAppBuilder;
    }
}

