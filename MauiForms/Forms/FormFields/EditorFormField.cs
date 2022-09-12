﻿using MauiForms.Forms.Configuration;
using MauiForms.Forms.Validation;

namespace MauiForms.Forms.FormFields;

public sealed class EditorFormField<TModel, TProperty> : FormFieldBase<TModel, TProperty>
{
    public EditorAutoSizeOption AutoSize { get; set; }
    public bool IsTextPredictionEnabled { get; set; }
    public string Placeholder { get; set; }
   
    public EditorFormField(TModel model, string memberName, Func<TModel, TProperty> getter, Action<TModel, TProperty> setter, IValidator<TModel> validator = null)
        : base(model, memberName, getter, setter, FormFieldNames.Editor, validator)
    {
    }

    internal override void ApplyConfiguration(IFormFieldConfiguration configuration)
    {
        var typedConfig = (EditorFormFieldConfiguration)configuration;

        AutoSize = typedConfig.AutoSize;
        IsTextPredictionEnabled = typedConfig.IsTextPredictionEnabled;
        Placeholder = typedConfig.Placeholder;
    }
}
