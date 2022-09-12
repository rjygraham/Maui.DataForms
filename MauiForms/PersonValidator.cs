using FluentValidation;
using FluentValidation.Internal;

namespace MauiForms;

public class PersonValidator : AbstractValidator<Person>, Maui.FluentForms.Validation.IValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(r => r.GivenName).NotEmpty().MaximumLength(20);
        RuleFor(r => r.Surname).NotEmpty().MaximumLength(50);
        RuleFor(r => r.DateOfBirth).Must(m => m >= DateTimeOffset.UtcNow.AddYears(-18));
    }

    public bool Validate(Person model, out IDictionary<string, string[]> errors)
    {
        var validationResults = Validate(model);

        if (validationResults.IsValid)
        {
            errors = new Dictionary<string, string[]>();
            return true;
        }

        errors = validationResults.ToDictionary();

        return false;
    }

    public bool Validate(Person model, string memberName, out string[] errors)
    {
        var members = new string[] { memberName };
        var validationContext = new ValidationContext<Person>(model, new PropertyChain(), new MemberNameValidatorSelector(members));

        var validationResults = Validate(validationContext);

        if (validationResults.IsValid)
        {
            errors = Array.Empty<string>();
            return true;
        }

        errors = validationResults.Errors.Select(s => s.ErrorMessage).ToArray();

        return false;
    }
}
