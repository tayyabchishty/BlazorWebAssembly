using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebAssembly.Shared.Utilities
{
    public class AllowedEmailDomainAttribute : ValidationAttribute
    {

        public AllowedEmailDomainAttribute(string allowedDomain)
        {
            AllowedDomain = allowedDomain;
        }

        public string AllowedDomain { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value.ToString().Length == 0)
            {
                return new ValidationResult("Email address is required");
            }
            else
            {
                if (value.ToString().IndexOf('@') == -1)
                {
                    return new ValidationResult("Invalid email address");
                }

                string[] strings = value.ToString().Split('@');
                if (strings[1].ToLower() == AllowedDomain.ToLower())
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(this.ErrorMessage ?? $"Email domain must be {AllowedDomain}");
                }
            }
        }
    }
}
