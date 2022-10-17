namespace Maui.DataForms.Validation;

public abstract class ValidationRuleBase<TProperty> : IValidationRule<TProperty>
{
    protected string ErrorMessageFormat { get; init; }

	protected ValidationRuleBase(string errorMessageFormat)
	{
		ErrorMessageFormat = errorMessageFormat;
	}

    protected abstract string GetErrorMessage();

    public abstract FormFieldValidationResult Validate(TProperty valueToCompare);
}

public abstract class ValidationRuleWithValueBase<TProperty> : ValidationRuleBase<TProperty>
    where TProperty : IComparable, IComparable<TProperty>
{
    protected TProperty RuleValue { get; init; }

    protected ValidationRuleWithValueBase(TProperty ruleValue, string errorMessageFormat)
        : base(errorMessageFormat)
    {
        RuleValue = ruleValue;
    }

    protected override string GetErrorMessage()
    {
        return string.Format(ErrorMessageFormat, RuleValue);
    }
}