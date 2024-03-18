namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Provide a custom status code
    /// </summary>
    public class CustomStatusException : Exception
    {
        private readonly int _statusCode;

        /// <summary>
        /// The status code provided by this exception
        /// </summary>
        public int StatusCode => _statusCode;

        private readonly object? _body;

        /// <summary>
        /// The body for the response
        /// </summary>
        public object? Body => _body;

        /// <summary>
        /// Provide a custom status code
        /// </summary>
        /// <param name="statusCode"></param>
        public CustomStatusException(int statusCode)
        {
            _statusCode = statusCode;
        }

        /// <summary>
        /// Provide a custom status code and body for the response
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="body"></param>
        public CustomStatusException(int statusCode, object? body)
        {
            _statusCode = statusCode;
            _body = body;
        }
    }
}
