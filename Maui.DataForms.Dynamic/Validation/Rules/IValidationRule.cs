namespace Maui.DataForms.Validation;

public interface IValidationRule
{
}

public interface IValidationRule<TProperty> : IValidationRule
{
    FormFieldValidationResult Validate(TProperty valueToCompare);
}
