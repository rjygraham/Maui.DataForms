namespace MauiForms;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = new PersonForm();
	}
}

