using Maui.DataForms.Configuration;
using Maui.DataForms.Validation;

namespace Maui.DataForms.FormFields;

public class CheckBoxFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public CheckBoxFormField(TModel model, string formFieldName, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(model, formFieldName, FormFieldNames.CheckBox, validationMode, validator)
    {
    }

    public CheckBoxFormField(TModel model, string formFieldName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(model, formFieldName, getter, setter, FormFieldNames.CheckBox, validationMode, validator)
    {
    }

    public override void ApplyConfiguration(IDictionary<string, object> configuration)
    {
        // no-op
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        // no-op
    }
}
