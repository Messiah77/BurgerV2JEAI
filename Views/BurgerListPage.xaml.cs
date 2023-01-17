using BurgerV2JEAI.Models;
namespace BurgerV2JEAI.Views;

public partial class BurgerListPage : ContentPage
{
	public BurgerListPage()
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
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        BurgerList.ItemsSource = burger;
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BurgerItemPage));
    }
    private async void BurgersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var burger = (Models.Burger)e.CurrentSelection[0];

            string action = await DisplayActionSheet("Seleccione la acción que desea realizar:", "Cancel", null, "Editar", "Borrar");

            if (action == "Editar")
            {
                await Shell.Current.GoToAsync($"{nameof(BurgerItemPage)}?{nameof(BurgerItemPage.ItemId)}={burger.ID}");
            }
            else if (action == "Borrar")
            {
                App.BurguerRepo.DeleteBurguer(burger);
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