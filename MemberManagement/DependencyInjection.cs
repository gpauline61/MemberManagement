using MemberManagement.Application;
using MemberManagement.Domain;
using MemberManagement.Infrastracture;

namespace MemberManagement.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebDI(this IServiceCollection services)
        {
            services.AddApplicationDI()
                .AddInfrastractureDI().AddDomainDI();
            return services;
        }
    }
}
