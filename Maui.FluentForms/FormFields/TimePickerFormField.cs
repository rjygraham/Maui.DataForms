using Maui.FluentForms.Configuration;
using Maui.FluentForms.Validation;

namespace Maui.FluentForms.FormFields;

public class TimePickerFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public string Format { get; set; }

    public TimePickerFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.TimePicker, validator)
    {
    }

    internal override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (TimePickerFormFieldConfiguration)configuration;

        Format = typedConfig.Format;
    }
}
