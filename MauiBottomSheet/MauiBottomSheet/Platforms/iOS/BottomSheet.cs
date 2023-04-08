using System;
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
}