using Maui.DataForms.Configuration;
using Maui.DataForms.Validation;

namespace Maui.DataForms.FormFields;

public class TimePickerFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public string Format { get; set; }

    public TimePickerFormField(TModel model, string formFieldName, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(model, formFieldName, FormFieldNames.TimePicker, validationMode, validator)
    {
    }

    public TimePickerFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.TimePicker, validationMode, validator)
    {
    }

    public override void ApplyConfiguration(IDictionary<string, object> configuration)
    {
        Format = configuration.TryGetValue(nameof(Format), out object format)
            ? (string)format
            : "t";
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (TimePickerFormFieldConfiguration)configuration;

        Format = typedConfig.Format;
    }
}
