using DynamicFormsSample.Forms.Configuration;

namespace DynamicFormsSample.Forms.Models;

public class FormFieldDefinition
{
    public string DataType { get; set; }
    public bool IsNullable { get; set; }
    public object DefaultValue { get; set; }
    public string ControlTemplateName { get; set; }
    public Dictionary<string, object> Configuration { get; set; }
    public LayoutConfiguration Layout { get; set; }
    public Dictionary<string, object> ValidationRules { get; set; }
}
