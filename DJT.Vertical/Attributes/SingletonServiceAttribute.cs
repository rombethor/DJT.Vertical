namespace DJT.Vertical.Attributes
{
    /// <summary>
    /// Register the class with the DI as a singleton service,
    /// optionally supplying a key
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SingletonServiceAttribute : Attribute
    {
        /// <summary>
        /// Registers the class as a singleton service.
        /// </summary>
        public SingletonServiceAttribute() { }

        /// <summary>
        /// Imeplements the decorated class as an singleton implementation of
        /// <see cref="ImplementsType"/>.  If the key is set, it will be a keyed
        /// service.
        /// </summary>
        /// <param name="implements"></param>
        /// <param name="key"></param>
        public SingletonServiceAttribute(Type implements, object? key = null)
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
        public object? Key { get; set; } = null;
    }
}
