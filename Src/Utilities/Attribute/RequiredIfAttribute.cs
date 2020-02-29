using System.ComponentModel.DataAnnotations;

namespace Utilities.Attribute
{
    public class RequiredIfAttribute : ValidationAttribute
    {
        private string PropertyName { get; set; }
        private new string ErrorMessage { get; set; }
        private object DesiredValue { get; set; }

        public RequiredIfAttribute(string propertyName, object desiredvalue, string errormessage)
        {
            this.PropertyName = propertyName;
            this.DesiredValue = desiredvalue;
            this.ErrorMessage = errormessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            if (value != null) { return ValidationResult.Success; }

            var instance = context.ObjectInstance;
            var type = instance.GetType();
            var proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            return proprtyvalue == null ? new ValidationResult(ErrorMessage) : ValidationResult.Success;
        }
    }
}
