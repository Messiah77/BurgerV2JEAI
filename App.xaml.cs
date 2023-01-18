using BurgerV2JEAI.Data;

namespace BurgerV2JEAI;

public partial class App : Application
{
	public static JEAIBurgerDatabase BurgerRepo { get; set; }
	public App(JEAIBurgerDatabase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		BurgerRepo = repo;
	}
}
