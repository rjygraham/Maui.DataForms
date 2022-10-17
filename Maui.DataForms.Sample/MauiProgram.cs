using CommunityToolkit.Maui;
using Maui.DataForms.Sample.ViewModels;
using Maui.DataForms.Sample.Views;
using Maui.DataForms.Controls;

namespace Maui.DataForms.Sample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseDefaultFormFieldContentControls()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .Services
                .AddTransient<DynamicDemoPage, DynamicDemoPageViewModel>()
                .AddTransient<FluentDemoPage, FluentDemoPageViewModel>();
            
        return builder.Build();
    }
}
