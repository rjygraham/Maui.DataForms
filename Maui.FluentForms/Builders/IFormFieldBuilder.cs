using Maui.FluentForms.Configuration;
using Maui.FluentForms.FormFields;
using Maui.FluentForms.Validation;

namespace Maui.FluentForms.Builders;

public interface IFormFieldBuilder<TModel>
{
    ICheckBoxFormFieldBuilder<TModel> AsCheckBox();
    IDatePickerFormFieldBuilder<TModel> AsDatePicker();
    IEditorFormFieldBuilder<TModel> AsEditor();
    IEntryFormFieldBuilder<TModel> AsEntry();
    ISliderFormFieldBuilder<TModel> AsSlider();
    IStepperFormFieldBuilder<TModel> AsStepper();
    ISwitchFormFieldBuilder<TModel> AsSwitch();
    ITimePickerFormFieldBuilder<TModel> AsTimePicker();
    FormFieldBase Build(TModel model, IValidator<TModel> validator, int currentRow);
}

public interface ILayoutFieldBuilder
{
    ILayoutFieldBuilder WithLayout(Action<FormFieldLayoutConfiguration> configure);
}

public interface ICheckBoxFormFieldBuilder<TModel> : ILayoutFieldBuilder
{
    ICheckBoxFormFieldBuilder<TModel> WithConfiguration(Action<CheckBoxFormFieldConfiguration> configure);
}

public interface IDatePickerFormFieldBuilder<TModel> : ILayoutFieldBuilder
{
    IDatePickerFormFieldBuilder<TModel> WithConfiguration(Action<DatePickerFormFieldConfiguration> configure);
}

public interface IEditorFormFieldBuilder<TModel> : ILayoutFieldBuilder
{
    IEditorFormFieldBuilder<TModel> WithConfiguration(Action<EditorFormFieldConfiguration> configure);
}

public interface IEntryFormFieldBuilder<TModel> : ILayoutFieldBuilder
{
    IEntryFormFieldBuilder<TModel> WithConfiguration(Action<EntryFormFieldConfiguration> configure);
}

public interface ISliderFormFieldBuilder<TModel> : ILayoutFieldBuilder
{
    ISliderFormFieldBuilder<TModel> WithConfiguration(Action<SliderFormFieldConfiguration> configure);
}

public interface IStepperFormFieldBuilder<TModel> : ILayoutFieldBuilder
{
    IStepperFormFieldBuilder<TModel> WithConfiguration(Action<StepperFormFieldConfiguration> configure);
}

public interface ISwitchFormFieldBuilder<TModel> : ILayoutFieldBuilder
{
    ISwitchFormFieldBuilder<TModel> WithConfiguration(Action<SwitchFormFieldConfiguration> configure);
}

public interface ITimePickerFormFieldBuilder<TModel> : ILayoutFieldBuilder
{
    ITimePickerFormFieldBuilder<TModel> WithConfiguration(Action<TimePickerFormFieldConfiguration> configure);
}
