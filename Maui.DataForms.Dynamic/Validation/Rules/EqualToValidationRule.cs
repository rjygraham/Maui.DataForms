namespace Maui.DataForms.Validation;

public class EqualToValidationRule<TProperty> : ValidationRuleWithValueBase<TProperty>
     where TProperty : IComparable, IComparable<TProperty>
{
    public EqualToValidationRule(TProperty ruleValue, string errorMessageFormat)
        : base(ruleValue, errorMessageFormat ?? "Value must be equal to {0}.")
    {
    }

    public override FormFieldValidationResult Validate(TProperty valueToCompare)
    {
        var isValid = RuleValue.CompareTo(valueToCompare) == 0;

        var errors = isValid
            ? Array.Empty<string>()
            : new string[] { GetErrorMessage() };

        return new FormFieldValidationResult(isValid, errors);
    }
}
