using System.ComponentModel.DataAnnotations;

namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// The base class for all exceptions that map to status codes.
    /// Inherits from ValidationException to provide ValidationResult support.
    /// </summary>
    public abstract class VerticalException : ValidationException
    {
        /// <summary>
        /// Specify error and member names.
        /// </summary>
        /// <param name="error"></param>
        /// <param name="properties"></param>
        public VerticalException(string error, params string[] properties)
            : base(new ValidationResult(error, properties), null, null)
        { }

        /// <summary>
        /// Specify a ValidationResult
        /// </summary>
        /// <param name="validationResult"></param>
        public VerticalException(ValidationResult validationResult)
            : base(validationResult, null, null)
        { }

        /// <summary>
        /// Fills out the exception with validation data
        /// </summary>
        /// <param name="validationResult"></param>
        /// <param name="validatingAttribute"></param>
        /// <param name="value"></param>
        public VerticalException(ValidationResult validationResult, ValidationAttribute? validatingAttribute, object? value)
            : base(validationResult, validatingAttribute, value)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalException"/> class.
        /// </summary>
        public VerticalException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VerticalException"/> class with the specified error message.
        /// </summary>
        /// <remarks>Use this constructor to create a <see cref="VerticalException"/> when you have a
        /// single error message to report.</remarks>
        /// <param name="error">The error message that describes the reason for the exception.</param>
        public VerticalException(string error)
            : base(new ValidationResult(error), null, null)
        { }

        /// <summary>
        /// The HTTP status code equivalent to return
        /// </summary>
        public abstract int StatusCode { get; }

        /// <summary>
        /// Gets the body of the exception detail.  By default, this is the ValidationResult.
        /// To work with HTTP responses, this should be serializable to JSON.
        /// </summary>
        public virtual object? Body => base.ValidationResult;
    }
}
