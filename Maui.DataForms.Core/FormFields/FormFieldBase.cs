using Maui.DataForms.Configuration;
using Maui.DataForms.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui.DataForms.FormFields;

public abstract class FormFieldBase : INotifyPropertyChanged, INotifyPropertyChanging
{
    public string ControlTemplateName { get; init; }
    public int GridRow { get; protected set; }
    public int GridRowSpan { get; protected set; }
    public int GridColumn { get; protected set; }
    public int GridColumnSpan { get; protected set; }
    public ObservableCollection<string> Errors { get; init; } = new();

    /// <inheritdoc cref = "INotifyPropertyChanged.PropertyChanged" />
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <inheritdoc cref="INotifyPropertyChanging.PropertyChanging"/>
    public event System.ComponentModel.PropertyChangingEventHandler? PropertyChanging;

    protected FormFieldBase(string controlTemplateName)
    {
        ArgumentNullException.ThrowIfNull(controlTemplateName);

        ControlTemplateName = controlTemplateName;
    }

    public abstract void ApplyConfiguration(IDictionary<string, object> configuration);
    public abstract void ApplyConfiguration(IFormFieldConfiguration configuration);

    public void ApplyLayoutConfiguration(LayoutConfiguration layoutConfiguration)
    {
        ArgumentNullException.ThrowIfNull(layoutConfiguration);

        GridRow = layoutConfiguration.GridRow;
        GridColumn = layoutConfiguration.GridColumn;
        GridRowSpan = layoutConfiguration.GridRowSpan;
        GridColumnSpan = layoutConfiguration.GridColumnSpan;
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
    /// <param name="e">The input <see cref="System.ComponentModel.PropertyChangingEventArgs"/> instance.</param>
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

public abstract class FormFieldBase<TProperty> : FormFieldBase
{
    private readonly ValidationMode validationMode;

    public TProperty Value
    {
        get => GetValue();
        set
        {
            if (!EqualityComparer<TProperty>.Default.Equals(GetValue(), value))
            {
                OnPropertyChanging();
                SetValue(value);
                if (validationMode == ValidationMode.Auto)
                {
                    ValidateValue();
                }
                OnPropertyChanged();
            }
        }
    }

    protected FormFieldBase(string controlTemplateName, ValidationMode validationMode)
        : base(controlTemplateName)
    {
        this.validationMode = validationMode;
    }

    protected abstract TProperty GetValue();
    protected abstract void SetValue(TProperty value);
    protected abstract void ValidateValue();
}

public abstract class FormFieldBase<TModel, TProperty> : FormFieldBase<TProperty>
{
    private readonly TModel model;

    private readonly Func<TModel, TProperty> stronglyTypedModelPropertyGetter;
    private readonly Action<TModel, TProperty> stronglyTypedModelPropertySetter;

    private readonly bool isStronglyTypedModel;

    private readonly string formFieldName;

    private readonly IFormFieldValidator<TModel> validator;

    private FormFieldBase(TModel model, string formFieldName, bool isStronglyTypedModel, string controlTemplateName, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : base(controlTemplateName, validationMode)
    {
        ArgumentNullException.ThrowIfNull(model);
        ArgumentNullException.ThrowIfNull(formFieldName);

        this.model = model;
        this.formFieldName = formFieldName;
        this.isStronglyTypedModel = isStronglyTypedModel;
        this.validator = validator;
    }

    protected FormFieldBase(TModel model, string formFieldName, string controlTemplateName, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : this(model, formFieldName, false, controlTemplateName, validationMode, validator)
    {
        if (model is not IDictionary<string, object>)
        {
            throw new ArgumentException("Parameter type must implement IDictionary<string, object> for this constructor overload.", nameof(model));
        }
    }

    public FormFieldBase(TModel model, string formFieldName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, string controlTemplateName, ValidationMode validationMode, IFormFieldValidator<TModel> validator = null)
        : this(model, formFieldName, true, controlTemplateName, validationMode, validator)
    {
        ArgumentNullException.ThrowIfNull(getter);
        ArgumentNullException.ThrowIfNull(setter);

        this.stronglyTypedModelPropertyGetter = getter;
        this.stronglyTypedModelPropertySetter = setter;
    }

    protected override TProperty GetValue()
    {
        try
        {
            return isStronglyTypedModel
            ? stronglyTypedModelPropertyGetter(model)
            : GetDictionaryValue(formFieldName);
        }
        catch
        {
            return default;
        }
    }

    protected TProperty GetDictionaryValue(string formFieldName)
    {
        if (((IDictionary<string, object>)model).TryGetValue(formFieldName, out var value) && value is not null)
        {
            return (TProperty)value;
        }

        return default;
    }

    protected override void SetValue(TProperty value)
    {
        if (isStronglyTypedModel)
        {
            stronglyTypedModelPropertySetter(model, value);
        }
        else
        {
            ((IDictionary<string, object>)model)[formFieldName] = value;
        }
    }

    protected override void ValidateValue()
    {
        if (validator is null)
        {
            return;
        }

        var validationResult = validator.ValidateField(model, formFieldName);

        Errors.Clear();

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error);
            }
        }
    }
}
