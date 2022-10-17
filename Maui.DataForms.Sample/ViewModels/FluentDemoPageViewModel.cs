using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.DataForms.Sample.DataForms;
using Maui.DataForms.Sample.Validators;

namespace Maui.DataForms.Sample.ViewModels;

public partial class FluentDemoPageViewModel : ObservableObject
{
	[ObservableProperty]
	private PersonDataForm personDataForm;

	public FluentDemoPageViewModel()
	{
		PersonDataForm = new PersonDataForm(new Models.Person(), new PersonValidator());
	}

	[RelayCommand]
	private async Task Submit()
	{
		// no-op
	}
}
