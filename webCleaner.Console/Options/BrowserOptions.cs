using System;
using System.ComponentModel.DataAnnotations;

namespace webCleaner.Options
{
    public enum BrowserOption {
        Chrome,
        FireFox,
        IE,
        Edge
    };

    class BrowserAttribute: ValidationAttribute
    {
        public BrowserAttribute(): base()
        {
            var validBrowser = String.Join(" or ", Enum.GetNames(typeof(BrowserOption)));
            ErrorMessage = $"The value for {{0}} must be {validBrowser}";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || (value is string str && str != "Chrome" && str != "Chromium" && str != "FireFox" && str != "IE" && str != "Edge"))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}