namespace Maui.FluentForms;

public static class AppHostBuilderExtensions
{
    public static MauiAppBuilder MapFormFieldContentControl<ContentView>(this MauiAppBuilder builder, string templateName)
    {
        FormFieldDataTemplateSelector.MapFormFieldContentControl<ContentView>(templateName);
        return builder;
    }
}
