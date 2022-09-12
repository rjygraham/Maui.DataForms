using MauiForms.Forms;

namespace MauiForms;

public class PersonForm : FormBase<Person>
{
	public PersonForm()
		: base(new Person(), new PersonValidator())
	{
		FieldFor(f => f.GivenName)
			.AsEntry()
			.WithConfiguration(config =>
			{
				config.Placeholder = "First Name";
			})
			.WithLayout(layout =>
			{
				layout.GridColumn = 0;
				layout.GridRow = 0;
			});

		FieldFor(f => f.Surname)
			.AsEntry()
			.WithConfiguration(config =>
			{
				config.Placeholder = "Last Name";
			})
			.WithLayout(layout =>
			{
				layout.GridColumn = 0;
				layout.GridRow = 1;
			});

		FieldFor(f => f.DateOfBirth)
			.AsDatePicker()
			.WithConfiguration(config =>
			{
				config.MinimumDate = DateTimeOffset.UtcNow.AddYears(-18).DateTime;
				config.MaximumDate = DateTimeOffset.UtcNow.DateTime;
			})
			.WithLayout(layout =>
			{
				layout.GridColumn = 0;
				layout.GridRow = 2;
			});

		Build();
	}
}
