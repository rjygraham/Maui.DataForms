﻿using MauiApp1;
using MauiApp1.Controls;
using MauiForms.Forms;
using MauiForms.Forms.FormFields;

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
