namespace Maui.FluentForms.Configuration;

public sealed class FormFieldLayoutConfiguration
{
    public int GridRow { get; set; } = -1;
    public int GridRowSpan { get; set; } = 1;
    public int GridColumn { get; set; } = 0;
    public int GridColumnSpan { get; set; } = 1;
}
