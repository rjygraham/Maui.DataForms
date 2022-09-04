namespace MauiForms.Forms;

public interface IFormFieldBuilder<TModel>
{
    IEditorFormFieldBuilder<TModel> AsEditor();
    IEntryFormFieldBuilder<TModel> AsEntry();
    ICheckBoxFormFieldBuilder<TModel> AsCheckBox();
    IDatePickerFormFieldBuilder<TModel> AsDatePicker();
    ISliderFormFieldBuilder<TModel> AsSlider();
    IStepperFormFieldBuilder<TModel> AsStepper();
    ISwitchFormFieldBuilder<TModel> AsSwitch();
    ITimePickerFormFieldBuilder<TModel> AsTimePicker();
    ICustomTemplateFormFieldBuilder<TModel> AsCustomTemplate(string templateName);
}

public interface ILayoutFieldBuilder
{
    int? GridRow { get; set; }
    int? GridRowSpan { get; set; }
    int? GridColumn { get; set; }
    int? GridColumnSpan { get; set; }
}

public interface IEditorFormFieldBuilder<TModel> : ILayoutFieldBuilder
{

}

public interface IEntryFormFieldBuilder<TModel> : ILayoutFieldBuilder
{

}

public interface ICheckBoxFormFieldBuilder<TModel> : ILayoutFieldBuilder
{

}

public interface IDatePickerFormFieldBuilder<TModel> : ILayoutFieldBuilder
{

}

public interface ISliderFormFieldBuilder<TModel> : ILayoutFieldBuilder
{

}

public interface IStepperFormFieldBuilder<TModel> : ILayoutFieldBuilder
{

}

public interface ISwitchFormFieldBuilder<TModel> : ILayoutFieldBuilder
{

}

public interface ITimePickerFormFieldBuilder<TModel> : ILayoutFieldBuilder
{

}

public interface ICustomTemplateFormFieldBuilder<TModel> : ILayoutFieldBuilder
{

}
