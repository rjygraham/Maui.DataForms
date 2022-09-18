using Maui.FluentForms.FormFields;

namespace Maui.FluentForms;

public class FormFieldDataTemplateSelector : DataTemplateSelector
{
    private static IDictionary<string, Type> mappings = new Dictionary<string, Type>();

    internal static void MapFormFieldContentControl<ContentView>(string formFieldTemplateName)
    {
        mappings.Add(formFieldTemplateName, typeof(ContentView));
    }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var contentControlType = mappings[((FormFieldBase)item).FormFieldTemplateName];
        return new DataTemplate(contentControlType);
    }
}
