namespace DynamicFormsSample.Forms.Validation;

public sealed class LessThanOrEqualValidationRule<TProperty> : IValidationRule<TProperty>
    where TProperty : IComparable<TProperty>
{
    public string Name => "LessThanOrEqual";

    private readonly TProperty value;
   
    public LessThanOrEqualValidationRule(TProperty value)
    {
        this.value = value;
    }

    public ValidationResult Validate(TProperty valueToCompare)
    {
        var isValid = value.CompareTo(valueToCompare) >= 0;

        return new ValidationResult
        {
            IsValid = isValid
        };
    }
}
