using Android.App;
using Android.Content.PM;
using Android.OS;
using System.Diagnostics;

namespace MauiSoftKeyboard.Droid;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Platform.Init(this, savedInstanceState);

        //Platform.CurrentActivity.Window.DecorView.ViewTreeObserver.AddOnGlobalLayoutListener(new MauiSoftKeyboard.Droid.Services.SoftKeyboardService());
    }
}
