using Hamburguesa_EduardoHidalgo.Models;
using Hamburguesa_EduardoHidalgo.Views;

namespace Hamburguesa_EduardoHidalgo.Views;

[QueryProperty(nameof(Item), nameof(Item))]
public partial class BurgerItemPage : ContentPage
{
    //Burger Item = new Burger();
    //Burger aux = new Burger();
    bool _flag;
    public Burger Item
    {
        get => BindingContext as Burger;
        set => BindingContext = value;  
    }

    public BurgerItemPage()
    {      
        InitializeComponent();                
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {
        //if (BindingContext == null)
        //{
        //    Item.Name = nameB.Text;
        //    Item.Description = descB.Text;
        //    Item.WithExtraCheese = _flag;
        //    App.BurgerRepo.AddNewBurger(Item);
        //}
        //else
        //{
            App.BurgerRepo.AddNewBurger(Item);
            await Shell.Current.GoToAsync("..");
        //}
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        if(Item.Id == 0)
        {
            return;
        }
        App.BurgerRepo.deleteBurger(Item);
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

    //private void loadBurger(int id)
    //{
    //    Models.Burger burgerSearch = new Models.Burger();
    //    burgerSearch = App.BurgerRepo.getID(id);
    //    aux = burgerSearch;
    //    BindingContext = burgerSearch;
    //}
}