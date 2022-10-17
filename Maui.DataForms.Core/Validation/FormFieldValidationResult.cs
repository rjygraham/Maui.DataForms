namespace Maui.DataForms.Validation;

public sealed record FormFieldValidationResult(bool IsValid, string[] Errors);