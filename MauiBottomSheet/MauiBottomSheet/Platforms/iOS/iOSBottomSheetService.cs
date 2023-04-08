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

    public BottomSheet ShowBottomSheet<TView, TViewModel>(bool dimDismiss = true, bool expandable = false, object parameters = null) where TView : View where TViewModel : IBottomSheetRef
    {
        var bottomSheetView = _serviceProvider.GetService<TView>();
        var viewModel = _serviceProvider.GetService<TViewModel>();

        bottomSheetView.BindingContext = viewModel;

        var page = Application.Current.MainPage;
        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext is null");
        var viewController = page.ToUIViewController(mauiContext);
        var viewControllerToPresent = bottomSheetView.ToUIViewController(mauiContext);

        var sheet = viewControllerToPresent.SheetPresentationController;
        if (sheet is not null)
        {
            // All bottom sheet properties : https://www.youtube.com/watch?v=oJU4RvZcxWo

            sheet.Detents = expandable ? _detents : _detents.Take(1).ToArray(); // Control all detents of bottom sheet large or medium
            sheet.PrefersScrollingExpandsWhenScrolledToEdge = false; // Can scrool in bottom sheet view
            sheet.PrefersGrabberVisible = expandable; // Add top indicator in bottom sheet
            sheet.PreferredCornerRadius = 24; // Corner raduis of our bottom sheet
            sheet.LargestUndimmedDetentIdentifier = dimDismiss ? UISheetPresentationControllerDetentIdentifier.Unknown : UISheetPresentationControllerDetentIdentifier.Medium; // Can close outside to close bottom sheet



            //sheet.PrefersEdgeAttachedInCompactHeight = false; // Must test this property
            //sheet.WidthFollowsPreferredContentSizeWhenEdgeAttached = true; // Must test this property
        }

        viewController.PresentViewController(viewControllerToPresent, animated: true, null);

        var instance = new BottomSheet()
        {
            View = viewControllerToPresent
        };

        viewModel.BottomSheetRef = instance;
        viewModel.OnAppearing(parameters);

        return instance;
    }

    public BottomSheet ShowBottomSheet<TView>(bool dimDismiss = true, bool expandable = false, object parameters = null) where TView : View, IBottomSheetRef
    {
        var bottomSheetView = _serviceProvider.GetService<TView>();

        var page = Application.Current.MainPage;
        var mauiContext = page.Handler?.MauiContext ?? throw new Exception("MauiContext is null");
        var viewController = page.ToUIViewController(mauiContext);
        var viewControllerToPresent = bottomSheetView.ToUIViewController(mauiContext);

        var sheet = viewControllerToPresent.SheetPresentationController;
        if (sheet is not null)
        {
            // All bottom sheet properties : https://www.youtube.com/watch?v=oJU4RvZcxWo

            sheet.Detents = expandable ? _detents : _detents.Take(1).ToArray(); // Control all detents of bottom sheet large or medium
            sheet.PrefersScrollingExpandsWhenScrolledToEdge = false; // Can scrool in bottom sheet view
            sheet.PrefersGrabberVisible = expandable; // Add top indicator in bottom sheet
            sheet.PreferredCornerRadius = 24; // Corner raduis of our bottom sheet
            sheet.LargestUndimmedDetentIdentifier = dimDismiss ? UISheetPresentationControllerDetentIdentifier.Unknown : UISheetPresentationControllerDetentIdentifier.Medium; // Can close outside to close bottom sheet



            //sheet.PrefersEdgeAttachedInCompactHeight = false; // Must test this property
            //sheet.WidthFollowsPreferredContentSizeWhenEdgeAttached = true; // Must test this property
        }

        viewController.PresentViewController(viewControllerToPresent, animated: true, null);

        var instance = new BottomSheet()
        {
            View = viewControllerToPresent
        };

        bottomSheetView.BottomSheetRef = instance;
        bottomSheetView.OnAppearing(parameters);

        return instance;
    }

    public void CloseBottomSheet(object result = null)
    {
        var bottomSheet = UIApplication.SharedApplication.KeyWindow.RootViewController;
        bottomSheet.DismissViewController(true, null);
    }

    public void CloseBottomSheet(BottomSheet bottomSheet, object result = null)
    {
        var viewControllerToDismiss = bottomSheet.View;
        if (viewControllerToDismiss != null)
        {
            viewControllerToDismiss.DismissViewController(true, () => {
                bottomSheet.Close(result);
            });
        }
    }
}


