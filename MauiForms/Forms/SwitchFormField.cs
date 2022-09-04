namespace MauiForms.Forms;

public class SwitchFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public Color OnColor { get; set; }
    public Color ThumbColor { get; set; }

    public SwitchFormField(TModel model, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter)
        : base(model, getter, setter, Constants.Switch)
    {
    }
}
