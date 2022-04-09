namespace MamcheAmAm.Web.ViewModels.ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;

    using Microsoft.AspNetCore.Http;

    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            this.extensions = extensions;
        }

        public string GetErrorMessage(string name)
        {
            return $"{name} extension is not allowed! Allowed extensions are - {string.Join(" / ", this.extensions)}";
        }

        protected override ValidationResult IsValid(
        object value, ValidationContext validationContext)
        {
            var files = value as IList<IFormFile>;
            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName);
                if (file != null)
                {
                    if (!this.extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult(this.GetErrorMessage(file.FileName));
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
