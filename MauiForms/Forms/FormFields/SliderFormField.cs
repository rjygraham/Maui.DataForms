using MauiForms.Forms.Configuration;
using MauiForms.Forms.Validation;
using System.Windows.Input;

namespace MauiForms.Forms.FormFields;

public class SliderFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public double Minimum { get; set; }
    public double Maximum { get; set; }
    public ICommand DragStartedCommand { get; set; }
    public ICommand DragCompletedCommand { get; set; }

    public SliderFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.Slider, validator)
    {
    }

    internal override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (SliderFormFieldConfiguration)configuration;

        Minimum = typedConfig.Minimum;
        Maximum = typedConfig.Maximum;
        DragStartedCommand = typedConfig.DragStartedCommand;
        DragCompletedCommand = typedConfig.DragCompletedCommand;
    }
}
