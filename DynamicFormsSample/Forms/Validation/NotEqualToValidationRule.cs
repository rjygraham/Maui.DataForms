namespace DynamicFormsSample.Forms.Validation;

public class NotEqualToValidationRule<TProperty> : IValidationRule<TProperty>
    where TProperty : IComparable, IComparable<TProperty>
{
    private readonly TProperty value;

    public string Name => "EqualTo";

    public NotEqualToValidationRule(TProperty value)
    {
        this.value = value;
    }

    public ValidationResult Validate(TProperty valueToCompare)
    {
        var isValid = value.CompareTo(valueToCompare) != 0;

        return new ValidationResult
        {
            IsValid = isValid
        };
    }
}
