namespace DynamicFormsSample.Forms.Validation;

public sealed class LessThanValidationRule<TProperty> : IValidationRule<TProperty>
    where TProperty : IComparable<TProperty>
{
    public string Name => "LessThan";

    private readonly TProperty value;
   
    public LessThanValidationRule(TProperty value)
    {
        this.value = value;
    }

    public ValidationResult Validate(TProperty valueToCompare)
    {
        var isValid = value.CompareTo(valueToCompare) > 0;

        return new ValidationResult
        {
            IsValid = isValid
        };
    }
}
