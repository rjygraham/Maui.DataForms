namespace MauiForms.Forms;

public class CheckBoxFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public Color Color { get; set; }

    public CheckBoxFormField(TModel model, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter)
        : base(model, getter, setter, Constants.CheckBox)
    {
    }
}
