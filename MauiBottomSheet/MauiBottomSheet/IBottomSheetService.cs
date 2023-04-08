using System;
namespace MauiBottomSheet;

public interface IBottomSheetService
{

    BottomSheet ShowBottomSheet<TView, TViewModel>() where TView : View where TViewModel : IBottomSheetRef;
    BottomSheet ShowBottomSheet<TView, TViewModel>(BottomSheetOptions options) where TView : View where TViewModel : IBottomSheetRef;

    BottomSheet ShowBottomSheet<TView>() where TView : View, IBottomSheetRef;
    BottomSheet ShowBottomSheet<TView>(BottomSheetOptions options) where TView : View, IBottomSheetRef;

    void CloseBottomSheet(object result = null);
}
