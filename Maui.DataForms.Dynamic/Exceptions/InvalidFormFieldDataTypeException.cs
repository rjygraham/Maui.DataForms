namespace Maui.DataForms.Exceptions;

internal class InvalidFormFieldDataTypeException : Exception
{
    public string DataType { get; set; }

    public InvalidFormFieldDataTypeException(string dataType)
        : base($"Data type {dataType} is invalid.")
    {
        DataType = dataType;
    }
}
