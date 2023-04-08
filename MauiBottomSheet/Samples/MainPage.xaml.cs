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

		var bottomSheet = _bottomSheetService.ShowBottomSheet<PurshaseBottomSheet>(expandable:true);


		bottomSheet.OnClose(result =>
		{
			Console.WriteLine(result);
		});
    }
}