namespace DynamicFormsSample.Forms.Validation;

public sealed class GreaterThanOrEqualValidationRule<TProperty> : IValidationRule<TProperty>
    where TProperty : IComparable<TProperty>
{
    public string Name => "GreaterThanOrEqual";

    private readonly TProperty value;
   
    public GreaterThanOrEqualValidationRule(TProperty value)
    {
        this.value = value;
    }

    public ValidationResult Validate(TProperty valueToCompare)
    {
        var isValid = value.CompareTo(valueToCompare) <= 0;

        return new ValidationResult
        {
            IsValid = isValid
        };
    }
}
