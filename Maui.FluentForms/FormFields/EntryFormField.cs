﻿using Maui.FluentForms.Configuration;
using Maui.FluentForms.Validation;
using System.Windows.Input;

namespace Maui.FluentForms.FormFields;

public class EntryFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public ClearButtonVisibility ClearButtonVisibility { get; set; }
    public bool FontAutoScalingEnabled { get; set; }
    public Keyboard Keyboard { get; set; }
    public bool IsPassword { get; set; }
    public bool IsTextPredictionEnabled { get; set; }
    public string Placeholder { get; set; }
    public ICommand ReturnCommand { get; set; }
    public object ReturnCommandParameter { get; set; }
    public ReturnType ReturnType { get; set; }
   
    public EntryFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
    : base(model, memberName, getter, setter, FormFieldNames.Entry, validator)
    {
    }

    public override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (EntryFormFieldConfiguration)configuration;

        ClearButtonVisibility = typedConfig.ClearButtonVisibility;
        FontAutoScalingEnabled = typedConfig.FontAutoScalingEnabled;
        Keyboard = typedConfig.Keyboard;
        IsPassword = typedConfig.IsPassword;
        IsTextPredictionEnabled = typedConfig.IsTextPredictionEnabled;
        Placeholder = typedConfig.Placeholder;
        ReturnCommand = typedConfig.ReturnCommand;
        ReturnCommandParameter = typedConfig.ReturnCommandParameter;
        ReturnType = typedConfig.ReturnType;
    }
}