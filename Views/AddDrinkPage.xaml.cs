using DeKoelkastApp.ViewModels;

namespace DeKoelkastApp.Views;

public partial class AddDrinkPage : ContentPage
{
	public AddDrinkPage()
	{
		InitializeComponent();
		BindingContext = new AddDrinkPageViewModel();
	}
}