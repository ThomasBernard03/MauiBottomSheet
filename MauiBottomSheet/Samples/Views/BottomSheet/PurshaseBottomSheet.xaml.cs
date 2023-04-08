using MauiBottomSheet;

namespace Samples.Views.BottomSheet;

public partial class PurshaseBottomSheet : ContentView, IBottomSheetRef
{
    public MauiBottomSheet.BottomSheet BottomSheetRef { get; set; }

    public PurshaseBottomSheet()
	{
		InitializeComponent();
	}


    public void OnAppearing(object parameters)
    {
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        BottomSheetRef.Close("Buy");
    }
}
