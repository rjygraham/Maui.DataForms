namespace Maui.DataForms.Validation;

public interface IModelValidator<TModel>
{
    bool Validate(TModel model, out IDictionary<string, string[]> errors);
    bool Validate(TModel model, string memberName, out string[] errors);
}
