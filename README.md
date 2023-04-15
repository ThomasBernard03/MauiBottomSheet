<p align="center">
  <img width="500" alt="Clipboard logo" src="https://raw.githubusercontent.com/ThomasBernard03/MauiBottomSheet/main/Images/MauiBottomSheetFullLogo.png"/>
</p>

---
<p align="center">
  <a href="https://github.com/ThomasBernard03/MauiBottomSheet/actions/workflows/main.yml">
    <img src="https://github.com/ThomasBernard03/MauiBottomSheet/actions/workflows/main.yml/badge.svg" alt="CI/CD-MauiBottomSheet">
  </a>
  <a href="https://www.nuget.org/packages/Simple.MauiBottomSheet/">
    <img src="https://img.shields.io/nuget/v/Simple.MauiBottomSheet" alt="forthebadge">
  </a>
  <a href="https://www.nuget.org/packages/Simple.MauiBottomSheet/">
    <img src="https://img.shields.io/nuget/dt/Simple.MauiBottomSheet" alt="forthebadge">
  </a>
   <a href="https://www.nuget.org/packages/Simple.MauiBottomSheet/">
    <img src="https://img.shields.io/github/last-commit/thomasbernard03/MauiBottomSheet" alt="forthebadge">
  </a>
</p>


## Presentation 



https://user-images.githubusercontent.com/67638928/230773903-92f329cd-daa0-4d9b-a654-136bdaaea2b3.mp4



## Installation 💿


You can install the latest version of the package with the command 
```shell
dotnet add package Simple.BottomSheet
```
You can also install it manualy in your IDE with the nuget package manager by searching Simple.BottomSheet.


## Configuration ⚙️

Add UseBottomSheet() in your MAUI builder :

```csharp
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .UseBottomSheet(); // Add UseBottomSheet
    return builder.Build();
}
```
      

## Utilisation 🚀

To use a bottom sheet you must proceed as follows:


1) Create your page (Your page must inherit IBottomSheetRef) :
```csharp
public partial class PurshaseBottomSheet : ContentView, IBottomSheetRef
{
  public BottomSheet BottomSheetRef { get; set; }

  public PurshaseBottomSheet()
  {
      InitializeComponent();
  }

  public void OnAppearing(object parameters){ }
}
```


2) Register your page (and viewmodel if you use one) in your IOC container :

```csharp
mauiAppBuilder.Services.AddTransient<PurshaseBottomSheet>(); // Pages must be registered as transient
```


3) Inject IBottomSheetService into your page or viewmodel :

```csharp
public MainPage(IBottomSheetService bottomSheetService)
{
    InitializeComponent();
    _bottomSheetService = bottomSheetService;
}
```


4) Use it ! ⌨️

```csharp
void Button_Clicked(System.Object sender, System.EventArgs e)
{
    var bottomSheet = _bottomSheetService.ShowBottomSheet<PurshaseBottomSheet>();
}
```


## Other 🎈

Feel free to contribute to this project by proposing features and pull requests !
