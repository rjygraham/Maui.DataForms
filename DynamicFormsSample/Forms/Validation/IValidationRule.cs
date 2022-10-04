namespace DynamicFormsSample.Forms.Validation;

public interface IValidationRule<TProperty>
{
    string Name { get; }
    ValidationResult Validate(TProperty valueToCompare);
}
