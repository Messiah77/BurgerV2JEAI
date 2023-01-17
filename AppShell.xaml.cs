using BurgerV2JEAI.Views;

namespace BurgerV2JEAI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(BurgerItemPage), typeof(BurgerItemPage));
        Routing.RegisterRoute(nameof(BurgerListPage), typeof(BurgerListPage));
    }
}
