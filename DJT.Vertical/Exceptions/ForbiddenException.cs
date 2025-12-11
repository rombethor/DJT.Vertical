namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Provides a 403 Forbidden status result.
    /// </summary>
    public sealed class ForbiddenException : VerticalException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ForbiddenException() { }

        /// <summary>
        /// Provide a custom status message
        /// </summary>
        /// <param name="message">Custom message for the response</param>
        public ForbiddenException(string message) : base(message)
        {
        }

        /// <summary>
        /// Provide a custom message with member names for additional information.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        public ForbiddenException(string message, params string[] properties) : base(message, properties)
        {
        }

        /// <summary>
        /// 403 Forbidden
        /// </summary>
        public override int StatusCode => 403;
    }
}
