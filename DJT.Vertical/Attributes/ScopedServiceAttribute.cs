using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.Vertical.Attributes
{
    /// <summary>
    /// Register the class with the DI as a scoped service,
    /// optionally supplying a key
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ScopedServiceAttribute : Attribute
    {
        /// <summary>
        /// Register the class as a scoped service
        /// </summary>
        public ScopedServiceAttribute() { }

        /// <summary>
        /// Register the class as a scoped service which implements type <see cref="ImplementsType"/>
        /// </summary>
        /// <param name="implements">The type which the decorated class implements</param>
        /// <param name="key">The keyed type</param>
        public ScopedServiceAttribute(Type implements, string key = "")
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
