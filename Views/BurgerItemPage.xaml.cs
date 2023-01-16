using Hamburguesa_EduardoHidalgo.Models;

namespace Hamburguesa_EduardoHidalgo.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class BurgerItemPage : ContentPage
{
    Burger Item = new Burger();
    Burger aux = new Burger();
    bool _flag;
    public int ItemId
    {
        set { loadBurger(value);          
    }

    }
    public BurgerItemPage()

    {
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        //burgerList.ItemsSource = burger;        
        InitializeComponent();                
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        if (BindingContext == null)
        {
            Item.Name = nameB.Text;
            Item.Description = descB.Text;
            Item.WithExtraCheese = _flag;
            App.BurgerRepo.AddNewBurger(Item);
        }
        else
        {
            App.BurgerRepo.updateData(aux.Id, aux.Name, aux.Description, aux.WithExtraCheese);
            await Shell.Current.GoToAsync("..");
        }
    }

    private void OnDeleteClicked(int id)
    {
        App.BurgerRepo.deleteBurger(id);
        Shell.Current.GoToAsync("..");
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {   
        _flag = e.Value;
    }

    private void loadBurger(int id)
    {
        Models.Burger burgerSearch = new Models.Burger();
        burgerSearch = App.BurgerRepo.getID(id);
        aux = burgerSearch;
        BindingContext = burgerSearch;
    }
}