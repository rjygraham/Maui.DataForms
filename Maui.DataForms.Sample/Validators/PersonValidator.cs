using FluentValidation;
using FluentValidation.Internal;
using Maui.DataForms.Sample.Models;
using Maui.DataForms.Validation;

namespace Maui.DataForms.Sample.Validators;

public class PersonValidator : AbstractValidator<Person>, IDataFormValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(r => r.FirstName)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(r => r.LastName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.DateOfBirth)
            .NotEmpty()
            .GreaterThanOrEqualTo(new DateTime(2000, 1, 1, 0, 0, 0))
            .LessThanOrEqualTo(new DateTime(2021, 12, 31, 23, 59, 59));

        RuleFor(r => r.Biography)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(r => r.Height)
            .GreaterThan(0.2)
            .LessThanOrEqualTo(0.8);

        RuleFor(r => r.Weight)
            .GreaterThan(20.0)
            .LessThanOrEqualTo(80.0);
    }

    public FormFieldValidationResult ValidateField(Person model, string formFieldName)
    {
        var members = new string[] { formFieldName };
        var validationContext = new ValidationContext<Person>(model, new PropertyChain(), new MemberNameValidatorSelector(members));

        var validationResults = Validate(validationContext);

        var errors = validationResults.IsValid
                ? Array.Empty<string>()
                : validationResults.Errors.Select(s => s.ErrorMessage).ToArray();

        return new FormFieldValidationResult(validationResults.IsValid, errors);
    }

    public DataFormValidationResult ValidateForm(Person model)
    {
        var validationResults = Validate(model);

        var errors = validationResults.IsValid
            ? new Dictionary<string, string[]>()
            : validationResults.ToDictionary();

        return new DataFormValidationResult(validationResults.IsValid, errors);
    }
}
