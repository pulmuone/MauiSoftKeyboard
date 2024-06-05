using Foundation;
using UIKit;

namespace MauiSoftKeyboard.iOS;

[Register(nameof(AppDelegate))]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
       

        return base.FinishedLaunching(app, options);
    }
    
}
