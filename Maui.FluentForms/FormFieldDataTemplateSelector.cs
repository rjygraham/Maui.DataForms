using Maui.FluentForms.FormFields;

namespace Maui.FluentForms;

public class FormFieldDataTemplateSelector : DataTemplateSelector
{
    private static IDictionary<string, Type> mappings = new Dictionary<string, Type>();

    internal static void MapFormFieldContentControl<ContentView>(string templateName)
    {
        mappings.Add(templateName, typeof(ContentView));
    }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var contentControlType = mappings[((FormFieldBase)item).FieldTemplateName];
        return new DataTemplate(contentControlType);
    }
}
