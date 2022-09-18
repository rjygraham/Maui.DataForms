# Maui.FluentForms

This is a proof of concept library for easily creating validable data entry forms in .NET MAUI. This is not published as a Nuget package yet, so please clone locally and add reference to the Maui.FluentForms project to use.

# Example

The included MauiForms sample project illustrates how to use Mail.FluentForms. Below are the highlights.

## Person

The `Person` class represents the underlying data model from which the form will be created.

```csharp
public class Person
{
	public string GivenName { get; set; }
	public string Surname { get; set; }
	public DateTime DateOfBirth { get; set; }
}
```

## PersonValidator

The `PersonValidator` class is the FluentValidation validator used to validate user inputs in our data form. You can use any validation framewwork you wish, just be sure to implement `Maui.FluentForms.Validation.IValidator<TModel>` where `TModel` is the data model class (in this case `Person`) to be validated.

```csharp
public class PersonValidator : AbstractValidator<Person>, Maui.FluentForms.Validation.IValidator<Person>
{
	public PersonValidator()
	{
		RuleFor(r => r.GivenName).NotEmpty().MaximumLength(20);
		RuleFor(r => r.Surname).NotEmpty().MaximumLength(50);
		RuleFor(r => r.DateOfBirth).Must(m => m >= DateTimeOffset.UtcNow.AddYears(-18));
	}

	public bool Validate(Person model, out IDictionary<string, string[]> errors)
	{
		var validationResults = Validate(model);

		if (validationResults.IsValid)
		{
			errors = new Dictionary<string, string[]>();
			return true;
		}

		errors = validationResults.ToDictionary();

		return false;
	}

	public bool Validate(Person model, string memberName, out string[] errors)
	{
		var members = new string[] { memberName };
		var validationContext = new ValidationContext<Person>(model, new PropertyChain(), new MemberNameValidatorSelector(members));

		var validationResults = Validate(validationContext);

		if (validationResults.IsValid)
		{
			errors = Array.Empty<string>();
			return true;
		}

		errors = validationResults.Errors.Select(s => s.ErrorMessage).ToArray();

		return false;
	}
}
```

## PersonForm

The `PersonForm` class is where the UI elements for the data entry form are defined. To build the form, just inherit from `FormBase<TModel>` and then create a constructor which passes the model and validator (optional) instances to the base class and the define your fields using the fluent syntax. Finally call `Build()`

```csharp
public class PersonForm : FormBase<Person>
{
	public PersonForm()
		: base(new Person(), new PersonValidator())
	{
		FieldFor(f => f.GivenName)
			.AsEntry()
			.WithConfiguration(config =>
			{
				config.Placeholder = "First Name";
			})
			.WithLayout(layout =>
			{
				layout.GridColumn = 0;
				layout.GridRow = 0;
			});

		FieldFor(f => f.Surname)
			.AsEntry()
			.WithConfiguration(config =>
			{
				config.Placeholder = "Last Name";
			})
			.WithLayout(layout =>
			{
				layout.GridColumn = 0;
				layout.GridRow = 1;
			});

		FieldFor(f => f.DateOfBirth)
			.AsDatePicker()
			.WithConfiguration(config =>
			{
				config.MinimumDate = DateTimeOffset.UtcNow.AddYears(-18).DateTime;
				config.MaximumDate = DateTimeOffset.UtcNow.DateTime;
			})
			.WithLayout(layout =>
			{
				layout.GridColumn = 0;
				layout.GridRow = 2;
			});

		Build();
	}
}
```

## MainPage.xaml.cs

Set the `BindingContext` to a new instance of `PersonForm`

```csharp
namespace MauiForms;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		BindingContext = new PersonForm();
	}
}
```

## MainPage.xaml

Add the `forms` namespace and then a `Grid` with `BindableLayout.ItemsSource="{Binding Fields}"` which binds to the `Fields` property of the `PersonForm` which was previously set to the `BindingContext`. Finally, set the Forms `BindableLayout.ItemTemplateSelector` to an instance of `FormFieldDataTemplateSelector`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
			 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
			 xmlns:forms="clr-namespace:Maui.FluentForms;assembly=Maui.FluentForms"
			 x:Class="MauiForms.MainPage">

	<ScrollView>
		<Grid RowDefinitions="*,*,*" BindableLayout.ItemsSource="{Binding Fields}" VerticalOptions="Start">
			<BindableLayout.ItemTemplateSelector>
				<forms:FormFieldDataTemplateSelector />
			</BindableLayout.ItemTemplateSelector>
		</Grid>
	</ScrollView>

</ContentPage>
```

## FormField Controls

The FormField controls are defined in the `Controls` folder within the `MauiForms` project. This sample only defines `EntryFormField` and `DatePickerFormField` controls, but you can see how other fields would be created.

## EntryFormField.xaml

At a minimum, you will want to bind `Entry.Text` property to `Value` of the `FormField` and in order to display errors, you will also want to bind `CollectionView.ItemsSource` to `Errors`.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentView xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
			 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
			 x:Class="MauiForms.Controls.EntryFormField"
			 Grid.Row="{Binding GridRow}"
			 Grid.Column="{Binding GridColumn}"
			 Grid.RowSpan="{Binding GridRowSpan}"
			 Grid.ColumnSpan="{Binding GridColumnSpan}">
	<VerticalStackLayout>
		<Entry ClearButtonVisibility="{Binding ClearButtonVisibility}" 
			   FontAutoScalingEnabled="{Binding FontAutoScalingEnabled}" 
			   Keyboard="{Binding Keyboard}" 
			   IsPassword="{Binding IsPassword}" 
			   IsTextPredictionEnabled="{Binding IsTextPredictionEnabled}"
			   Placeholder="{Binding Placeholder}" 
			   ReturnCommand="{Binding ReturnCommand}" 
			   ReturnCommandParameter="{Binding ReturnCommandParameter}" 
			   ReturnType="{Binding ReturnType}" 
			   Text="{Binding Path=Value, Mode=TwoWay}"  />
		<CollectionView ItemsSource="{Binding Errors}">
			<CollectionView.ItemTemplate>
				<DataTemplate>
					<Label Text="{Binding}" TextColor="Red" />
				</DataTemplate>
			</CollectionView.ItemTemplate>
		</CollectionView>
	</VerticalStackLayout>
</ContentView>
```

## MapFormFieldContentControl

You must register your `FormField` controls with `FormFieldDataTemplateSelector` before they can be used. In order to do this, use the `MauiAppBuilder.MapFormFieldContentControl<ContentView>(string templateName)` extension method in `MauiProgram.cs`.

```csharp
using Maui.FluentForms;
using Maui.FluentForms.FormFields;
using MauiForms.Controls;

namespace MauiForms;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.MapFormFieldContentControl<EntryFormField>(FormFieldNames.Entry)
			.MapFormFieldContentControl<DatePickerFormField>(FormFieldNames.DatePicker
			.MapFormFieldContentControl<Controls.CustomFormField>(MauiFormsCustomFormFieldNames.CustomFormField);

		return builder.Build();
	}
}
```

## WithConfiguration()

As shown in the `EntryFormField.xaml` section above, you can set many values of the `Entry` control using `Maui.FluentForms`. These values are set in the `WithConfiguration()` method call when defining your field. The `EntryFormFieldConfiguration.cs` snippet below shows all configuration that can be set for `Entry` controls. 

> By default, `Maui.FluentForms` uses all the control default values for the various properties, so unless you have a specific need to change the default value, you may consider removing the binding from the `FormField` control definition to minimize cycles binding to values which contain the already the property default value.

```csharp
using System.Windows.Input;

namespace Maui.FluentForms.Configuration;

public sealed class EntryFormFieldConfiguration : FormFieldConfigurationBase
{
	public ClearButtonVisibility ClearButtonVisibility { get; set; } = ClearButtonVisibility.Never;
	public bool FontAutoScalingEnabled { get; set; } = true;
	public Keyboard Keyboard { get; set; } = Keyboard.Default;
	public bool IsPassword { get; set; } = false;
	public bool IsTextPredictionEnabled { get; set; } = true;
	public string Placeholder { get; set; } = string.Empty;
	public ICommand ReturnCommand { get; set; }
	public object ReturnCommandParameter { get; set; }
	public ReturnType ReturnType { get; set; } = ReturnType.Default;
}
```

## WithLayout()

This method provides you fine grained control over the placement of the control by allowing you to specify the `Grid.Row`, `Grid.Column`, `Grid.RowSpan`, and `Grid.ColumnSpan` properties. 

## Styling

Since styling is something unique to every application and can vary greatly across controls, `Maui.FluentForms` doesn't provide any options to provide styling and instead encourages developers to use styles set in the application resource dictionary.

# Customization

Every application is different and therefore data entry forms may require input controls beyond those built into .NET MAUI. For this reason, `Maui.FluentForms` allows custom FormFields to be defined.

For the time being, in liue of documentation please review the the code inside the `CustomFormField` folder of the `MauiForms` project.