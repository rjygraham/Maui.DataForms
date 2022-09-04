namespace MauiForms.Forms;

public sealed class EditorFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public EditorAutoSizeOption AutoSize { get; set; }
    public double CharacterSpacing { get; set; }
    public FontAttributes FontAttributes { get; set; }
    public bool FontAutoScalingEnabled { get; set; }
    public string FontFamily { get; set; }
    public double FontSize { get; set; }
    public TextAlignment HorizontalTextAlignment { get; set; }
    public bool IsTextPredictionEnabled { get; set; }
    public string Placeholder { get; set; }
    public Color PlaceholderColor { get; set; }
    public Color TextColor { get; set; }
    public TextAlignment VerticalTextAlignment { get; set; }

    public EditorFormField(TModel model, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter)
        : base(model, getter, setter, Constants.Editor)
    {
    }
}
