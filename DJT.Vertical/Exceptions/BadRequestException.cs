using System.ComponentModel.DataAnnotations;

namespace DJT.Vertical.Exceptions
{
    public class BadRequestException : ValidationException
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string error, params string[] properties)
            : base(new ValidationResult(error, properties), null, null)
        { }

        public BadRequestException(string? message) : base(message)
        {
        }

        public BadRequestException(ValidationResult validationResult, ValidationAttribute? validatingAttribute, object? value) : base(validationResult, validatingAttribute, value)
        {
        }
    }
}
