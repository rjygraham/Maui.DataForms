using Maui.DataForms.Configuration;
using Maui.DataForms.FormFields;

namespace DynamicFormsSample.Forms.Models;

public class FormFieldDefinition
{
    public string DataType { get; set; }
    public object DefaultValue { get; set; }
    public string ControlTemplateName { get; set; }
    public ValidationMode ValidationMode { get; set; } = ValidationMode.Auto;
    public Dictionary<string, object> Configuration { get; set; }
    public LayoutConfiguration Layout { get; set; }
    public Dictionary<string, object> ValidationRules { get; set; }
}
