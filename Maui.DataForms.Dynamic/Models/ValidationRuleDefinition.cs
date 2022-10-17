namespace Maui.DataForms.Models;

public sealed class ValidationRuleDefinition
{
    public string RuleName { get; set; }
    public object RuleValue { get; set; }
    public string ErrorMessageFormat { get; set; }
}
