using Maui.FluentForms.Configuration;
using Maui.FluentForms.Extensions;
using Maui.FluentForms.FormFields;
using Maui.FluentForms.Validation;
using System.Linq.Expressions;

namespace Maui.FluentForms.Builders;

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
    protected string FormFieldTemplateName { get; set; }
    protected IFormFieldConfiguration FormFieldConfiguration { get; set; }
    protected FormFieldLayoutConfiguration LayoutConfiguration { get; set; } = new FormFieldLayoutConfiguration();

    public FormFieldBuilder(Expression<Func<TModel, TProperty>> expression)
    {
        this.Expression = expression;
    }

    public FormFieldBase Build(TModel model, IValidator<TModel> validator, int currentRow)
    {
        var field = CreateFormField(model, validator);
        field.ApplyConfiguration(FormFieldConfiguration);
        field.ApplyLayoutConfiguration(LayoutConfiguration, currentRow);
        return field;
    }

    private FormFieldBase CreateFormField(TModel model, IValidator<TModel> validator)
    {
        var memberInfo = Expression.GetMember();
        var getter = FormFieldAccessorCache.GetCachedGetter<TModel, TProperty>(memberInfo);
        var setter = FormFieldAccessorCache.GetCachedSetter<TModel, TProperty>(memberInfo);

        return (this) switch
        {
            { FormFieldTemplateName: FormFieldNames.CheckBox } => new CheckBoxFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { FormFieldTemplateName: FormFieldNames.DatePicker } => new DatePickerFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { FormFieldTemplateName: FormFieldNames.Editor } => new EditorFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { FormFieldTemplateName: FormFieldNames.Entry } => new EntryFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { FormFieldTemplateName: FormFieldNames.Slider } => new SliderFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { FormFieldTemplateName: FormFieldNames.Stepper } => new StepperFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { FormFieldTemplateName: FormFieldNames.Switch } => new SwitchFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { FormFieldTemplateName: FormFieldNames.TimePicker } => new TimePickerFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            _ => CreateCustomFormField(model, memberInfo.Name, getter, setter, validator)
        };
    }

    protected virtual FormFieldBase CreateCustomFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
    {
        throw new ArgumentOutOfRangeException();
    }

    public ICheckBoxFormFieldBuilder<TModel> AsCheckBox()
    {
        FormFieldTemplateName = FormFieldNames.CheckBox;
        FormFieldConfiguration = new CheckBoxFormFieldConfiguration();
       
        return this;
    }

    public IDatePickerFormFieldBuilder<TModel> AsDatePicker()
    {
        FormFieldTemplateName = FormFieldNames.DatePicker;
        FormFieldConfiguration = new DatePickerFormFieldConfiguration();
       
        return this;
    }

    public IEditorFormFieldBuilder<TModel> AsEditor()
    {
        FormFieldTemplateName = FormFieldNames.Editor;
        FormFieldConfiguration = new EditorFormFieldConfiguration();
      
        return this;
    }

    public IEntryFormFieldBuilder<TModel> AsEntry()
    {
        FormFieldTemplateName = FormFieldNames.Entry;
        FormFieldConfiguration = new EntryFormFieldConfiguration();
       
        return this;
    }

    public ISliderFormFieldBuilder<TModel> AsSlider()
    {
        FormFieldTemplateName = FormFieldNames.Slider;
        FormFieldConfiguration = new SliderFormFieldConfiguration();
        
        return this;
    }

    public IStepperFormFieldBuilder<TModel> AsStepper()
    {
        FormFieldTemplateName = FormFieldNames.Stepper;
        FormFieldConfiguration = new StepperFormFieldConfiguration();
       
        return this;
    }

    public ISwitchFormFieldBuilder<TModel> AsSwitch()
    {
        FormFieldTemplateName = FormFieldNames.Switch;
        FormFieldConfiguration = new SwitchFormFieldConfiguration();
        
        return this;
    }

    public ITimePickerFormFieldBuilder<TModel> AsTimePicker()
    {
        FormFieldTemplateName = FormFieldNames.TimePicker;
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

    public ILayoutFieldBuilder WithLayout(Action<FormFieldLayoutConfiguration> configure)
    {
        configure?.Invoke(LayoutConfiguration);
        return this;
    }
}
