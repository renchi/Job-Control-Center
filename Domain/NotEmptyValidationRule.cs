using System.Globalization;
using System.Windows.Controls;
using JobControlCenter.Domain;
using MaterialDesignThemes.Wpf;


namespace JobControlCenter.Domain
{
    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())
                ? new ValidationResult(false, "Field is required.")
                : ValidationResult.ValidResult;
        }
    }
}
