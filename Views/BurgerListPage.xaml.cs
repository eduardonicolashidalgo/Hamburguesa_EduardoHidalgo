using Hamburguesa_EduardoHidalgo.Models;

namespace Hamburguesa_EduardoHidalgo.Views;

public partial class BurgerListPage : ContentPage
{
    public BurgerListPage()
    {
        InitializeComponent();
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }
    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BurgerItemPage));
    }

    private void RefreshData(object sender, EventArgs e)
    {
       List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }
    private async void SelectedItem(object sender, ItemTappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(BurgerListPage));
    }
}