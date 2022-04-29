using Forum4TE.Repository.Repositories;
using Forum4TE.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Forum4TE.DependencyInjection.Repository
{
    public static class RepositoryDependencyInjection
    {
        public static void RepositoryDI(this IServiceCollection services)
        {
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
