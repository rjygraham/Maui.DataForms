using Maui.DataForms.Configuration;
using Maui.DataForms.Validation;

namespace Maui.DataForms.FormFields;

public class DatePickerFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public DateTime MinimumDate { get; set; }
    public DateTime MaximumDate { get; set; }
    public string Format { get; set; }

    public DatePickerFormField(TModel model, string formFieldName, ValidationMode validationMode, IModelValidator<TModel> validator = null)
        : base(model, formFieldName, FormFieldNames.DatePicker, validationMode, validator)
    {
    }

    public DatePickerFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, ValidationMode validationMode, IModelValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.DatePicker, validationMode, validator)
    {
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfiguration = (DatePickerFormFieldConfiguration)configuration;

        MinimumDate = typedConfiguration.MinimumDate;
        MaximumDate = typedConfiguration.MaximumDate;
        Format = typedConfiguration.Format;
    }
}
