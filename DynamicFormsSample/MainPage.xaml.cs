using Maui.DataForms.Models;
using Maui.DataForms;
using System.Text.Json;

namespace DynamicFormsSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            options.Converters.Add(new SystemObjectNewtonsoftCompatibleConverter());

            var dataFormDefinition = JsonSerializer.Deserialize<DataFormDefiniton>(dynamicFormJson, options);

            BindingContext = DynamicDataForm.Create(dataFormDefinition);
        }

        private string dynamicFormJson = """
        {
            "id": "e5d97ee7-500c-4fbf-88aa-6ddbd74691e8",
            "name": "Person Form",
            "etag": 1664738021,
            "remoteUri": "",
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
                            "ruleValue": 20
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
                            "ruleName": "notEmpty"
                        },
                        {
                            "ruleName": "maximumLength",
                            "ruleValue": 20,
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
                            "ruleValue": "2004-09-20T01:29:57"
                        }
                    ],
                    "configuration": {
                        "minimumDate": "2004-09-20T01:29:57",
                        "maximumDate": "2022-09-20T01:29:57"
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 2
                    }
                }
            ]
        }
        """;
    }
}