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

    public BottomSheet ShowBottomSheet<TView, TViewModel>(bool dimDismiss = true, bool expandable = false, object parameters = null) where TView : View where TViewModel : IBottomSheetRef
    {
        var page = Application.Current.MainPage;
        var bottomSheetContent = _serviceProvider.GetService<TView>();
        var viewModel = _serviceProvider.GetService<TViewModel>();
        bottomSheetContent.BindingContext = viewModel;

        var bottomSheetDialog = new BottomSheetDialog(Platform.CurrentActivity?.Window?.DecorView.FindViewById(Android.Resource.Id.Content)?.RootView?.Context);
        bottomSheetDialog.SetContentView(bottomSheetContent.ToPlatform(page.Handler?.MauiContext ?? throw new Exception("MauiContext is null")));
        bottomSheetDialog.Behavior.Hideable = dimDismiss;
        bottomSheetDialog.Behavior.FitToContents = true;
        bottomSheetDialog.Show();

        var result = new BottomSheet()
        {
            View = bottomSheetDialog
        };

        viewModel.BottomSheetRef = result;
        viewModel.OnAppearing(parameters);

        return result;
    }

    public BottomSheet ShowBottomSheet<TView>(bool dimDismiss = true, bool expandable = false, object parameters = null) where TView : View, IBottomSheetRef
    {
        var page = Application.Current.MainPage;
        var bottomSheetContent = _serviceProvider.GetService<TView>();


        var bottomSheetDialog = new BottomSheetDialog(Platform.CurrentActivity?.Window?.DecorView.FindViewById(Android.Resource.Id.Content)?.RootView?.Context);


        bottomSheetDialog.SetContentView(bottomSheetContent.ToPlatform(page.Handler?.MauiContext ?? throw new Exception("MauiContext is null")));
        bottomSheetDialog.Behavior.Hideable = dimDismiss;
        bottomSheetDialog.Behavior.FitToContents = true;
        bottomSheetDialog.Show();

        var result = new BottomSheet()
        {
            View = bottomSheetDialog
        };

        bottomSheetContent.BottomSheetRef = result;
        bottomSheetContent.OnAppearing(parameters);

        return result;
    }


    public void CloseBottomSheet(object result = null)
    {
        //var bottomSheet = ((Activity)Application.Current.Services.GetRequiredService<IContextProvider>().Context).FindViewById<BottomSheetDialog>(Resource.Id.design_bottom_sheet);
        //bottomSheet?.Dismiss();
    }

    public void CloseBottomSheet(BottomSheet bottomSheet, object result = null)
    {
        var bottomSheetDialog = bottomSheet.View as BottomSheetDialog;
        bottomSheetDialog?.Dismiss();
        bottomSheet.Close(result);
    }

    public BottomSheet ShowBottomSheet<TView, TViewModel>()
        where TView : View
        where TViewModel : IBottomSheetRef
    {
        throw new NotImplementedException();
    }

    public BottomSheet ShowBottomSheet<TView, TViewModel>(BottomSheetOptions options)
        where TView : View
        where TViewModel : IBottomSheetRef
    {
        throw new NotImplementedException();
    }

    public BottomSheet ShowBottomSheet<TView>() where TView : View, IBottomSheetRef
    {
        throw new NotImplementedException();
    }

    public BottomSheet ShowBottomSheet<TView>(BottomSheetOptions options) where TView : View, IBottomSheetRef
    {
        throw new NotImplementedException();
    }
}

