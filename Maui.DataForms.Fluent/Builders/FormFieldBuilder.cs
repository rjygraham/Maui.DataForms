using Maui.DataForms.Configuration;
using Maui.DataForms.Extensions;
using Maui.DataForms.FormFields;
using Maui.DataForms.Validation;
using System.Linq.Expressions;

namespace Maui.DataForms.Builders;

public class FormFieldBuilder<TModel, TProperty> : IFormFieldBuilder<TModel>,
    ICheckBoxFormFieldBuilder<TModel>,
    IDatePickerFormFieldBuilder<TModel>,
    IEditorFormFieldBuilder<TModel>,
    IEntryFormFieldBuilder<TModel>,
    ISliderFormFieldBuilder<TModel>,
    IStepperFormFieldBuilder<TModel>,
    ISwitchFormFieldBuilder<TModel>,
    ITimePickerFormFieldBuilder<TModel>

{
    protected Expression<Func<TModel, TProperty>> Expression { get; init; }
    protected string ControlTemplateName { get; set; }
    protected IFormFieldConfiguration FormFieldConfiguration { get; set; }
    protected LayoutConfiguration Layout { get; set; } = new LayoutConfiguration();

    protected ValidationMode ValidationMode { get; set; } = ValidationMode.Auto;

    public FormFieldBuilder(Expression<Func<TModel, TProperty>> expression)
    {
        this.Expression = expression;
    }

    public FormFieldBase Build(TModel model, IDataFormValidator<TModel> validator, int currentRow)
    {
        var field = CreateFormField(model, ValidationMode, validator);
        field.ApplyConfiguration(FormFieldConfiguration);
        field.ApplyLayoutConfiguration(Layout);
        return field;
    }

    private FormFieldBase CreateFormField(TModel model, ValidationMode validationMode, IDataFormValidator<TModel> validator)
    {
        var memberInfo = Expression.GetMember();
        var getter = FormFieldAccessorCache.GetCachedGetter<TModel, TProperty>(memberInfo);
        var setter = FormFieldAccessorCache.GetCachedSetter<TModel, TProperty>(memberInfo);

        return this switch
        {
            { ControlTemplateName: FormFieldNames.CheckBox } => new CheckBoxFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validationMode, validator),
            { ControlTemplateName: FormFieldNames.DatePicker } => new DatePickerFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validationMode, validator),
            { ControlTemplateName: FormFieldNames.Editor } => new EditorFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validationMode, validator),
            { ControlTemplateName: FormFieldNames.Entry } => new EntryFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validationMode, validator),
            { ControlTemplateName: FormFieldNames.Slider } => new SliderFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validationMode, validator),
            { ControlTemplateName: FormFieldNames.Stepper } => new StepperFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validationMode, validator),
            { ControlTemplateName: FormFieldNames.Switch } => new SwitchFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validationMode, validator),
            { ControlTemplateName: FormFieldNames.TimePicker } => new TimePickerFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validationMode, validator),
            _ => CreateCustomFormField(model, memberInfo.Name, getter, setter, validator)
        };
    }

    protected virtual FormFieldBase CreateCustomFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IDataFormValidator<TModel> validator = null)
    {
        throw new ArgumentOutOfRangeException();
    }

    public ICheckBoxFormFieldBuilder<TModel> AsCheckBox()
    {
        ControlTemplateName = FormFieldNames.CheckBox;
        FormFieldConfiguration = new CheckBoxFormFieldConfiguration();
       
        return this;
    }

    public IDatePickerFormFieldBuilder<TModel> AsDatePicker()
    {
        ControlTemplateName = FormFieldNames.DatePicker;
        FormFieldConfiguration = new DatePickerFormFieldConfiguration();
       
        return this;
    }

    public IEditorFormFieldBuilder<TModel> AsEditor()
    {
        ControlTemplateName = FormFieldNames.Editor;
        FormFieldConfiguration = new EditorFormFieldConfiguration();
      
        return this;
    }

    public IEntryFormFieldBuilder<TModel> AsEntry()
    {
        ControlTemplateName = FormFieldNames.Entry;
        FormFieldConfiguration = new EntryFormFieldConfiguration();
       
        return this;
    }

    public ISliderFormFieldBuilder<TModel> AsSlider()
    {
        ControlTemplateName = FormFieldNames.Slider;
        FormFieldConfiguration = new SliderFormFieldConfiguration();
        
        return this;
    }

    public IStepperFormFieldBuilder<TModel> AsStepper()
    {
        ControlTemplateName = FormFieldNames.Stepper;
        FormFieldConfiguration = new StepperFormFieldConfiguration();
       
        return this;
    }

    public ISwitchFormFieldBuilder<TModel> AsSwitch()
    {
        ControlTemplateName = FormFieldNames.Switch;
        FormFieldConfiguration = new SwitchFormFieldConfiguration();
        
        return this;
    }

    public ITimePickerFormFieldBuilder<TModel> AsTimePicker()
    {
        ControlTemplateName = FormFieldNames.TimePicker;
        FormFieldConfiguration = new TimePickerFormFieldConfiguration();
        
        return this;
    }

    public ICheckBoxFormFieldBuilder<TModel> WithConfiguration(Action<CheckBoxFormFieldConfiguration> configure)
    {
        configure?.Invoke((CheckBoxFormFieldConfiguration)FormFieldConfiguration);
        return this;
    }

    public IDatePickerFormFieldBuilder<TModel> WithConfiguration(Action<DatePickerFormFieldConfiguration> configure)
    {
        configure?.Invoke((DatePickerFormFieldConfiguration)FormFieldConfiguration);
        return this;
    }

    public IEditorFormFieldBuilder<TModel> WithConfiguration(Action<EditorFormFieldConfiguration> configure)
    {
        configure?.Invoke((EditorFormFieldConfiguration)FormFieldConfiguration);
        return this;
    }

    public IEntryFormFieldBuilder<TModel> WithConfiguration(Action<EntryFormFieldConfiguration> configure)
    {
        configure?.Invoke((EntryFormFieldConfiguration)FormFieldConfiguration);
        return this;
    }

    public ISliderFormFieldBuilder<TModel> WithConfiguration(Action<SliderFormFieldConfiguration> configure)
    {
        configure?.Invoke((SliderFormFieldConfiguration)FormFieldConfiguration);
        return this;
    }

    public IStepperFormFieldBuilder<TModel> WithConfiguration(Action<StepperFormFieldConfiguration> configure)
    {
        configure?.Invoke((StepperFormFieldConfiguration)FormFieldConfiguration);
        return this;
    }

    public ISwitchFormFieldBuilder<TModel> WithConfiguration(Action<SwitchFormFieldConfiguration> configure)
    {
        configure?.Invoke((SwitchFormFieldConfiguration)FormFieldConfiguration);
        return this;
    }

    public ITimePickerFormFieldBuilder<TModel> WithConfiguration(Action<TimePickerFormFieldConfiguration> configure)
    {
        configure?.Invoke((TimePickerFormFieldConfiguration)FormFieldConfiguration);
        return this;
    }

    public IFormFieldBuilder WithLayout(Action<LayoutConfiguration> configure)
    {
        configure?.Invoke(Layout);
        return this;
    }

    public IFormFieldBuilder WithValidationMode(ValidationMode validationMode)
    {
        ValidationMode = validationMode;
        return this;
    }
}
