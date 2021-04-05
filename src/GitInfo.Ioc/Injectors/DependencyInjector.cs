
using GitInfo.Data.Repositories;
using GitInfo.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GitInfo.Ioc.Injectors
{
    public class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<FileInfoService>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            services.Scan(scan => scan
                .FromAssemblyOf<GithubRepository>()
                .AddClasses()
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}