using System.Collections;

namespace DynamicFormsSample.Forms.Validation;

public sealed class NotEmptyValidationRule<TProperty> : IValidationRule<TProperty>
{
    public string Name => "NotEmpty";

    public ValidationResult Validate(TProperty value)
    {
        bool isValid = true;

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

        if (isValid && value is not null && value.Equals(default(TProperty)))
        {
            isValid = false;
        }

        return new ValidationResult
        {
            IsValid = isValid
        };
    }
}
