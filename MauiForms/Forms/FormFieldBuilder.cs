using System.Linq.Expressions;

namespace MauiForms.Forms;

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
    public int? GridRow { get; set; }
    public int? GridRowSpan { get; set; }
    public int? GridColumn { get; set; }
    public int? GridColumnSpan { get; set; }

    public FormFieldBuilder(Expression<Func<TModel, TProperty>> expression)
	{
		this.expression = expression;
	}

    public ICheckBoxFormFieldBuilder<TModel> AsCheckBox()
    {
        controlTemplateName = Constants.CheckBox;
        return this;
    }

    public ICustomTemplateFormFieldBuilder<TModel> AsCustomTemplate(string templateName)
    {
        controlTemplateName = templateName;
        return this;
    }

    public IDatePickerFormFieldBuilder<TModel> AsDatePicker()
    {
        controlTemplateName = Constants.DatePicker;
        return this;
    }

    public IEditorFormFieldBuilder<TModel> AsEditor()
    {
        controlTemplateName = Constants.Editor;
        return this;
    }

    public IEntryFormFieldBuilder<TModel> AsEntry()
    {
        controlTemplateName = Constants.Entry;
        return this;
    }

    public ISliderFormFieldBuilder<TModel> AsSlider()
    {
        controlTemplateName = Constants.Slider;
        return this;
    }

    public IStepperFormFieldBuilder<TModel> AsStepper()
    {
        controlTemplateName = Constants.Stepper;
        return this;
    }

    public ISwitchFormFieldBuilder<TModel> AsSwitch()
    {
        controlTemplateName = Constants.Switch;
        return this;
    }

    public ITimePickerFormFieldBuilder<TModel> AsTimePicker()
    {
        controlTemplateName = Constants.TimePicker;
        return this;
    }

    internal FormFieldBase<TModel, TProperty> Build(TModel model)
	{
		var field = FormFieldBase<TModel, TProperty>.Create(model, expression, controlTemplateName);

		return field;
	}
}
