using Maui.FluentForms.Builders;
using Maui.FluentForms.FormFields;
using Maui.FluentForms.Validation;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Maui.FluentForms;

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

        return FieldFor(new FormFieldBuilder<TModel, TProperty>(expression));
    }

    public TBuilder FieldFor<TBuilder>(TBuilder builder)
        where TBuilder : IFormFieldBuilder<TModel>
    {
        _ = builder ?? throw new ArgumentNullException(nameof(builder));

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
