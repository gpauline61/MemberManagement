using MemberManagement.Application;
using MemberManagement.Domain;
using MemberManagement.Infrastracture;

namespace MemberManagement.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebDI(this IServiceCollection services, IConfiguration configuration)
        {
            //Adding all services listed to each dependency injection per layer
            //Added configuration parameter for the connection string
            //AddWebDI will be added to Program.cs as a collection of all
            //services included to each layer
            services.AddApplicationDI()
                .AddInfrastractureDI(configuration).AddDomainDI();
            return services;
        }
    }
}
