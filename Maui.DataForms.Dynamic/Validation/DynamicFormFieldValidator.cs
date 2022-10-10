using System.Diagnostics;

namespace Maui.DataForms.Validation;

public class DynamicFormFieldValidator<TProperty> : IFormFieldValidator<IDictionary<string, object>>
{
    private readonly IList<IValidationRule> validationRules;

    public DynamicFormFieldValidator(IList<IValidationRule> validationRules)
    {
        this.validationRules = validationRules;
    }

    public FormFieldValidationResult Validate(IDictionary<string, object> model, string formFieldName)
    {
        var isValid = true;
        var errors = new List<string>();

        TProperty value = (TProperty)model[formFieldName];

        foreach (var validationRule in validationRules)
        {
            var ruleResult = ((IValidationRule<TProperty>)validationRule).Validate(value);
            isValid = isValid && ruleResult.IsValid;
            errors.AddRange(ruleResult.Errors);
        }

        return new FormFieldValidationResult(isValid, errors.ToArray());
    }
}
