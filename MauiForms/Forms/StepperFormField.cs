namespace MauiForms.Forms;

public class StepperFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public double Increment { get; set; }
    public double Minimum { get; set; }
    public double Maximum { get; set; }

    public StepperFormField(TModel model, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter)
        : base(model, getter, setter, Constants.Stepper)
    {
    }
}
