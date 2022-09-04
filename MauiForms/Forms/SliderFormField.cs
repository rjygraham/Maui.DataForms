using Microsoft.UI.Xaml.Controls.Primitives;
using System.Windows.Input;

namespace MauiForms.Forms;

public class SliderFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public double Minimum { get; set; }
    public double Maximum { get; set; }
    public Color MinimumTrackColor { get; set; }
    public Color MaximumTrackColor { get; set; }
    public Color ThumbColor { get; set; }
    public ImageSource ThumbImageSource { get; set; }
    public ICommand DragStartedCommand { get; set; }
    public ICommand DragCompletedCommand { get; set; }

    public SliderFormField(TModel model, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter)
        : base(model, getter, setter, Constants.Slider)
    {
    }
}
