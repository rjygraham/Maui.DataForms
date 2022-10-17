using Maui.DataForms.Controls;

namespace Maui.DataForms;

public static class AppHostBuilderExtensions
{
    public static MauiAppBuilder MapFormFieldContentControl<ContentView>(this MauiAppBuilder builder, string formFieldTemplateName)
    {
        DataFormsDataTemplateSelector.MapFormFieldControlTemplate<ContentView>(formFieldTemplateName);
        return builder;
    }
}
