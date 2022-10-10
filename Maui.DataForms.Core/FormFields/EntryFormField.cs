using Maui.DataForms.Configuration;
using Maui.DataForms.Validation;
using System.Windows.Input;

namespace Maui.DataForms.FormFields;

public class EntryFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public ClearButtonVisibility ClearButtonVisibility { get; set; }
    public bool FontAutoScalingEnabled { get; set; }
    public Keyboard Keyboard { get; set; }
    public bool IsPassword { get; set; }
    public bool IsTextPredictionEnabled { get; set; }
    public string Placeholder { get; set; }
    public ICommand ReturnCommand { get; set; }
    public object ReturnCommandParameter { get; set; }
    public ReturnType ReturnType { get; set; }

    public EntryFormField(TModel model, string formFieldName, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(model, formFieldName, FormFieldNames.Entry, validationMode, validator)
    {
    }

    public EntryFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
    : base(model, memberName, getter, setter, FormFieldNames.Entry, validationMode, validator)
    {
    }

    public override void ApplyConfiguration(IDictionary<string, object> configuration)
    {
        ClearButtonVisibility = configuration.TryGetValue(nameof(ClearButtonVisibility), out object clearButtonVisibility)
            ? (ClearButtonVisibility)clearButtonVisibility
            : ClearButtonVisibility.Never;

        FontAutoScalingEnabled = configuration.TryGetValue(nameof(FontAutoScalingEnabled), out object fontAutoScalingEnabled)
            ? (bool)fontAutoScalingEnabled
            : true;

        Keyboard = configuration.TryGetValue(nameof(Keyboard), out object keyboard)
            ? (Keyboard)keyboard
            : Keyboard.Default;

        IsPassword = configuration.TryGetValue(nameof(IsPassword), out object isPassword)
            ? (bool)isPassword
            : false;

        IsTextPredictionEnabled = configuration.TryGetValue(nameof(IsTextPredictionEnabled), out object isTextPredictionEnabled)
            ? (bool)isTextPredictionEnabled
            : true;

        Placeholder = configuration.TryGetValue(nameof(Placeholder), out object placeholder)
            ? (string)placeholder
            : string.Empty;

        ReturnCommand = configuration.TryGetValue(nameof(ReturnCommand), out object returnCommand)
            ? (ICommand)returnCommand
            : null;

        ReturnCommandParameter = configuration.TryGetValue(nameof(ReturnCommandParameter), out object returnCommandParameter)
            ? returnCommandParameter
            : null;

        ReturnType = configuration.TryGetValue(nameof(ReturnType), out object returnType)
            ? (ReturnType)returnType
            : ReturnType.Default;
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (EntryFormFieldConfiguration)configuration;

        ClearButtonVisibility = typedConfig.ClearButtonVisibility;
        FontAutoScalingEnabled = typedConfig.FontAutoScalingEnabled;
        Keyboard = typedConfig.Keyboard;
        IsPassword = typedConfig.IsPassword;
        IsTextPredictionEnabled = typedConfig.IsTextPredictionEnabled;
        Placeholder = typedConfig.Placeholder;
        ReturnCommand = typedConfig.ReturnCommand;
        ReturnCommandParameter = typedConfig.ReturnCommandParameter;
        ReturnType = typedConfig.ReturnType;
    }
}
