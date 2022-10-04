namespace Maui.DataForms.Validation;

public interface IPropertyValidator<TProperty>
{
    ValidationResult Validate(TProperty newValue);
}
