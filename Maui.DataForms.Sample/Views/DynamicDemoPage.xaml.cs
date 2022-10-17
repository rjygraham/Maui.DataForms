using Maui.DataForms.Sample.ViewModels;

namespace Maui.DataForms.Sample.Views;

public partial class DynamicDemoPage : ContentPage
{
	public DynamicDemoPage(DynamicDemoPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}