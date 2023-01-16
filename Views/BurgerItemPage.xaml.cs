using Hamburguesa_EduardoHidalgo.Models;

namespace Hamburguesa_EduardoHidalgo.Views;

public partial class BurgerItemPage : ContentPage
{
    Burger Item = new Burger();
    String _flag;
    public BurgerItemPage()
    {
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        //burgerList.ItemsSource = burger;        
        InitializeComponent();                
    }
    private void OnSaveClicked(object sender, EventArgs e)
    {
        Item.Name = nameB.Text;
        Item.Description = descB.Text;
        Item.WithExtraCheese = _flag;
        App.BurgerRepo.AddNewBurger(Item);
        Shell.Current.GoToAsync("..");
    }

    private void OnDeleteClicked(object sender, EventArgs e)
    {
        App.BurgerRepo.DeleteBurger(Item);
        Shell.Current.GoToAsync("..");
    }
    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {       
        if(e.Value == true)
        {
            _flag = "Tiene queso";
        }
        _flag = "No tiene queso";
        //_flag = e.Value;
    }
}