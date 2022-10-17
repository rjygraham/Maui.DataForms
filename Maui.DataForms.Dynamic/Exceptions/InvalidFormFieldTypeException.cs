namespace Maui.DataForms.Exceptions;

internal class InvalidFormFieldTypeException : Exception
{
    public string FormField { get; set; }

    public InvalidFormFieldTypeException(string formField)
        : base($"Form field {formField} is invalid. Please ensure custom form fields are registered and that the form field name is correct.")
    {
        FormField = formField;
    }
}
