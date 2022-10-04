﻿using Maui.DataForms.Configuration;
using Maui.DataForms.Validation;

namespace Maui.DataForms.FormFields;

public class StepperFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public double Increment { get; set; }
    public double Minimum { get; set; }
    public double Maximum { get; set; }

    public StepperFormField(TModel model, string formFieldName, ValidationMode validationMode, IModelValidator<TModel> validator = null)
        : base(model, formFieldName, FormFieldNames.Stepper, validationMode, validator)
    {
    }

    public StepperFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, ValidationMode validationMode, IModelValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.Stepper, validationMode, validator)
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
