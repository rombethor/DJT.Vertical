using System.ComponentModel.DataAnnotations;

namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Returns a 400 status code.  Based on <see cref="ValidationException"/>.
    /// </summary>
    public sealed class BadRequestException : VerticalException
    {
        /// <summary>
        /// 400 Bad Request
        /// </summary>
        public override int StatusCode => 400;

        /// <summary>
        /// 
        /// </summary>
        public BadRequestException() : base("The request contents or format was unacceptable")
        {
        }

        /// <summary>
        /// Provide validation data for the specified properties
        /// </summary>
        /// <param name="error">Error message</param>
        /// <param name="properties">Erroneous properties</param>
        public BadRequestException(string error, params string[] properties)
            : base(new ValidationResult(error, properties))
        { }

        /// <summary>
        /// Provide a specific message
        /// </summary>
        /// <param name="message"></param>
        public BadRequestException(string message) : base(message)
        {
        }

        /// <summary>
        /// Wraps a ValidationException
        /// </summary>
        /// <param name="validationResult"></param>
        /// <param name="validatingAttribute"></param>
        /// <param name="value"></param>
        public BadRequestException(ValidationResult validationResult, ValidationAttribute? validatingAttribute, object? value) : base(validationResult, validatingAttribute, value)
        {
        }
    }
}
