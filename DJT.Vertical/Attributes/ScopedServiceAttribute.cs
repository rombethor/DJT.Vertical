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
        /// If supplied, the service will be registered as a keyed service
        /// </summary>
        public string Key { get; set; } = string.Empty;
    }
}
