namespace Maui.DataForms.Validation;

public interface IFormFieldValidator<TModel>
{
    FormFieldValidationResult Validate(TModel model, string formFieldName);
}
