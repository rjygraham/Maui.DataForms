using MauiForms.Forms.Builders;
using MauiForms.Forms.FormFields;
using MauiForms.Forms.Validation;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace MauiForms.Forms;

public abstract class FormBase<TModel>
{
    private HashSet<IFormFieldBuilder<TModel>> builders = new HashSet<IFormFieldBuilder<TModel>>();
    private int currentRow;

    public ObservableCollection<FormFieldBase> Fields { get; init; } = new ObservableCollection<FormFieldBase>();

    public TModel Model { get; }
    public IValidator<TModel> Validator { get; }

    public FormBase(TModel model, IValidator<TModel> validator = null)
    {
        Model = model;
        Validator = validator;
    }

    public IFormFieldBuilder<TModel> FieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
    {
        _ = expression ?? throw new ArgumentNullException(nameof(expression));

        var builder = new FormFieldBuilder<TModel, TProperty>(expression);
        builders.Add(builder);
        return builder;
    }

    protected void Build()
    {
        foreach (var builder in builders)
        {
            Fields.Add(builder.Build(Model, Validator, currentRow));
        }
    }
}
