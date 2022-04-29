using Forum4TE.Domain.Interfaces;
using Forum4TE.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Forum4TE.DependencyInjection.Service
{
    public static class ServiceDependencyInjection
    {
        public static void ServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
