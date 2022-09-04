using System.Linq.Expressions;

namespace MauiForms.Forms;

public abstract class FormBase<TModel>
{
    private HashSet<IFormFieldBuilder<TModel>> formFieldBuilders = new HashSet<IFormFieldBuilder<TModel>>();

    public TModel Model { get; set; }

    public FormBase(TModel model)
    {
        Model = model;
    }

    public IFormFieldBuilder<TModel> FieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
    {
        _ = expression ?? throw new ArgumentNullException(nameof(expression));

        return new FormFieldBuilder<TModel, TProperty>(expression);
    }

    public void Build()
    {

    }
}
