using Maui.DataForms.FormFields;

namespace Maui.DataForms.Controls;

public static class AppHostBuilderExtensions
{
    public static MauiAppBuilder UseDefaultFormFieldContentControls(this MauiAppBuilder builder)
    {
        return builder
            .MapFormFieldContentControl<CheckBoxFormFieldControl>(FormFieldNames.CheckBox)
            .MapFormFieldContentControl<DatePickerFormFieldControl>(FormFieldNames.DatePicker)
            .MapFormFieldContentControl<EditorFormFieldControl>(FormFieldNames.Editor)
            .MapFormFieldContentControl<EntryFormFieldControl>(FormFieldNames.Entry)
            .MapFormFieldContentControl<SliderFormFieldControl>(FormFieldNames.Slider)
            .MapFormFieldContentControl<StepperFormFieldControl>(FormFieldNames.Stepper)
            .MapFormFieldContentControl<SwitchFormFieldControl>(FormFieldNames.Switch)
            .MapFormFieldContentControl<TimePickerFormFieldControl>(FormFieldNames.TimePicker);
    }
}
