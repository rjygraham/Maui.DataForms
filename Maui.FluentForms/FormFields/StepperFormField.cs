using Maui.FluentForms.Configuration;
using Maui.FluentForms.Validation;

namespace Maui.FluentForms.FormFields;

public class StepperFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public double Increment { get; set; }
    public double Minimum { get; set; }
    public double Maximum { get; set; }

    public StepperFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.Stepper, validator)
    {
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (StepperFormFieldConfiguration)configuration;

        Increment = typedConfig.Increment;
        Minimum = typedConfig.Minimum;
        Maximum = typedConfig.Maximum;
    }
}
