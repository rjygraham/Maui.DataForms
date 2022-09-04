using System.Windows.Input;

namespace MauiForms.Forms;

public class EntryFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public double CharacterSpacing { get; set; }
    public ClearButtonVisibility ClearButtonVisibility { get; set; }
    public FontAttributes FontAttributes { get; set; }
    public bool FontAutoScalingEnabled { get; set; }
    public string FontFamily { get; set; }
    public double FontSize { get; set; }
    public Keyboard Keyboard { get; set; }
    public TextAlignment HorizontalTextAlignment { get; set; }
    public bool IsPassword { get; set; }
    public bool IsTextPredictionEnabled { get; set; }
    public string Placeholder { get; set; }
    public Color PlaceholderColor { get; set; }
    public ICommand ReturnCommand { get; set; }
    public object ReturnCommandParameter { get; set; }
    public ReturnType ReturnType { get; set; }
    public Color TextColor { get; set; }
    public TextAlignment VerticalTextAlignment { get; set; }

  
    public EntryFormField(TModel model, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter)
    : base(model, getter, setter, Constants.Entry)
    {
    }
}
