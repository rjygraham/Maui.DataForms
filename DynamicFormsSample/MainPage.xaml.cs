using DynamicFormsSample.Forms.Models;
using System.Text.Json;

namespace DynamicFormsSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var dynamicForm = JsonSerializer.Deserialize<FormDefiniton>(dynamicFormJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }

        private string dynamicFormJson = """
        {
            "id": "e5d97ee7-500c-4fbf-88aa-6ddbd74691e8",
            "etag": 1664738021,
            "fields": {
                "firstName": {
                    "dataType": "string",
                    "controlTemplateName": "Entry",
                    "validationRules": {
                        "notEmpty": true,
                        "maximumLength": 20
                    },
                    "configuration": {
                        "placeholder": "First Name"
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 0
                    }
                },
                "lastName": {
                    "dataType": "string",
                    "controlTemplateName": "Entry",
                    "validationRules": {
                        "notEmpty": true,
                        "maximumLength": 20
                    },
                    "configuration": {
                        "placeholder": "Last Name"
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 1
                    }
                },
                "dateOfBirth": {
                    "dataType": "DateTimeOffset",
                    "controlTemplateName": "DatePicker",
                    "validationRules": {
                        "greaterThanOrEqual": "9/20/2004 1:29:57 AM +00:00"
                    },
                    "configuration": {
                        "minimumDate": "9/20/2004 1:29:57 AM +00:00",
                        "maximumDate": "9/20/2022 1:29:57 AM +00:00"
                    },
                    "layout": {
                        "gridColumn": 0,
                        "gridRow": 2
                    }
                }
            }
        }
        """;
    }
}