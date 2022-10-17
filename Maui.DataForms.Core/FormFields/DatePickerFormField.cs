using Maui.DataForms.Configuration;
using Maui.DataForms.Validation;

namespace Maui.DataForms.FormFields;

public class DatePickerFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public DateTime MinimumDate { get; set; }
    public DateTime MaximumDate { get; set; }
    public string Format { get; set; }

    public DatePickerFormField(TModel model, string formFieldName, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(model, formFieldName, FormFieldNames.DatePicker, validationMode, validator)
    {
    }

    public DatePickerFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.DatePicker, validationMode, validator)
    {
    }
    public override void ApplyConfiguration(IDictionary<string, object> configuration)
    {
        MinimumDate = configuration.TryGetValue(nameof(MinimumDate), out object minimumDate)
            ? GetDateTime(minimumDate, DateTime.MinValue)
            : DateTime.MinValue;

        MaximumDate = configuration.TryGetValue(nameof(MaximumDate), out object maximumDate)
            ? GetDateTime(maximumDate, DateTime.MaxValue)
            : DateTime.MaxValue;

        Format = configuration.TryGetValue(nameof(Format), out object format)
            ? (string)format
            : "D";
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfiguration = (DatePickerFormFieldConfiguration)configuration;

        MinimumDate = typedConfiguration.MinimumDate;
        MaximumDate = typedConfiguration.MaximumDate;
        Format = typedConfiguration.Format;
    }

    private DateTime GetDateTime(object input, DateTime defaultValue)
    {
        if (input is DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.DateTime;
        }
        else if (input is DateTime dateTime)
        {
            return dateTime;
        }

        return defaultValue;
    }
}
