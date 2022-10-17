namespace Maui.DataForms.Configuration;

public sealed class DatePickerFormFieldConfiguration : FormFieldConfigurationBase
{
    public DateTime MinimumDate { get; set; } = DateTime.MinValue;
    public DateTime MaximumDate { get; set; } = DateTime.MaxValue;
    public string Format { get; set; } = "D";
}
