namespace MauiForms.Forms;

public class CustomTemplateFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public CustomTemplateFormField(TModel model, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, string fieldTemplateName)
        : base(model, getter, setter, fieldTemplateName)
    {
    }
}
