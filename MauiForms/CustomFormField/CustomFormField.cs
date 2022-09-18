using Maui.FluentForms.Configuration;
using Maui.FluentForms.FormFields;
using Maui.FluentForms.Validation;

namespace MauiForms.CustomFormField;

public class CustomFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public string CustomProperty { get; set; }

    public CustomFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, MauiFormsCustomFormFieldNames.CustomFormField, validator)
    {
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfiguration = (CustomFormFieldConfiguration)configuration;

        CustomProperty = typedConfiguration.CustomProperty;
    }
}
