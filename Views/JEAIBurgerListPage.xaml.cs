using BurgerV2JEAI.Models;
namespace BurgerV2JEAI.Views;

public partial class JEAIBurgerListPage : ContentPage
{
	public JEAIBurgerListPage()
	{
		InitializeComponent();
        LoadData();
    }

    protected override void OnAppearing()
    {
        LoadData();
    }

    public void LoadData()
    {
        List<JEAIBurger> burger = App.BurgerRepo.GetAllBurgers();
        BurgerList.ItemsSource = burger;
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(JEAIBurgerItemPage));
    }
    private async void BurgersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var burger = (Models.JEAIBurger)e.CurrentSelection[0];

            string action = await DisplayActionSheet("Escoja una opción:", "Modificar", "Eliminar");

            if (action == "Editar")
            {
                await Shell.Current.GoToAsync($"{nameof(JEAIBurgerItemPage)}?{nameof(JEAIBurgerItemPage.ItemId)}={burger.ID}");
            }
            else if (action == "Borrar")
            {
                App.BurgerRepo.DeleteBurger(burger);
                LoadData();
            }
            else
            {
                LoadData();
            }

            BurgerList.SelectedItem = null;
        }
    }
}