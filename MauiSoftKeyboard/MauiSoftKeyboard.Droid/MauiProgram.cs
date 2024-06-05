namespace MauiSoftKeyboard.Droid;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseSharedMauiApp()
            .ConfigureEffects(effects =>
            {
                effects.Add<MauiSoftKeyboard.Effects.KeyboardEnableEffect, MauiSoftKeyboard.Droid.Effects.KeyboardEnableEffect>();
            });

        return builder.Build();
    }
}
