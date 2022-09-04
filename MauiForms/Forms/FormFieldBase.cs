using MauiForms.Forms.Extensions;
using System.Linq.Expressions;
using System.Reflection;

namespace MauiForms.Forms;

public class FormFieldBase<TModel, TProperty>
{
    private readonly TModel model;
    private readonly Func<TModel, TProperty> getter;
    private readonly Action<TModel, TProperty> setter;

    public TProperty Value
    {
        get
        {
            return getter(model);
        }
        set
        {
            setter(model, value);
        }
    }

    public string FieldTemplateName { get; init; }
    public int? GridRow { get; internal set; }
    public int? GridRowSpan { get; internal set; }
    public int? GridColumn { get; internal set; }
    public int? GridColumnSpan { get; internal set; }

    public FormFieldBase(TModel model,Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, string fieldTemplateName)
    {
        this.model = model;
        this.getter = getter;
        this.setter = setter;

        FieldTemplateName = fieldTemplateName;
    }

    internal static FormFieldBase<TModel, TProperty> Create(TModel model, Expression<Func<TModel, TProperty>> expression, string fieldTemplateName)
    {
        var memberInfo = expression.GetMember();
        var getter = FormFieldAccessorCache.GetCachedGetter<TModel, TProperty>(memberInfo);
        var setter = FormFieldAccessorCache.GetCachedSetter<TModel, TProperty>(memberInfo);

        return new FormFieldBase<TModel, TProperty>(model, getter, setter, fieldTemplateName);
    }
}
