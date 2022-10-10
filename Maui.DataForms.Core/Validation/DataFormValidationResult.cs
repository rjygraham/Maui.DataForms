namespace Maui.DataForms.Validation;

public sealed record DataFormValidationResult(bool IsValid, IDictionary<string, string[]> Errors);