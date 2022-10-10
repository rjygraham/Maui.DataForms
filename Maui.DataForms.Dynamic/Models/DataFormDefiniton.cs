namespace Maui.DataForms.Models;

public class DataFormDefiniton
{
    public string Id { get; set; }
    public string Name { get; set; }
    public long ETag { get; set; }
    public IList<FormFieldDefinition> Fields { get; set; }
}
