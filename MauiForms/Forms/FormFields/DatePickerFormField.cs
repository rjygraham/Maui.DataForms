using MauiForms.Forms.Configuration;
using MauiForms.Forms.Validation;

namespace MauiForms.Forms.FormFields;

public class DatePickerFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public DateTime MinimumDate { get; set; }
    public DateTime MaximumDate { get; set; }
    public string Format { get; set; }

    public DatePickerFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.DatePicker, validator)
    {
    }

    internal override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfiguration = (DatePickerFormFieldConfiguration)configuration;

        MinimumDate = typedConfiguration.MinimumDate;
        MaximumDate = typedConfiguration.MaximumDate;
        Format = typedConfiguration.Format;
    }
}
