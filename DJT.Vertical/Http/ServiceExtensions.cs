using DJT.Vertical.Attributes;
using DJT.Vertical.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace DJT.Vertical.Http
{
    /// <summary>
    /// Extension methods for using the components in this library
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds generic AuthService dependency and registers IRequestHandlers in the calling assembly
        /// </summary>
        /// <param name="services"></param>
        public static void AddVerticalComponents(this IServiceCollection services)
        {
            services.TryAddScoped<AuthService>();

            var allTypes = Assembly.GetCallingAssembly().GetTypes();
            foreach(var type in allTypes)
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
                        if (t.Key != string.Empty)
                        {
                            services.TryAddKeyedTransient(type, t.Key, t.ImplementsType);
                        }
                        else
                        {
                            services.TryAddTransient(type, t.ImplementsType);
                        }
                    }
                    else
                    {
                        if (t.Key != string.Empty)
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
                        if (s.Key  != string.Empty)
                        {
                            services.TryAddKeyedScoped(s.ImplementsType, s.Key, type);
                        }
                        else
                        {
                            services.TryAddScoped(s.ImplementsType, s.ImplementsType);
                        }
                    }
                    else
                    {
                        if (s.Key != string.Empty)
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
                        if (z.Key != string.Empty)
                        {
                            services.TryAddKeyedSingleton(type, z.Key, z.ImplementsType);
                        }
                        else
                        {
                            services.TryAddSingleton(type, z.ImplementsType);
                        }
                    }
                    else
                    {
                        if (z.Key != string.Empty)
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

        /// <summary>
        /// Adds client error handling middleware for web api
        /// </summary>
        /// <param name="app"></param>
        public static void UseVerticalComponents(this IApplicationBuilder app)
        {
            app.UseMiddleware<ClientErrorMiddleware>();
        }
    }
}
