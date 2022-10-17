using Maui.DataForms.FormFields;

namespace Maui.DataForms.Controls;

public class DataFormsDataTemplateSelector : DataTemplateSelector
{
    private static IDictionary<string, Type> mappings = new Dictionary<string, Type>();

    internal static void MapFormFieldControlTemplate<ContentView>(string controlTemplateName)
    {
        mappings.Add(controlTemplateName, typeof(ContentView));
    }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var contentControlType = mappings[((FormFieldBase)item).ControlTemplateName];
        return new DataTemplate(contentControlType);
    }
}
