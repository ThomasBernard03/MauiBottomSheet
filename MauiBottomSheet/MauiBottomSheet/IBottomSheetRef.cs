using System;
namespace MauiBottomSheet;

public interface IBottomSheetRef
{
    /// <summary>
    /// Bottom sheet instance
    /// </summary>
    BottomSheet BottomSheetRef { get; set; }


    /// <summary>
    /// Method called when bottom sheet appear
    /// </summary>
    /// <param name="parameters">Bottom sheet parameters</param>
    void OnAppearing(object parameters);
}
