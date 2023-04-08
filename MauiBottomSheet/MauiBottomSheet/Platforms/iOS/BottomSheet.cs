using System;
using Microsoft.Maui.Platform;

namespace MauiBottomSheet;

public partial class BottomSheet
{
    private Action<object> _onCloseCallback;


    public partial void Close(object result = null)
    {
        View?.DismissViewController(true, () =>
        {
            _onCloseCallback?.Invoke(result);
        });
    }

    public partial void OnClose(Action<object> callback)
    {
        _onCloseCallback = callback;
    }

    public partial void Reduce()
    {
        var sheet = View.SheetPresentationController;

        sheet.AnimateChanges(() =>
        {
            sheet.SelectedDetentIdentifier = UIKit.UISheetPresentationControllerDetentIdentifier.Medium;
        });
    }

    public partial void Expand()
    {
        var sheet = View.SheetPresentationController;

        sheet.AnimateChanges(() =>
        {
            sheet.SelectedDetentIdentifier = UIKit.UISheetPresentationControllerDetentIdentifier.Large;
        });
    }
}