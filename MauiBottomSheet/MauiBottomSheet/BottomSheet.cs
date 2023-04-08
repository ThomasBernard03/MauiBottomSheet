using System;
#if IOS
using BottomSheetView = UIKit.UIViewController;
#elif ANDROID
using BottomSheetView = Google.Android.Material.BottomSheet.BottomSheetDialog;
#endif

namespace MauiBottomSheet;

public partial class BottomSheet
{
    public BottomSheetView View { get; set; }

    public partial void Close(object result = null);

    public partial void OnClose(Action<object> callback);

    public partial void Reduce();

    public partial void Expand();

}
