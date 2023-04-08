using MauiBottomSheet;

namespace Samples.Views.BottomSheet;

public partial class NotAllowedBottomSheet : ContentView, IBottomSheetRef
{
	public NotAllowedBottomSheet()
	{
		InitializeComponent();
	}

    public MauiBottomSheet.BottomSheet BottomSheetRef { get; set; }

    public void OnAppearing(object parameters)
    {
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        BottomSheetRef.Close("Page closed");
    }
}
