namespace MauiSoftKeyboard.iOS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseSharedMauiApp()
                .ConfigureEffects(effects =>
                {
                    effects.Add<MauiSoftKeyboard.Effects.KeyboardEnableEffect, MauiSoftKeyboard.iOS.Effects.KeyboardEnableEffect>();
                });

        return builder.Build();
	}
}
