using MauiBottomSheet;
using Microsoft.Extensions.DependencyInjection;
using Samples.Views.BottomSheet;

namespace Samples;

public partial class MainPage : ContentPage
{
	int count = 0;

	private readonly IBottomSheetService _bottomSheetService;

	public MainPage(IBottomSheetService bottomSheetService)
	{
		InitializeComponent();
		_bottomSheetService = bottomSheetService;
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		var options = new BottomSheetOptions()
		{
			Radius = 24,
			Detent = BottomSheetDetent.Small,
			Detents = new List<BottomSheetDetent>() { BottomSheetDetent.Large, BottomSheetDetent.Medium }
		};

		var bottomSheet = _bottomSheetService.ShowBottomSheet<PurshaseBottomSheet>(options) ;


		bottomSheet.OnClose(result =>
		{
			Console.WriteLine(result);
		});
    }

    void NotAllowedButton_Clicked(System.Object sender, System.EventArgs e)
    {

        var options = new BottomSheetOptions()
        {
            Radius = 0,
            Detent = BottomSheetDetent.Small,
            Detents = new List<BottomSheetDetent>() { BottomSheetDetent.Small }
        };

        var bottomSheet = _bottomSheetService.ShowBottomSheet<NotAllowedBottomSheet>(options);
    }

    void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var options = new BottomSheetOptions()
        {
            Radius = 8,
            Detent = BottomSheetDetent.Medium,
            Detents = new List<BottomSheetDetent>() { BottomSheetDetent.Small, BottomSheetDetent.Medium, BottomSheetDetent.Large }
        };

        var bottomSheet = _bottomSheetService.ShowBottomSheet<PurshaseBottomSheet>(options);
    }

    void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        var options = new BottomSheetOptions()
        {
            Radius = 24,
            Detent = BottomSheetDetent.Large,
            Detents = new List<BottomSheetDetent>() { BottomSheetDetent.Large }
        };

        var bottomSheet = _bottomSheetService.ShowBottomSheet<PurshaseBottomSheet>(options);
    }
}