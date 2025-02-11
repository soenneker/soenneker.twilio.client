using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Twilio.Client.Abstract;

namespace Soenneker.Twilio.Client.Registrars
{
    /// <summary>
    /// An async thread-safe singleton for the Twilio client
    /// </summary>
    public static class TwilioClientUtilRegistrar
    {
        /// <summary>
        /// Adds <see cref="ITwilioClientUtil"/> as a singleton service. <para/>
        /// </summary>
        public static IServiceCollection AddTwilioClientUtilAsSingleton(this IServiceCollection services)
        {
            services.TryAddSingleton<ITwilioClientUtil, TwilioClientUtil>();
            return services;
        }

        /// <summary>
        /// Adds <see cref="ITwilioClientUtil"/> as a scoped service. <para/>
        /// </summary>
        public static IServiceCollection AddTwilioClientUtilAsScoped(this IServiceCollection services)
        {
            services.TryAddScoped<ITwilioClientUtil, TwilioClientUtil>();
            return services;
        }
    }
}