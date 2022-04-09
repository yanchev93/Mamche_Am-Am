namespace MamcheAmAm.Web.ViewModels.ValidationAttributes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            this.maxFileSize = maxFileSize;
        }

        public string GetErrorMessage(string name)
        {
            return $"{name}'s size is out of range. Maximum allowed file size is {this.maxFileSize} bytes.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var files = value as IList<IFormFile>;
            foreach (var file in files)
            {
                if (file != null)
                {
                    if (file.Length > this.maxFileSize)
                    {
                        return new ValidationResult(this.GetErrorMessage(file.FileName));
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
