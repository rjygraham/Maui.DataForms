using Maui.DataForms.Configuration;
using Maui.DataForms.FormFields;

namespace Maui.DataForms.Models;

public class FormFieldDefinition
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string DataType { get; set; }
    public object DefaultValue { get; set; }
    public string ControlTemplateName { get; set; }
    public ValidationMode ValidationMode { get; set; } = ValidationMode.Auto;
    public CaseInsensitiveDictionary<object> Configuration { get; set; } = new CaseInsensitiveDictionary<object>();
    public LayoutConfiguration Layout { get; set; }
    public IList<ValidationRuleDefinition> ValidationRules { get; set; } = new List<ValidationRuleDefinition>();
}
