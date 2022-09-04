namespace MauiForms.Forms;

public class DatePickerFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public DateTime MinimumDate { get; set; }
    public DateTime MaximumDate { get; set; }
    public string  Format { get; set; }
    public Color TextColor { get; set; }
    public FontAttributes FontAttributes { get; set; }
    public string FontFamily { get; set; }
    public double FontSize { get; set; }
    public double CharacterSpacing { get; set; }
    
    public DatePickerFormField(TModel model, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter)
        : base(model, getter, setter, Constants.DatePicker)
    {
    }
}
