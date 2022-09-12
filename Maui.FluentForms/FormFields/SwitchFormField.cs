using Maui.FluentForms.Configuration;
using Maui.FluentForms.Validation;

namespace Maui.FluentForms.FormFields;

public class SwitchFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public SwitchFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.Switch, validator)
    {
    }

    internal override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        // no-op
        return;
    }
}
