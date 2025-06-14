using DJT.Vertical.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace DJT.Vertical
{
    /// <summary>
    /// Extension methods for using the components in this library
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Registers IRequestHandler implementations and services with the <see cref="ScopedServiceAttribute"/>, <see cref="SingletonServiceAttribute"/> 
        /// and <see cref="TransientServiceAttribute"/> attributes with the DI container.
        /// </summary>
        /// <param name="services"></param>
        public static void AddVerticalComponents(this IServiceCollection services)
        {
            var allTypes = Assembly.GetCallingAssembly().GetTypes();
            foreach (var type in allTypes)
            {
                //transient IRequestHandler
                var i = type.GetInterface("IRequestHandler`1")
                    ?? type.GetInterface("IRequestHandler`2")
                    ?? type.GetInterface("IRequestHandler`3");
                if (i is not null)
                {
                    services.TryAddTransient(type);
                }

                //transients
                var t = type.GetCustomAttribute<TransientServiceAttribute>();

                if (t is not null)
                {
                    if (t.ImplementsType is not null)
                    {
                        if (t.Key != null)
                        {
                            services.TryAddKeyedTransient(t.ImplementsType, t.Key, type);
                        }
                        else
                        {
                            services.TryAddTransient(t.ImplementsType, type);
                        }
                    }
                    else
                    {
                        if (t.Key != null)
                        {
                            services.TryAddKeyedTransient(type, t.Key);
                        }
                        else
                        {
                            services.TryAddTransient(type);
                        }
                    }

                }

                //scoped
                var s = type.GetCustomAttribute<ScopedServiceAttribute>();

                if (s is not null)
                {
                    if (s.ImplementsType is not null)
                    {
                        if (s.Key != null)
                        {
                            services.TryAddKeyedScoped(s.ImplementsType, s.Key, type);
                        }
                        else
                        {
                            services.TryAddScoped(s.ImplementsType, type);
                        }
                    }
                    else
                    {
                        if (s.Key != null)
                        {
                            services.TryAddKeyedScoped(type, s.Key);
                        }
                        else
                        {
                            services.TryAddScoped(type);
                        }
                    }
                }

                //singleton
                var z = type.GetCustomAttribute<SingletonServiceAttribute>();
                if (z is not null)
                {
                    if (z.ImplementsType is not null)
                    {
                        if (z.Key != null)
                        {
                            services.TryAddKeyedSingleton(z.ImplementsType, z.Key, type);
                        }
                        else
                        {
                            services.TryAddSingleton(z.ImplementsType, type);
                        }
                    }
                    else
                    {
                        if (z.Key != null)
                        {
                            services.TryAddKeyedSingleton(service: type, serviceKey: z.Key);
                        }
                        else
                        {
                            services.TryAddSingleton(type);
                        }
                    }
                }

            }
        }


    }
}
