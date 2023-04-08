using System;
namespace MauiBottomSheet;

public class BottomSheetOptions
{
	public BottomSheetOptions()
	{
	}


	public int Radius { get; set; }
	public IEnumerable<BottomSheetDetent> Detents { get; set; }
	public BottomSheetDetent Detent { get; set; }
	public object Parameters { get; set; }
}

