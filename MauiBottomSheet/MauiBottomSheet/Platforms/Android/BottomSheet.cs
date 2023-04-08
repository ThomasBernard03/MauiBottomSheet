using System;
using Google.Android.Material.BottomSheet;

namespace MauiBottomSheet;

public partial class BottomSheet
{
    private Action<object> _onCloseCallback;

    public partial void Close(object result = null)
    {
        var bottomSheetDialog = View as BottomSheetDialog;
        bottomSheetDialog?.Dismiss();
        _onCloseCallback?.Invoke(result);
    }

    public partial void OnClose(Action<object> callback)
    {
        _onCloseCallback = callback;
    }

    public partial void Reduce()
    {
        throw new NotImplementedException("");
    }

    public partial void Expand()
    {
        throw new NotImplementedException("");
    }
}