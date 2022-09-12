
using MauiForms.Forms.Configuration;
using MauiForms.Forms.Validation;

namespace MauiForms.Forms.FormFields;

public class CheckBoxFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public CheckBoxFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.CheckBox, validator)
    {
    }

    internal override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        // no-op
        return;
    }
}
