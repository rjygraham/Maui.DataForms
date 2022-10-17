using Maui.DataForms.Sample.ViewModels;

namespace Maui.DataForms.Sample.Views;

public partial class FluentDemoPage : ContentPage
{
	public FluentDemoPage(FluentDemoPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}