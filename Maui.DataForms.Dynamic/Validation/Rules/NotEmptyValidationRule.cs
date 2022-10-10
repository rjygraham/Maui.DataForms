using System.Collections;

namespace Maui.DataForms.Validation;

public sealed class NotEmptyValidationRule<TProperty> : ValidationRuleBase<TProperty>
{
    public NotEmptyValidationRule(string errorMessageFormat)
        : base(errorMessageFormat ?? "Value must not be empty.")
    {
    }

    public override FormFieldValidationResult Validate(TProperty value)
    {
        var isValid = true;

        switch (value)
        {
            case null:
            case string s when string.IsNullOrWhiteSpace(s):
            case ICollection { Count: 0 }:
            case Array { Length: 0 }:
            case IEnumerable e when !e.GetEnumerator().MoveNext():
                isValid = false;
                break;
        }

        if (isValid && value.Equals(default(TProperty)))
        {
            isValid = false;
        }

        var errors = isValid
            ? Array.Empty<string>()
            : new string[] { GetErrorMessage() };

        return new FormFieldValidationResult(isValid, errors);
    }

    protected override string GetErrorMessage()
    {
        return ErrorMessageFormat;
    }
}
