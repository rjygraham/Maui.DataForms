using System.Collections;

namespace Maui.DataForms.Validation;

public class MinimumLengthValidationRule<TProperty> : ValidationRuleBase<TProperty>
{
    private readonly short length;

    public MinimumLengthValidationRule(short ruleValue, string errorMessageFormat)
        : base(errorMessageFormat ?? "Minimum required length is {0}.")
    {
        length = ruleValue;
    }

    public override FormFieldValidationResult Validate(TProperty value)
    {
        var isValid = true;

        switch (value)
        {
            case string s when !string.IsNullOrWhiteSpace(s) && s.Length < length:
            case ICollection c when c.Count < length:
            case Array a when a.Length < length:
            case IEnumerable e when e.Cast<object>().Count() < length:
                isValid = false;
                break;
        }

        var errors = isValid
            ? Array.Empty<string>()
            : new string[] { GetErrorMessage() };

        return new FormFieldValidationResult(isValid, errors);
    }

    protected override string GetErrorMessage()
    {
        return string.Format(ErrorMessageFormat, length);
    }
}
