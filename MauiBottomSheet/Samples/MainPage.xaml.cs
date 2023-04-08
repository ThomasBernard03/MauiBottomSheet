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
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		var options = new BottomSheetOptions()
		{
			Radius = 0,
			Detent = BottomSheetDetent.Large,
			Detents = new List<BottomSheetDetent>() { BottomSheetDetent.Large, BottomSheetDetent.Small }
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
            Radius = 24,
            Detent = BottomSheetDetent.Small,
            Detents = new List<BottomSheetDetent>() { BottomSheetDetent.Small, BottomSheetDetent.Medium, BottomSheetDetent.Large }
        };


        var bottomSheet = _bottomSheetService.ShowBottomSheet<PurshaseBottomSheet>(options);
    }
}