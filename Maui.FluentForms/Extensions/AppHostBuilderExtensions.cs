namespace Maui.FluentForms;

public static class AppHostBuilderExtensions
{
    public static MauiAppBuilder MapFormFieldContentControl<ContentView>(this MauiAppBuilder builder, string formFieldTemplateName)
    {
        FormFieldDataTemplateSelector.MapFormFieldContentControl<ContentView>(formFieldTemplateName);
        return builder;
    }
}
