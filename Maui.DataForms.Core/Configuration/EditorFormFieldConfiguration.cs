namespace Maui.DataForms.Configuration;

public sealed class EditorFormFieldConfiguration : FormFieldConfigurationBase
{
    public EditorAutoSizeOption AutoSize { get; set; } = EditorAutoSizeOption.Disabled;
    public bool IsTextPredictionEnabled { get; set; } = true;
    public Keyboard Keyboard { get; set; } = Keyboard.Default;
    public string Placeholder { get; set; } = string.Empty;
}
