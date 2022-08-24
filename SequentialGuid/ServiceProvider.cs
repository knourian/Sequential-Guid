using Microsoft.Extensions.DependencyInjection;

namespace SequentialGuid
{
    public static class ServiceProvider
    {
        public static IServiceCollection AddSequentialGuid(this IServiceCollection services)
        {
            services.AddSingleton<ISequentialGuid, SequentialGuid>();
            return services;
        }
    }
}