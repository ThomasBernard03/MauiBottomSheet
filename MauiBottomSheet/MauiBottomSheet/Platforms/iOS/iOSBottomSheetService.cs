using System;
using Microsoft.Maui.Platform;
using UIKit;

namespace MauiBottomSheet.Platforms.iOS;

public class BottomSheetService : IBottomSheetService
{
    private readonly IServiceProvider _serviceProvider;

    private UISheetPresentationControllerDetent[] _detents = new[]
    {
        UISheetPresentationControllerDetent.Create("small detent", sheet => 120),
        UISheetPresentationControllerDetent.CreateMediumDetent(),
        UISheetPresentationControllerDetent.CreateLargeDetent(),
    };

    public BottomSheetService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public BottomSheet ShowBottomSheet<TView, TViewModel>(bool dismissable = true, bool expandable = false, object parameters = null) where TView : View where TViewModel : IBottomSheetRef
    {
        var bottomSheetView = _serviceProvider.GetService<TView>();
        var viewModel = _serviceProvider.GetService<TViewModel>();
        bottomSheetView.BindingContext = viewModel;

        var viewControllerToPresent = GetViewControllerToPresent(bottomSheetView);
        ConfigureSheet(viewControllerToPresent.SheetPresentationController, dismissable, expandable);

        PresentViewController(viewControllerToPresent);

        return CreateBottomSheetInstance(viewControllerToPresent, viewModel, parameters);
    }

    public BottomSheet ShowBottomSheet<TView>(bool dismissable = true, bool expandable = false, object parameters = null) where TView : View, IBottomSheetRef
    {
        var bottomSheetView = _serviceProvider.GetService<TView>();

        var viewControllerToPresent = GetViewControllerToPresent(bottomSheetView);
        ConfigureSheet(viewControllerToPresent.SheetPresentationController, dismissable, expandable);

        PresentViewController(viewControllerToPresent);

        return CreateBottomSheetInstance(viewControllerToPresent, bottomSheetView, parameters);
    }

    private UIViewController GetViewControllerToPresent(View view)
    {
        var page = Application.Current.MainPage;
        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext is null");
        return view.ToUIViewController(mauiContext);
    }

    private void ConfigureSheet(UISheetPresentationController sheet, bool dismissable, bool expandable)
    {
        if (sheet is not null)
        {
            sheet.Detents = expandable ? _detents : _detents.Take(1).ToArray();
            sheet.PrefersScrollingExpandsWhenScrolledToEdge = false;
            sheet.PrefersGrabberVisible = expandable;
            sheet.PreferredCornerRadius = 24;
            sheet.LargestUndimmedDetentIdentifier = dismissable ? UISheetPresentationControllerDetentIdentifier.Large : UISheetPresentationControllerDetentIdentifier.Medium;
        }
    }

    private void PresentViewController(UIViewController viewControllerToPresent)
    {
        var page = Application.Current.MainPage;
        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext is null");
        var viewController = page.ToUIViewController(mauiContext);

        viewController.PresentViewController(viewControllerToPresent, animated: true, null);
    }

    private BottomSheet CreateBottomSheetInstance<T>(UIViewController viewController, T bottomSheetRef, object parameters) where T : IBottomSheetRef
    {
        var instance = new BottomSheet()
        {
            View = viewController
        };

        bottomSheetRef.BottomSheetRef = instance;
        bottomSheetRef.OnAppearing(parameters);

        return instance;
    }

    public void CloseBottomSheet(object result = null)
    {
        var bottomSheet = UIApplication.SharedApplication.KeyWindow.RootViewController;
        bottomSheet.DismissViewController(true, null);
    }
}


