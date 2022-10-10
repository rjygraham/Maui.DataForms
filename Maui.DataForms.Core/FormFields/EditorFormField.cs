using Maui.DataForms.Configuration;
using Maui.DataForms.Validation;

namespace Maui.DataForms.FormFields;

public sealed class EditorFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public EditorAutoSizeOption AutoSize { get; set; }
    public bool IsTextPredictionEnabled { get; set; }
    public string Placeholder { get; set; }

    public EditorFormField(TModel model, string formFieldName, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(model, formFieldName, FormFieldNames.Editor, validationMode, validator)
    {
    }

    public EditorFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.Editor, validationMode, validator)
    {
    }

    public override void ApplyConfiguration(IDictionary<string, object> configuration)
    {
        AutoSize = configuration.TryGetValue(nameof(AutoSize), out object autoSize)
            ? (EditorAutoSizeOption)autoSize
            : EditorAutoSizeOption.Disabled;

        IsTextPredictionEnabled = configuration.TryGetValue(nameof(IsTextPredictionEnabled), out object isTextPredictionEnabled)
            ? (bool)isTextPredictionEnabled
            : true;

        Placeholder = configuration.TryGetValue(nameof(Placeholder), out object placeholder)
            ? (string)placeholder
            : string.Empty;
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (EditorFormFieldConfiguration)configuration;

        AutoSize = typedConfig.AutoSize;
        IsTextPredictionEnabled = typedConfig.IsTextPredictionEnabled;
        Placeholder = typedConfig.Placeholder;
    }
}
