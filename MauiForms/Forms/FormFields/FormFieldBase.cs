using MauiForms.Forms.Configuration;
using MauiForms.Forms.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiForms.Forms.FormFields;

public abstract class FormFieldBase
{
    public string FieldTemplateName { get; init; }
    public int? GridRow { get; protected set; }
    public int? GridRowSpan { get; protected set; }
    public int? GridColumn { get; protected set; }
    public int? GridColumnSpan { get; protected set; }
    public string StyleKey { get; protected set; }

    public FormFieldBase(string fieldTemplateName)
    {
        FieldTemplateName = fieldTemplateName;
    }

    internal abstract void ApplyConfiguration(IFormFieldConfiguration configuration);

    internal void ApplyLayoutConfiguration(FormFieldLayoutConfiguration layoutConfiguration, int currentRow)
    {
        GridRow = layoutConfiguration.GridRow == -1
            ? currentRow
            : layoutConfiguration.GridRow;

        GridColumn = layoutConfiguration.GridColumn;
        GridRowSpan = layoutConfiguration.GridRowSpan;
        GridColumnSpan = layoutConfiguration.GridColumnSpan;
    }
}

public abstract class FormFieldBase<TModel, TProperty> : FormFieldBase, INotifyPropertyChanged, INotifyPropertyChanging
{
    private const string ValuePropertyName = "Value";

    private readonly TModel model;
    private readonly string memberName;
    private readonly Func<TModel, TProperty> getter;
    private readonly Action<TModel, TProperty> setter;
    private readonly IValidator<TModel> validator;

    /// <inheritdoc cref="INotifyPropertyChanged.PropertyChanged"/>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <inheritdoc cref="INotifyPropertyChanging.PropertyChanging"/>
    public event System.ComponentModel.PropertyChangingEventHandler? PropertyChanging;

    public TProperty Value
    {
        get => getter(model);
        set
        {
            if (!EqualityComparer<TProperty>.Default.Equals(getter(model), value))
            {
                OnPropertyChanging(ValuePropertyName);
                setter(model, value);
                ValidateValue();
                OnPropertyChanged(ValuePropertyName);
            }
        }
    }

    public ObservableCollection<string> Errors { get; init; } = new ObservableCollection<string>();

    public FormFieldBase(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, string fieldTemplateName, IValidator<TModel> validator = null)
        : base(fieldTemplateName)
    {
        this.model = model;
        this.memberName = memberName;
        this.getter = getter;
        this.setter = setter;
        this.validator = validator;
    }

    private void ValidateValue()
    {
        if (validator is null)
        {
            return;
        }

        Errors.Clear();

        if (!validator.Validate(model, memberName, out string[] errors))
        {
            for (int i = 0; i < errors.Length; i++)
            {
                Errors.Add(errors[i]);
            }
        }
    }

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event.
    /// </summary>
    /// <param name="e">The input <see cref="PropertyChangedEventArgs"/> instance.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="e"/> is <see langword="null"/>.</exception>
    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);

        PropertyChanged?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="PropertyChanging"/> event.
    /// </summary>
    /// <param name="e">The input <see cref="PropertyChangingEventArgs"/> instance.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="e"/> is <see langword="null"/>.</exception>
    protected virtual void OnPropertyChanging(System.ComponentModel.PropertyChangingEventArgs e)
    {
        ArgumentNullException.ThrowIfNull(e);

        PropertyChanging?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event.
    /// </summary>
    /// <param name="propertyName">(optional) The name of the property that changed.</param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Raises the <see cref="PropertyChanging"/> event.
    /// </summary>
    /// <param name="propertyName">(optional) The name of the property that changed.</param>
    protected void OnPropertyChanging([CallerMemberName] string? propertyName = null)
    {
        OnPropertyChanging(new System.ComponentModel.PropertyChangingEventArgs(propertyName));
    }
}
