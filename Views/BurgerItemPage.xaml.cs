using Hamburguesa_EduardoHidalgo.Models;
using Hamburguesa_EduardoHidalgo.Views;

namespace Hamburguesa_EduardoHidalgo.Views;

[QueryProperty(nameof(Item), nameof(Item))]
public partial class BurgerItemPage : ContentPage
{
    bool _flag;
    public Burger Item
    {
        get => BindingContext as Burger;
        set => BindingContext = value;  
    }

    public BurgerItemPage()
    {      
        InitializeComponent();
        TimerB.Text = DateTime.Today.ToString();
    }
    private async void OnSaveClicked(object sender, EventArgs e)
    {          
            App.BurgerRepo.AddNewBurger(Item);
            await Shell.Current.GoToAsync("..");
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

    
}