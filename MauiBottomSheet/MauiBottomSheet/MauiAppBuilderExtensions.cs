using System;
using MauiBottomSheet;
using Microsoft.Maui.Hosting;

#if IOS
using MauiBottomSheet.Platforms.iOS;
#elif ANDROID
using MauiBottomSheet.Platforms.Droid;
#endif

namespace Simple.MauiBottomSheet;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseBottomSheet(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IBottomSheetService, BottomSheetService>();


        return builder;
    }
}