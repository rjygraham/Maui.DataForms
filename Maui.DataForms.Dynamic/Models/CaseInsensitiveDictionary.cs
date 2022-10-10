namespace Maui.DataForms.Models;

public class CaseInsensitiveDictionary<TValue> : Dictionary<string, TValue>
{
	public CaseInsensitiveDictionary()
		: base(StringComparer.OrdinalIgnoreCase)
	{
	}
}
