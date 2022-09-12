using Maui.FluentForms.Configuration;
using Maui.FluentForms.Extensions;
using Maui.FluentForms.FormFields;
using Maui.FluentForms.Validation;
using System.Linq.Expressions;

namespace Maui.FluentForms.Builders;

internal class FormFieldBuilder<TModel, TProperty> : IFormFieldBuilder<TModel>,
    ICheckBoxFormFieldBuilder<TModel>,
    ICustomTemplateFormFieldBuilder<TModel>,
    IDatePickerFormFieldBuilder<TModel>,
    IEditorFormFieldBuilder<TModel>,
    IEntryFormFieldBuilder<TModel>,
    ISliderFormFieldBuilder<TModel>,
    IStepperFormFieldBuilder<TModel>,
    ISwitchFormFieldBuilder<TModel>,
    ITimePickerFormFieldBuilder<TModel>

{
    private readonly Expression<Func<TModel, TProperty>> expression;

    private string controlTemplateName;

    private IFormFieldConfiguration formFieldConfiguration;
    private FormFieldLayoutConfiguration layoutConfiguration;

    public FormFieldBuilder(Expression<Func<TModel, TProperty>> expression)
    {
        this.expression = expression;
    }

    public FormFieldBase Build(TModel model, IValidator<TModel> validator, int currentRow)
    {
        var field = CreateFormField(model, validator);
        field.ApplyConfiguration(formFieldConfiguration);
        field.ApplyLayoutConfiguration(layoutConfiguration, currentRow);
        return field;
    }

    private FormFieldBase CreateFormField(TModel model, IValidator<TModel> validator)
    {
        var memberInfo = expression.GetMember();
        var getter = FormFieldAccessorCache.GetCachedGetter<TModel, TProperty>(memberInfo);
        var setter = FormFieldAccessorCache.GetCachedSetter<TModel, TProperty>(memberInfo);

        return (this) switch
        {
            { controlTemplateName: FormFieldNames.CheckBox } => new CheckBoxFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { controlTemplateName: FormFieldNames.DatePicker } => new DatePickerFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { controlTemplateName: FormFieldNames.Editor } => new EditorFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { controlTemplateName: FormFieldNames.Entry } => new EntryFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { controlTemplateName: FormFieldNames.Slider } => new SliderFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { controlTemplateName: FormFieldNames.Stepper } => new StepperFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { controlTemplateName: FormFieldNames.Switch } => new SwitchFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            { controlTemplateName: FormFieldNames.TimePicker } => new TimePickerFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
            _ => new CustomTemplateFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, controlTemplateName, validator)
        };
    }

    public ICheckBoxFormFieldBuilder<TModel> AsCheckBox()
    {
        controlTemplateName = FormFieldNames.CheckBox;
        formFieldConfiguration = new CheckBoxFormFieldConfiguration();
        layoutConfiguration = new FormFieldLayoutConfiguration();

        return this;
    }

    public ICustomTemplateFormFieldBuilder<TModel> AsCustomTemplate(string templateName)
    {
        controlTemplateName = templateName;
        formFieldConfiguration = new CustomTemplateFormFieldConfiguration();
        layoutConfiguration = new FormFieldLayoutConfiguration();

        return this;
    }

    public IDatePickerFormFieldBuilder<TModel> AsDatePicker()
    {
        controlTemplateName = FormFieldNames.DatePicker;
        formFieldConfiguration = new DatePickerFormFieldConfiguration();
        layoutConfiguration = new FormFieldLayoutConfiguration();

        return this;
    }

    public IEditorFormFieldBuilder<TModel> AsEditor()
    {
        controlTemplateName = FormFieldNames.Editor;
        formFieldConfiguration = new EditorFormFieldConfiguration();
        layoutConfiguration = new FormFieldLayoutConfiguration();

        return this;
    }

    public IEntryFormFieldBuilder<TModel> AsEntry()
    {
        controlTemplateName = FormFieldNames.Entry;
        formFieldConfiguration = new EntryFormFieldConfiguration();
        layoutConfiguration = new FormFieldLayoutConfiguration();

        return this;
    }

    public ISliderFormFieldBuilder<TModel> AsSlider()
    {
        controlTemplateName = FormFieldNames.Slider;
        formFieldConfiguration = new SliderFormFieldConfiguration();
        layoutConfiguration = new FormFieldLayoutConfiguration();

        return this;
    }

    public IStepperFormFieldBuilder<TModel> AsStepper()
    {
        controlTemplateName = FormFieldNames.Stepper;
        formFieldConfiguration = new StepperFormFieldConfiguration();
        layoutConfiguration = new FormFieldLayoutConfiguration();

        return this;
    }

    public ISwitchFormFieldBuilder<TModel> AsSwitch()
    {
        controlTemplateName = FormFieldNames.Switch;
        formFieldConfiguration = new SwitchFormFieldConfiguration();
        layoutConfiguration = new FormFieldLayoutConfiguration();

        return this;
    }

    public ITimePickerFormFieldBuilder<TModel> AsTimePicker()
    {
        controlTemplateName = FormFieldNames.TimePicker;
        formFieldConfiguration = new TimePickerFormFieldConfiguration();
        layoutConfiguration = new FormFieldLayoutConfiguration();

        return this;
    }

    public ICheckBoxFormFieldBuilder<TModel> WithConfiguration(Action<CheckBoxFormFieldConfiguration> configure)
    {
        configure?.Invoke((CheckBoxFormFieldConfiguration)formFieldConfiguration);
        return this;
    }

    public ICustomTemplateFormFieldBuilder<TModel> WithConfiguration(Action<CustomTemplateFormFieldConfiguration> configure)
    {
        configure?.Invoke((CustomTemplateFormFieldConfiguration)formFieldConfiguration);
        return this;
    }

    public IDatePickerFormFieldBuilder<TModel> WithConfiguration(Action<DatePickerFormFieldConfiguration> configure)
    {
        configure?.Invoke((DatePickerFormFieldConfiguration)formFieldConfiguration);
        return this;
    }

    public IEditorFormFieldBuilder<TModel> WithConfiguration(Action<EditorFormFieldConfiguration> configure)
    {
        configure?.Invoke((EditorFormFieldConfiguration)formFieldConfiguration);
        return this;
    }

    public IEntryFormFieldBuilder<TModel> WithConfiguration(Action<EntryFormFieldConfiguration> configure)
    {
        configure?.Invoke((EntryFormFieldConfiguration)formFieldConfiguration);
        return this;
    }

    public ISliderFormFieldBuilder<TModel> WithConfiguration(Action<SliderFormFieldConfiguration> configure)
    {
        configure?.Invoke((SliderFormFieldConfiguration)formFieldConfiguration);
        return this;
    }

    public IStepperFormFieldBuilder<TModel> WithConfiguration(Action<StepperFormFieldConfiguration> configure)
    {
        configure?.Invoke((StepperFormFieldConfiguration)formFieldConfiguration);
        return this;
    }

    public ISwitchFormFieldBuilder<TModel> WithConfiguration(Action<SwitchFormFieldConfiguration> configure)
    {
        configure?.Invoke((SwitchFormFieldConfiguration)formFieldConfiguration);
        return this;
    }

    public ITimePickerFormFieldBuilder<TModel> WithConfiguration(Action<TimePickerFormFieldConfiguration> configure)
    {
        configure?.Invoke((TimePickerFormFieldConfiguration)formFieldConfiguration);
        return this;
    }

    public ILayoutFieldBuilder WithLayout(Action<FormFieldLayoutConfiguration> configure)
    {
        configure?.Invoke(layoutConfiguration);
        return this;
    }
}
