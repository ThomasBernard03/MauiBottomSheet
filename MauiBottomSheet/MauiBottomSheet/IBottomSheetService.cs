using System;
namespace MauiBottomSheet;

public interface IBottomSheetService
{
    /// <summary>
    /// Open a bottom sheet instance. The View and the ViewModel MUST be registered in ServiceProvider.
    /// </summary>
    /// <typeparam name="TView">The current view displayed by the bottom sheet</typeparam>
    /// <typeparam name="TViewModel">The Binding context of the view</typeparam>
    /// <param name="dismissable"></param>
    /// <param name="expandable"></param>
    /// <param name="parameters"></param>
    /// <returns>A BottomSheet instance</returns>
    BottomSheet ShowBottomSheet<TView, TViewModel>(bool dismissable = true, bool expandable = false, object parameters = null) where TView : View where TViewModel : IBottomSheetRef;


    /// <summary>
    /// Open a bottom sheet instance. The View MUST be registered in ServiceProvider.
    /// </summary>
    /// <typeparam name="TView"></typeparam>
    /// <param name="dismissable"></param>
    /// <param name="expandable"></param>
    /// <param name="parameters">A bottom sheet instance</param>
    /// <returns></returns>
    BottomSheet ShowBottomSheet<TView>(bool dismissable = true, bool expandable = false, object parameters = null) where TView : View, IBottomSheetRef;


    /// <summary>
    /// Close the current bottom sheet
    /// </summary>
    /// <param name="result">The result</param>
    void CloseBottomSheet(object result = null);
}
