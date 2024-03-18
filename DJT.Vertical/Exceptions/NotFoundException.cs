namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Provides a 404 Not Found status for the request.
    /// </summary>
    public class NotFoundException : Exception
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
        public NotFoundException(string? message) : base(message)
        {
        }
    }
}
