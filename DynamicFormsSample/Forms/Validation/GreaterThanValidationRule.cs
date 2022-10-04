namespace DynamicFormsSample.Forms.Validation;

public sealed class GreaterThanValidationRule<TProperty> : IValidationRule<TProperty>
    where TProperty : IComparable<TProperty>
{
    public string Name => "GreaterThan";

    private readonly TProperty value;
   
    public GreaterThanValidationRule(TProperty value)
    {
        this.value = value;
    }

    public ValidationResult Validate(TProperty valueToCompare)
    {
        var isValid = value.CompareTo(valueToCompare) < 0;

        return new ValidationResult
        {
            IsValid = isValid
        };
    }
}
