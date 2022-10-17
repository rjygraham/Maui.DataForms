namespace Maui.DataForms.Validation;

public interface IFormFieldValidator<TModel>
{
    FormFieldValidationResult ValidateField(TModel model, string formFieldName);
}
