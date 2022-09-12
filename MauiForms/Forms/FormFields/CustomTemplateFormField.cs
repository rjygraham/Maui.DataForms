using MauiForms.Forms.Configuration;
using MauiForms.Forms.Validation;

namespace MauiForms.Forms.FormFields;

public class CustomTemplateFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public CustomTemplateFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, string fieldTemplateName, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, fieldTemplateName, validator)
    {
    }

    internal override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (CustomTemplateFormFieldConfiguration)configuration;
    }
}
