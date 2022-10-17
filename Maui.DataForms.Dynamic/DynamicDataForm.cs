using Maui.DataForms.Exceptions;
using Maui.DataForms.FormFields;
using Maui.DataForms.Models;
using Maui.DataForms.Validation;
using System.Collections.ObjectModel;

namespace Maui.DataForms;

public class DynamicDataForm
{
    private static Type dictionaryType = typeof(IDictionary<string, object>);
    private static Type dynamicFormFieldValidatorType = typeof(DynamicFormFieldValidator<>);

    private static IDictionary<string, Type> mappedFormFields = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
    {
        [FormFieldNames.CheckBox] = typeof(CheckBoxFormField<,>),
        [FormFieldNames.DatePicker] = typeof(DatePickerFormField<,>),
        [FormFieldNames.Editor] = typeof(EditorFormField<,>),
        [FormFieldNames.Entry] = typeof(EntryFormField<,>),
        [FormFieldNames.Slider] = typeof(SliderFormField<,>),
        [FormFieldNames.Stepper] = typeof(StepperFormField<,>),
        [FormFieldNames.Switch] = typeof(SwitchFormField<,>),
        [FormFieldNames.TimePicker] = typeof(TimePickerFormField<,>)
    };

    private static IDictionary<string, Type> mappedDataTypes = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
    {
        [DataTypeNames.Bool] = typeof(bool),
        [DataTypeNames.Char] = typeof(char),
        [DataTypeNames.DateOnly] = typeof(DateOnly),
        [DataTypeNames.DateTime] = typeof(DateTime),
        [DataTypeNames.DateTimeOffset] = typeof(DateTimeOffset),
        [DataTypeNames.Decimal] = typeof(decimal),
        [DataTypeNames.Double] = typeof(double),
        [DataTypeNames.Float] = typeof(float),
        [DataTypeNames.Int] = typeof(int),
        [DataTypeNames.Long] = typeof(long),
        [DataTypeNames.Short] = typeof(short),
        [DataTypeNames.String] = typeof(string),
        [DataTypeNames.TimeOnly] = typeof(TimeOnly),
        [DataTypeNames.TimeSpan] = typeof(TimeSpan),
        [DataTypeNames.Uint] = typeof(uint),
        [DataTypeNames.Ulong] = typeof(ulong),
        [DataTypeNames.Ushort] = typeof(ushort),
        [DataTypeNames.NullableBool] = typeof(bool?),
        [DataTypeNames.NullableChar] = typeof(char?),
        [DataTypeNames.NullableDateOnly] = typeof(DateOnly?),
        [DataTypeNames.NullableDateTime] = typeof(DateTime?),
        [DataTypeNames.NullableDateTimeOffset] = typeof(DateTimeOffset?),
        [DataTypeNames.NullableDecimal] = typeof(decimal?),
        [DataTypeNames.NullableDouble] = typeof(double?),
        [DataTypeNames.NullableFloat] = typeof(float?),
        [DataTypeNames.NullableInt] = typeof(int?),
        [DataTypeNames.NullableLong] = typeof(long?),
        [DataTypeNames.NullableShort] = typeof(short?),
        [DataTypeNames.NullableTimeOnly] = typeof(TimeOnly?),
        [DataTypeNames.NullableUint] = typeof(uint?),
        [DataTypeNames.NullableUlong] = typeof(ulong?),
        [DataTypeNames.NullableUshort] = typeof(ushort?)
    };

    private static IDictionary<string, Type> mappedValidationRules = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
    {
        [ValidationRuleNames.EqualTo] = typeof(EqualToValidationRule<>),
        [ValidationRuleNames.GreaterThanOrEqual] = typeof(GreaterThanOrEqualValidationRule<>),
        [ValidationRuleNames.GreaterThan] = typeof(GreaterThanValidationRule<>),
        [ValidationRuleNames.LessThanOrEqual] = typeof(LessThanOrEqualValidationRule<>),
        [ValidationRuleNames.LessThan] = typeof(LessThanValidationRule<>),
        [ValidationRuleNames.MaximumLength] = typeof(MaximumLengthValidationRule<>),
        [ValidationRuleNames.MinimumLength] = typeof(MinimumLengthValidationRule<>),
        [ValidationRuleNames.NotEmpty] = typeof(NotEmptyValidationRule<>),
        [ValidationRuleNames.NotEqualTo] = typeof(NotEqualToValidationRule<>)
    };

    public ObservableCollection<FormFieldBase> Fields { get; init; } = new();

    public IDictionary<string, object> Model { get; init; }

    private DynamicDataForm()
    {
        Model = new Dictionary<string, object>();
    }

    public static void MapDynamicFormField<TFormField>(string formFieldName)
    {
        mappedDataTypes.TryAdd(formFieldName, typeof(TFormField));
    }

    public static DynamicDataForm Create(DataFormDefiniton dataFormDefinition)
    {
        var form = new DynamicDataForm();

        foreach (var fieldDefinition in dataFormDefinition.Fields)
        {
            var field = CreateDynamicFormField(form, fieldDefinition);
            form.Fields.Add(field);

            if (fieldDefinition.DefaultValue is not null)
            {
                form.Model[fieldDefinition.Id] = fieldDefinition.DefaultValue;
            }
            else
            {
                form.Model[fieldDefinition.Id] = null;
            }
        }

        return form;
    }

    private static FormFieldBase CreateDynamicFormField(DynamicDataForm form, FormFieldDefinition formFieldDefinition)
    {
        Type formFieldType;
        if (!mappedFormFields.TryGetValue(formFieldDefinition.ControlTemplateName, out formFieldType))
        {
            throw new InvalidFormFieldTypeException(formFieldDefinition.ControlTemplateName);
        }

        Type formFieldDataType;
        if (!mappedDataTypes.TryGetValue(formFieldDefinition.DataType, out formFieldDataType))
        {
            throw new InvalidFormFieldDataTypeException(formFieldDefinition.DataType);
        }

        var genericFormFieldType = formFieldType.MakeGenericType(dictionaryType, formFieldDataType);
        var validator = CreateValidator(formFieldDataType, formFieldDefinition.ValidationRules);
        var field = (FormFieldBase)Activator.CreateInstance(genericFormFieldType, form.Model, formFieldDefinition.Id, formFieldDefinition.ValidationMode, validator);

        field.ApplyConfiguration(formFieldDefinition.Configuration);
        field.ApplyLayoutConfiguration(formFieldDefinition.Layout);

        return field;
    }

    private static IFormFieldValidator<IDictionary<string, object>> CreateValidator(Type formFieldDataType, IList<ValidationRuleDefinition> validationRuleDefinitions)
    {
        var validationRules = new List<IValidationRule>();

        foreach (var validationRuleDefinition in validationRuleDefinitions)
        {
            validationRules.Add(CreateValidationRule(formFieldDataType, validationRuleDefinition));
        }

        var genericValidationRuleType = dynamicFormFieldValidatorType.MakeGenericType(formFieldDataType);
        return (IFormFieldValidator<IDictionary<string, object>>)Activator.CreateInstance(genericValidationRuleType, validationRules);
    }

    private static IValidationRule CreateValidationRule(Type formFieldDataType, ValidationRuleDefinition validationRuleDefinition)
    {
        Type validationRuleType;
        if (!mappedValidationRules.TryGetValue(validationRuleDefinition.RuleName, out validationRuleType))
        {
            throw new InvalidValidationRuleException(validationRuleDefinition.RuleName);
        }

        var genericValidationRuleType = validationRuleType.MakeGenericType(formFieldDataType);

        if (validationRuleDefinition.RuleValue is null)
        {
            return (IValidationRule)Activator.CreateInstance(genericValidationRuleType, validationRuleDefinition.ErrorMessageFormat);
        }
        else
        {
            return (IValidationRule)Activator.CreateInstance(genericValidationRuleType, validationRuleDefinition.RuleValue, validationRuleDefinition.ErrorMessageFormat);
        }
    }
}
