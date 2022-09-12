namespace MauiForms.Forms.Validation;

public interface IValidator<TModel>
{
    bool Validate(TModel model, out IDictionary<string, string[]> errors);
    bool Validate(TModel model, string memberName, out string[] errors);
}
