namespace Maui.DataForms.Exceptions;

internal class InvalidValidationRuleException : Exception
{
    public string RuleName { get; set; }

    public InvalidValidationRuleException(string ruleName)
        : base($"Validation rule {ruleName} is invalid. Please ensure custom valition rules are registered and that the rule name is correct.")
    {
        RuleName = ruleName;
    }
}
