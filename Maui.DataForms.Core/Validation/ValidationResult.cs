namespace Maui.DataForms.Validation;

public sealed class ValidationResult
{
    public bool IsValid { get; init; }
    public string[] Errors { get; init; } = Array.Empty<string>();
}
