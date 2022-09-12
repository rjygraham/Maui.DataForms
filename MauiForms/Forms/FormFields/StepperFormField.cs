using MauiForms.Forms.Configuration;
using MauiForms.Forms.Validation;

namespace MauiForms.Forms.FormFields;

public class StepperFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public double Increment { get; set; }
    public double Minimum { get; set; }
    public double Maximum { get; set; }

    public StepperFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.Stepper, validator)
    {
    }

    internal override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (StepperFormFieldConfiguration)configuration;

        Increment = typedConfig.Increment;
        Minimum = typedConfig.Minimum;
        Maximum = typedConfig.Maximum;
    }
}
