using Maui.DataForms.FormFields;
using Maui.DataForms.Models;
using System.Collections.ObjectModel;

namespace Maui.DataForms;

public class DynamicDataForm<TModel>
    where TModel : IDictionary<string, object>
{
    private static IDictionary<string, Type> mappedFormFields = new Dictionary<string, Type>
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

    private static IDictionary<string, Type> mappedDataTypes = new Dictionary<string, Type>
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

    public ObservableCollection<FormFieldBase> Fields { get; init; }

    public TModel Model { get; }

    public static void MapDynamicFormField<TFormField>(string formFieldName)
    {
        mappedDataTypes.TryAdd(formFieldName, typeof(TFormField));
    }
}
