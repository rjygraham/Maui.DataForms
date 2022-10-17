using Maui.DataForms.Configuration;
using Maui.DataForms.FormFields;
using Maui.DataForms.Validation;

namespace Maui.DataForms.Builders;

public interface IFormFieldLayoutBuilder
{
    IFormFieldBuilder WithLayout(Action<LayoutConfiguration> configure);
}

public interface IFormFieldValidationBuilder
{
    IFormFieldBuilder WithValidationMode(ValidationMode validationMode);
}

public interface IFormFieldBuilder : IFormFieldLayoutBuilder, IFormFieldValidationBuilder
{
}

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
    FormFieldBase Build(TModel model, IDataFormValidator<TModel> validator, int currentRow);
}

public interface ICheckBoxFormFieldBuilder<TModel> : IFormFieldBuilder
{
    ICheckBoxFormFieldBuilder<TModel> WithConfiguration(Action<CheckBoxFormFieldConfiguration> configure);
}

public interface IDatePickerFormFieldBuilder<TModel> : IFormFieldBuilder
{
    IDatePickerFormFieldBuilder<TModel> WithConfiguration(Action<DatePickerFormFieldConfiguration> configure);
}

public interface IEditorFormFieldBuilder<TModel> : IFormFieldBuilder
{
    IEditorFormFieldBuilder<TModel> WithConfiguration(Action<EditorFormFieldConfiguration> configure);
}

public interface IEntryFormFieldBuilder<TModel> : IFormFieldBuilder
{
    IEntryFormFieldBuilder<TModel> WithConfiguration(Action<EntryFormFieldConfiguration> configure);
}

public interface ISliderFormFieldBuilder<TModel> : IFormFieldBuilder
{
    ISliderFormFieldBuilder<TModel> WithConfiguration(Action<SliderFormFieldConfiguration> configure);
}

public interface IStepperFormFieldBuilder<TModel> : IFormFieldBuilder
{
    IStepperFormFieldBuilder<TModel> WithConfiguration(Action<StepperFormFieldConfiguration> configure);
}

public interface ISwitchFormFieldBuilder<TModel> : IFormFieldBuilder
{
    ISwitchFormFieldBuilder<TModel> WithConfiguration(Action<SwitchFormFieldConfiguration> configure);
}

public interface ITimePickerFormFieldBuilder<TModel> : IFormFieldBuilder
{
    ITimePickerFormFieldBuilder<TModel> WithConfiguration(Action<TimePickerFormFieldConfiguration> configure);
}
