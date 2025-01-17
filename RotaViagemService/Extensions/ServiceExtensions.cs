using Contracts.Managers;
using Contracts.Mappers;
using Contracts.Repositories.Repo;
using Managers;
using Managers.Mappers;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repo;

namespace RotaViagemService.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection ConfigureManagers(this IServiceCollection services)
        {

            services.AddScoped<IMelhorTrajetoManager, MelhorTrajetoManager>();
            services.AddScoped<IPernaRepo, PernaRepo>();
            services.AddScoped<IPernaMapping, PernaMapping>();
            services.AddScoped<IMelhorTrajetoMapping, MelhorTrajetoMapping>();

            return services;
        }

    }
}
