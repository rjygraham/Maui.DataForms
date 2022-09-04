using MauiForms.Forms;
using MauiForms.Forms.Extensions;

namespace MauiForms;

public class PersonForm : FormBase<Person>
{
	public PersonForm()
		: base(new Person())
	{
		FieldFor(f => f.GivenName).AsEntry().WithGridLayout(1, 2, 1, 1);
		FieldFor(f => f.Surname).AsEntry();
		FieldFor(f => f.DateOfBirth).AsDatePicker().WithGridLayout(1, 2, 1, 1);

		Build();
	}
}
