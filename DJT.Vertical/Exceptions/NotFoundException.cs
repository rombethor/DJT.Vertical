namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Provides a 404 Not Found status for the request.
    /// </summary>
    public sealed class NotFoundException : VerticalException
    {
        /// <summary>
        /// Default empty constructor
        /// </summary>
        public NotFoundException()
        {
        }

        /// <summary>
        /// Provide a custom message to accompany the 404 response.
        /// </summary>
        /// <param name="message">Custom error message</param>
        public NotFoundException(string message) : base(message)
        {
        }

        /// <summary>
        /// Provide a custom message with member names for additional information.
        /// </summary>
        /// <param name="error"></param>
        /// <param name="properties"></param>
        public NotFoundException(string error, params string[] properties)
            : base(error, properties)
        { }

        /// <summary>
        /// 404 Not Found
        /// </summary>
        public override int StatusCode => 404;
    }
}
