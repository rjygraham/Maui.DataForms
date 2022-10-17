using CommunityToolkit.Mvvm.ComponentModel;
using Maui.DataForms.Models;
using System.Text.Json;

namespace Maui.DataForms.Sample.ViewModels;

public partial class DynamicDemoPageViewModel : ObservableObject
{
    [ObservableProperty]
    private DynamicDataForm personDataForm;

    public DynamicDemoPageViewModel()
    {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        options.Converters.Add(new SystemObjectNewtonsoftCompatibleConverter());

        var dataFormDefinition = JsonSerializer.Deserialize<DataFormDefiniton>(json, options);

        PersonDataForm = DynamicDataForm.Create(dataFormDefinition);
    }

    private const string json =
        """
        {
            "id": "personForm",
            "name": "Person Form",
            "etag": 1664738021,
            "fields": [
                {
                    "id": "firstName",
                    "name": "First Name",
                    "dataType": "string",
                    "controlTemplateName": "Entry",
                    "validationMode": 0,
                    "validationRules": [
                        {
                            "ruleName": "notEmpty",
                            "errorMessageFormat": "First Name must not be empty."
                        },
                        {
                            "ruleName": "maximumLength",
                            "ruleValue": 20,
                            "errorMessageFormat": "First Name must not be longer than {0} characters."
                        }
                    ],
                    "configuration": {
                        "placeholder": "First Name"
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 0
                    }
                },
                {
                    "id": "lastName",
                    "name": "Last Name",
                    "dataType": "string",
                    "controlTemplateName": "Entry",
                    "validationMode": 0,
                    "validationRules": [
                        {
                            "ruleName": "notEmpty",
                            "errorMessageFormat": "Last Name must not be empty."
                        },
                        {
                            "ruleName": "maximumLength",
                            "ruleValue": 50,
                            "errorMessageFormat": "Last Name must not be longer than {0} characters."
                        }
                    ],
                    "configuration": {
                        "placeholder": "Last Name"
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 1
                    }
                },
                {
                    "id": "dateOfBirth",
                    "name": "Date Of Birth",
                    "dataType": "DateTime",
                    "controlTemplateName": "DatePicker",
                    "validationMode": 0,
                    "validationRules": [
                        {
                            "ruleName": "greaterThanOrEqual",
                            "ruleValue": "2000-01-01T00:00:00",
                            "errorMessageFormat": "Date Of Birth must not be greater than or equal to {0}."
                        },
                        {
                            "ruleName": "lessThanOrEqual",
                            "ruleValue": "2021-12-31T23:59:59",
                            "errorMessageFormat": "Date Of Birth must not be less than or equal to {0}."
                        }
                    ],
                    "configuration": {
                        "format": "D",
                        "minimumDate": "0001-01-01T00:00:00",
                        "maximumDate": "9999-12-31T23:59:59"
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 2
                    }
                },
                {
                    "id": "timeOfBirth",
                    "name": "Time Of Birth",
                    "dataType": "TimeSpan",
                    "controlTemplateName": "TimePicker",
                    "validationMode": 0,
                    "configuration": {
                        "format": "t"
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 3
                    }
                },
                {
                    "id": "biography",
                    "name": "Biography",
                    "dataType": "string",
                    "controlTemplateName": "Editor",
                    "validationMode": 0,
                    "validationRules": [
                        {
                            "ruleName": "notEmpty",
                            "errorMessageFormat": "Biography must not be empty."
                        },
                        {
                            "ruleName": "maximumLength",
                            "ruleValue": 500,
                            "errorMessageFormat": "Biography must not be longer than {0} characters."
                        }
                    ],
                    "configuration": {
                        "placeholder": "Biography"
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 4
                    }
                },
                {
                    "id": "height",
                    "name": "Height",
                    "dataType": "double",
                    "controlTemplateName": "Slider",
                    "validationMode": 0,
                    "validationRules": [
                        {
                            "ruleName": "greaterThan",
                            "ruleValue": 0.2,
                            "errorMessageFormat": "Height must not be greater than {0}."
                        },
                        {
                            "ruleName": "lessThanOrEqual",
                            "ruleValue": 0.8,
                            "errorMessageFormat": "Height must be less than or equal to {0}."
                        }
                    ],
                    "configuration": {
                        "minimum": 0.1,
                        "maximum": 0.9
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 5
                    }
                },
                {
                    "id": "weight",
                    "name": "Weight",
                    "dataType": "double",
                    "controlTemplateName": "Stepper",
                    "validationMode": 0,
                    "validationRules": [
                        {
                            "ruleName": "greaterThan",
                            "ruleValue": 20.0,
                            "errorMessageFormat": "Weight must not be greater than {0}."
                        },
                        {
                            "ruleName": "lessThanOrEqual",
                            "ruleValue": 80.0,
                            "errorMessageFormat": "Weight must be less than or equal to {0}."
                        }
                    ],
                    "configuration": {
                        "minimum": 10.0,
                        "maximum": 90.0
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 6
                    }
                },
                {
                    "id": "likesPizza",
                    "name": "Likes Pizza",
                    "dataType": "bool",
                    "controlTemplateName": "Switch",
                    "validationMode": 0,
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 7
                    }
                },
        {
                    "id": "isActive",
                    "name": "Is Active",
                    "dataType": "bool",
                    "controlTemplateName": "CheckBox",
                    "validationMode": 0,
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 8
                    }
                }
            ]
        }
        """;
}
