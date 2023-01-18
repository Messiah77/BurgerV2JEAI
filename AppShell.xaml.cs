using BurgerV2JEAI.Views;

namespace BurgerV2JEAI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(JEAIBurgerItemPage), typeof(JEAIBurgerItemPage));
        Routing.RegisterRoute(nameof(JEAIBurgerListPage), typeof(JEAIBurgerListPage));
    }
}
