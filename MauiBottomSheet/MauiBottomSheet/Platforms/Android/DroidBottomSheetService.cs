using System;
using Google.Android.Material.BottomSheet;
using Microsoft.Maui.Platform;

namespace MauiBottomSheet.Platforms.Droid;

public class BottomSheetService : IBottomSheetService
{
    private readonly IServiceProvider _serviceProvider;

    public BottomSheetService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public BottomSheet ShowBottomSheet<TView, TViewModel>()
        where TView : View
        where TViewModel : IBottomSheetRef
    {
        return ShowBottomSheet<TView, TViewModel>(new BottomSheetOptions());
    }

    public BottomSheet ShowBottomSheet<TView, TViewModel>(BottomSheetOptions options)
        where TView : View
        where TViewModel : IBottomSheetRef
    {
        var view = _serviceProvider.GetService<TView>();
        var viewModel = _serviceProvider.GetService<TViewModel>();
        view.BindingContext = viewModel;

        return ShowBottomSheet(view, options, viewModel);
    }

    public BottomSheet ShowBottomSheet<TView>()
        where TView : View, IBottomSheetRef
    {
        return ShowBottomSheet<TView>(new BottomSheetOptions());
    }

    public BottomSheet ShowBottomSheet<TView>(BottomSheetOptions options)
        where TView : View, IBottomSheetRef
    {
        var view = _serviceProvider.GetService<TView>();

        return ShowBottomSheet(view, options, view);
    }

    private BottomSheet ShowBottomSheet(View view, BottomSheetOptions options, IBottomSheetRef bottomSheetRef)
    {
        var page = Application.Current.MainPage;
        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext is null");

        var bottomSheetDialog = new BottomSheetDialog(Platform.CurrentActivity?.Window?.DecorView.FindViewById(Android.Resource.Id.Content)?.RootView?.Context);
        bottomSheetDialog.SetContentView(view.ToPlatform(mauiContext));
        //bottomSheetDialog.Behavior.Hideable = options.Detent == BottomSheetDetent.Dismissible;
        //bottomSheetDialog.Behavior.FitToContents = true;
        bottomSheetDialog.Show();

        var result = new BottomSheet()
        {
            View = bottomSheetDialog
        };

        bottomSheetRef.BottomSheetRef = result;
        bottomSheetRef.OnAppearing(options.Parameters);

        return result;
    }

    public void CloseBottomSheet(object result = null)
    {
        throw new NotImplementedException("Not implented for android");
    }
}

