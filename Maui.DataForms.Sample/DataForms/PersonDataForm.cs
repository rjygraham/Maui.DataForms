using Maui.DataForms.FormFields;
using Maui.DataForms.Sample.Models;
using Maui.DataForms.Validation;
using Maui.FluentForms;

namespace Maui.DataForms.Sample.DataForms;

public class PersonDataForm : FluentFormBase<Person>
{
    public PersonDataForm(Person model, IDataFormValidator<Person> validator = null)
        : base(model, validator)
    {
        FieldFor(f => f.FirstName)
            .AsEntry()
            .WithConfiguration(config => config.Placeholder = "First Name")
            .WithLayout(layout => layout.GridRow = 0)
            .WithValidationMode(ValidationMode.Auto);

        FieldFor(f => f.LastName)
            .AsEntry()
            .WithConfiguration(config => config.Placeholder = "Last Name")
            .WithLayout(layout => layout.GridRow = 1)
            .WithValidationMode(ValidationMode.Auto);

        FieldFor(f => f.DateOfBirth)
            .AsDatePicker()
            .WithConfiguration(config =>
            {
                config.Format = "D";
                config.MinimumDate = DateTime.MinValue;
                config.MaximumDate = DateTime.MaxValue;
            })
            .WithLayout(layout => layout.GridRow = 2)
            .WithValidationMode(ValidationMode.Auto);

        FieldFor(f => f.TimeOfBirth)
            .AsTimePicker()
            .WithConfiguration(config => config.Format = "t")
            .WithLayout(layout => layout.GridRow = 3)
            .WithValidationMode(ValidationMode.Auto);

        FieldFor(f => f.Biography)
            .AsEditor()
            .WithConfiguration(config => config.Placeholder = "Biography")
            .WithLayout(layout => layout.GridRow = 4)
            .WithValidationMode(ValidationMode.Auto);

        FieldFor(f => f.Height)
            .AsSlider()
            .WithConfiguration(config =>
            {
                config.Minimum = 0.1;
                config.Maximum = 0.9;
            })
            .WithLayout(layout => layout.GridRow = 5)
            .WithValidationMode(ValidationMode.Auto);

        FieldFor(f => f.Weight)
            .AsStepper()
            .WithConfiguration(config =>
            {
                config.Minimum = 10.0;
                config.Maximum = 90.0;
            })
            .WithLayout(layout => layout.GridRow = 6)
            .WithValidationMode(ValidationMode.Auto);

        FieldFor(f => f.LikesPizza)
            .AsSwitch()
            .WithLayout(layout => layout.GridRow = 7);

        FieldFor(f => f.IsActive)
            .AsCheckBox()
            .WithLayout(layout => layout.GridRow = 8);

        Build();
    }
}
