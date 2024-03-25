namespace DJT.Vertical.Attributes
{
    /// <summary>
    /// Register the class with the DI as a transient service,
    /// optionally supplying a key
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TransientServiceAttribute : Attribute
    {
        /// <summary>
        /// Registers the decorated class with the DI container as
        /// a transient service.
        /// </summary>
        public TransientServiceAttribute() { }

        /// <summary>
        /// Registers the decorated class as a transient service
        /// which implements the given type <see cref="ImplementsType"/>
        /// and with the given key if included.
        /// </summary>
        /// <param name="implements">The type the class implements.</param>
        /// <param name="key">If provided, the keyed service</param>
        public TransientServiceAttribute(Type implements, string key = "")
        {
            ImplementsType = implements;
            Key = key;
        }

        /// <summary>
        /// The type (typically interface) which this scoped service implements
        /// </summary>
        public Type? ImplementsType { get; set; }

        /// <summary>
        /// If supplied, the service will be registered as a keyed service
        /// </summary>
        public string Key { get; set; } = string.Empty;
    }
}
