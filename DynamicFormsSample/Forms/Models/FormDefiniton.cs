namespace DynamicFormsSample.Forms.Models;

public class FormDefiniton
{
    public string Id { get; set; }
    public long ETag { get; set; }
    public Dictionary<string, FormFieldDefinition> Fields { get; set; }
}
