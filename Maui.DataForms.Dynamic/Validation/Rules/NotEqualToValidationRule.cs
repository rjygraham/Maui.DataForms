namespace Maui.DataForms.Validation;

public class NotEqualToValidationRule<TProperty> : ValidationRuleWithValueBase<TProperty>
    where TProperty : IComparable, IComparable<TProperty>
{
    public NotEqualToValidationRule(TProperty ruleValue, string errorMessageFormat)
        : base(ruleValue, errorMessageFormat ?? "Value must not be equal to {0}.")
    {
    }

    public override FormFieldValidationResult Validate(TProperty valueToCompare)
    {
        var isValid = RuleValue.CompareTo(valueToCompare) != 0;

        var errors = isValid
            ? Array.Empty<string>()
            : new string[] { GetErrorMessage() };

        return new FormFieldValidationResult(isValid, errors);
    }
}
