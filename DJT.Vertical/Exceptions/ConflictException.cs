namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Provides a 409 status response, indicating Conflict.
    /// </summary>
    public sealed class ConflictException : VerticalException
    {
        /// <summary>
        /// Default exception
        /// </summary>
        public ConflictException() { }

        /// <summary>
        /// Provides the HTTP status code equivalent to return
        /// </summary>
        public override int StatusCode => 409;

        /// <summary>
        /// Provide a custom error message
        /// </summary>
        /// <param name="message"></param>
        public ConflictException(string message) : base(message)
        {
        }

        public ConflictException(string error, params string[] properties)
            : base(error, properties)
        { }
    }
}
