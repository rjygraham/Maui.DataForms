using Maui.DataForms.FormFields;

namespace Maui.DataForms.Configuration;

public abstract class FormFieldConfigurationBase : IFormFieldConfiguration
{
    public ValidationMode validationMode { get; set; }
}
