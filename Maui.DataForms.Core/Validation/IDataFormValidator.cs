namespace Maui.DataForms.Validation;

public interface IDataFormValidator<TModel> : IFormFieldValidator<TModel>
{
    DataFormValidationResult ValidateForm(TModel model);
}
