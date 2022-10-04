using Maui.DataForms.Configuration;
using Maui.DataForms.Validation;

namespace Maui.DataForms.FormFields;

public class SwitchFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public SwitchFormField(TModel model, string formFieldName, ValidationMode validationMode, IModelValidator<TModel> validator = null)
        : base(model, formFieldName, FormFieldNames.Switch, validationMode, validator)
    {
    }

    public SwitchFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, ValidationMode validationMode, IModelValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.Switch, validationMode, validator)
    {
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        // no-op
        return;
    }
}
