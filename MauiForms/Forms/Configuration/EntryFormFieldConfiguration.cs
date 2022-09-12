using System.Windows.Input;

namespace MauiForms.Forms.Configuration;

public sealed class EntryFormFieldConfiguration : FormFieldConfigurationBase
{
    public ClearButtonVisibility ClearButtonVisibility { get; set; } = ClearButtonVisibility.Never;
    public bool FontAutoScalingEnabled { get; set; } = true;
    public Keyboard Keyboard { get; set; } = Keyboard.Default;
    public bool IsPassword { get; set; } = false;
    public bool IsTextPredictionEnabled { get; set; } = true;
    public string Placeholder { get; set; } = string.Empty;
    public ICommand ReturnCommand { get; set; }
    public object ReturnCommandParameter { get; set; }
    public ReturnType ReturnType { get; set; } = ReturnType.Default;
}
