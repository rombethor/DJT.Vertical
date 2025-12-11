namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Provide a custom status code
    /// </summary>
    public sealed class CustomStatusException : VerticalException
    {
        private readonly int _statusCode;

        /// <summary>
        /// The status code provided by this exception
        /// </summary>
        public override int StatusCode => _statusCode;

        private readonly object? _customBody = null;

        /// <summary>
        /// The body for the response
        /// </summary>
        public override object? Body => _customBody ?? ValidationResult;

        /// <summary>
        /// Provide a custom status code
        /// </summary>
        /// <param name="statusCode"></param>
        public CustomStatusException(int statusCode)
        {
            _statusCode = statusCode;
        }

        public CustomStatusException(int statusCode, string error)
            : base(error)
        {
            _statusCode = statusCode;
        }

        public CustomStatusException(int statusCode, string error, params string[] propertyNames)
            : base(error, propertyNames)
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
            _customBody = body;
        }
    }
}
