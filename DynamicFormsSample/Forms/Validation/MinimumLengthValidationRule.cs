using System.Collections;

namespace DynamicFormsSample.Forms.Validation;

public class MinimumLengthValidationRule<TProperty> : IValidationRule<TProperty>
{
    private readonly int length;

    public string Name => "MaximumLength";

    public MinimumLengthValidationRule(int length)
    {
        this.length = length;
    }

    public ValidationResult Validate(TProperty value)
    {
        bool isValid = true;

        switch (value)
        {
            case string s when !string.IsNullOrWhiteSpace(s) && s.Length < length:
            case ICollection c when c.Count < length:
            case Array a when a.Length < length:
            case IEnumerable e when e.Cast<object>().Count() < length:
                isValid = false;
                break;
        }

        return new ValidationResult
        {
            IsValid = isValid
        };
    }
}
