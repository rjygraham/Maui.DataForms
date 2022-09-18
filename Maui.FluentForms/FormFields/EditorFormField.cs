using Maui.FluentForms.Configuration;
using Maui.FluentForms.Validation;

namespace Maui.FluentForms.FormFields;

public sealed class EditorFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public EditorAutoSizeOption AutoSize { get; set; }
    public bool IsTextPredictionEnabled { get; set; }
    public string Placeholder { get; set; }
   
    public EditorFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.Editor, validator)
    {
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (EditorFormFieldConfiguration)configuration;

        AutoSize = typedConfig.AutoSize;
        IsTextPredictionEnabled = typedConfig.IsTextPredictionEnabled;
        Placeholder = typedConfig.Placeholder;
    }
}
