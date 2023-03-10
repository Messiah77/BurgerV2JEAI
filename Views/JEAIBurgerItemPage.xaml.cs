using BurgerV2JEAI.Models;

namespace BurgerV2JEAI.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class JEAIBurgerItemPage : ContentPage
{
    JEAIBurger Item = new JEAIBurger();
    bool _flag;
    public JEAIBurgerItemPage()
	{
		InitializeComponent();
        LoadBurguer();
    }

    public int ItemId
    {
        set { LoadBurguer(value); }
    }

    public void LoadBurguer(int value = -1)
    {
        if (value > -1)
        {
            Item = App.BurgerRepo.GetBurger(value);
            SaveButton.Text = "Editar";
        }

        BindingContext = Item;

    }

    private void Check_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _flag = e.Value;
    }

    private void OnSavedClicked(object sender, EventArgs e)
    {
        Item.Name = NameB.Text;
        Item.Description = DescB.Text;
        Item.WithExtraCheese = _flag;
        if (SaveButton.Text == "Editar")
        {
            App.BurgerRepo.UpadateBurger(Item);
        }
        else
        {
            App.BurgerRepo.AddNewBurger(Item);
        }
        Shell.Current.GoToAsync("..");
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

}