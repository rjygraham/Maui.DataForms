using Maui.FluentForms.Builders;
using Maui.FluentForms.FormFields;
using Maui.FluentForms.Validation;
using System.Linq.Expressions;

namespace MauiForms.CustomFormField;

public interface ICustomFormFieldBuilder<TModel> : ILayoutFieldBuilder
{
    ICustomFormFieldBuilder<TModel> WithConfiguration(Action<CustomFormFieldConfiguration> configure);
}

public class MauiFormsCustomFormFieldBuilder<TModel, TProperty> : FormFieldBuilder<TModel, TProperty>, ICustomFormFieldBuilder<TModel>
{
    public MauiFormsCustomFormFieldBuilder(Expression<Func<TModel, TProperty>> expression)
        : base(expression)
    {
    }

    public ICustomFormFieldBuilder<TModel> WithConfiguration(Action<CustomFormFieldConfiguration> configure)
    {
        configure?.Invoke((CustomFormFieldConfiguration)FormFieldConfiguration);
        return this;
    }

    protected override FormFieldBase CreateCustomFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
    {
        // Logic in this method should determine the custom FormField and return it.
        // For example, this is the logic in the standard FormFieldBuilder:
        //
        // return (this) switch
        // {
        //     { FormFieldTemplateName: FormFieldNames.CheckBox } => new CheckBoxFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
        //     { FormFieldTemplateName: FormFieldNames.DatePicker } => new DatePickerFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
        //     { FormFieldTemplateName: FormFieldNames.Editor } => new EditorFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
        //     { FormFieldTemplateName: FormFieldNames.Entry } => new EntryFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
        //     { FormFieldTemplateName: FormFieldNames.Slider } => new SliderFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
        //     { FormFieldTemplateName: FormFieldNames.Stepper } => new StepperFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
        //     { FormFieldTemplateName: FormFieldNames.Switch } => new SwitchFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
        //     { FormFieldTemplateName: FormFieldNames.TimePicker } => new TimePickerFormField<TModel, TProperty>(model, memberInfo.Name, getter, setter, validator),
        //     _ => CreateCustomFormField(model, memberInfo.Name, getter, setter, validator)
        // };

        // In our custom FormField example, there is only a single custom FormField
        // so the logic is simplistic.
        if (FormFieldTemplateName.Equals(MauiFormsCustomFormFieldNames.CustomFormField))
        {
            return new CustomFormField<TModel, TProperty>(model, memberName, getter, setter, validator);
        }

        throw new ArgumentOutOfRangeException();
    }

    public ICustomFormFieldBuilder<TModel> AsCustomFormField()
    {
        FormFieldTemplateName = MauiFormsCustomFormFieldNames.CustomFormField;
        FormFieldConfiguration = new CustomFormFieldConfiguration();

        return this;
    }

}
