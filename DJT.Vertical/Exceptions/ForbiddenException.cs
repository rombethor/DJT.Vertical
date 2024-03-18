namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Provides a 403 Forbidden status result.
    /// </summary>
    public class ForbiddenException : Exception
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ForbiddenException() { }

        /// <summary>
        /// Provide a custom status message
        /// </summary>
        /// <param name="message">Custom message for the response</param>
        public ForbiddenException(string? message) : base(message)
        {
        }
    }
}
