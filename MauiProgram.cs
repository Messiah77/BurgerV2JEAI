using BurgerV2JEAI.Data;

namespace BurgerV2JEAI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        string dbPath = FileAccessHelper.GetLocalFilePath("burguer.db3");
        builder.Services.AddSingleton<JEAIBurgerDatabase>(s => ActivatorUtilities.CreateInstance<JEAIBurgerDatabase>(s, dbPath));
        return builder.Build();
	}
}
