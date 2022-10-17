using System.Windows.Input;

namespace Maui.DataForms.Configuration;

public sealed class SliderFormFieldConfiguration : FormFieldConfigurationBase
{
    public double Minimum { get; set; } = 0;
    public double Maximum { get; set; } = 1;
    public ICommand DragStartedCommand { get; set; }
    public ICommand DragCompletedCommand { get; set; }
}
