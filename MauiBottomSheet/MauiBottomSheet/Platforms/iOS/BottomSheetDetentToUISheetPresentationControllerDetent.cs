using System;
using UIKit;

namespace MauiBottomSheet.Platforms.iOS;

public static class BottomSheetDetentToUISheetPresentationControllerDetent
{
    public static UISheetPresentationControllerDetent[] Transform(this IEnumerable<BottomSheetDetent> detents)
    {
        return detents.Select(detent =>
        {
            switch (detent)
            {
                case BottomSheetDetent.Small:
                    return UISheetPresentationControllerDetent.Create("small detent", sheet => 120);
                case BottomSheetDetent.Medium:
                    return UISheetPresentationControllerDetent.CreateMediumDetent();
                default:
                    return UISheetPresentationControllerDetent.CreateLargeDetent();
            }
        }).ToArray() ;
    }
}

