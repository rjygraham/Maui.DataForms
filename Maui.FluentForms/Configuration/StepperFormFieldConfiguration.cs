namespace Maui.FluentForms.Configuration;

public sealed class StepperFormFieldConfiguration : FormFieldConfigurationBase
{
    public double Increment { get; set; } = 1;
    public double Minimum { get; set; } = 0;
    public double Maximum { get; set; } = 100;
}
