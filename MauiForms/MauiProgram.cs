using Maui.FluentForms;
using Maui.FluentForms.FormFields;
using MauiApp1;
using MauiApp1.Controls;

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
			.MapFormFieldContentControl<DatePickerFormField>(FormFieldNames.DatePicker);

		return builder.Build();
	}
}
