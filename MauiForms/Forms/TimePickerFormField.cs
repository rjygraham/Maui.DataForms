namespace MauiForms.Forms;

public class TimePickerFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public string Format { get; set; }

    public Color TextColor { get; set; }

    public FontAttributes FontAttributes { get; set; }

    public string FontFamily { get; set; }

    public double FontSize { get; set; }

    public double CharacterSpacing { get; set; }

    public TimePickerFormField(TModel model, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter)
        : base(model, getter, setter, Constants.TimePicker)
    {
    }
}
