namespace DJT.Vertical.Exceptions
{
    /// <summary>
    /// Indicates a 402 status code response for the request.
    /// The cost of the request cannot be covered.
    /// </summary>
    public sealed class PaymentRequiredException : VerticalException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public PaymentRequiredException()
        {
        }

        /// <summary>
        /// Payment required exception with message.
        /// </summary>
        /// <param name="message"></param>
        public PaymentRequiredException(string message) : base(message)
        {
        }

        /// <summary>
        /// Payment required exception with message and properties.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        public PaymentRequiredException(string message, params string[] properties) : base(message, properties)
        {
        }

        /// <summary>
        /// 402 Payment Required
        /// </summary>
        public override int StatusCode => 402;
    }
}
