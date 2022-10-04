namespace DynamicFormsSample.Forms.Models;

public class DataFormDefiniton
{
    public string Id { get; set; }
    public long ETag { get; set; }
    public Dictionary<string, FormFieldDefinition> Fields { get; set; }
}
