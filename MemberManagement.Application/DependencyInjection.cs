using MemberManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MemberManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            //Add Service classes to service collection
            services.AddScoped<MemberService>();
            services.AddScoped<HomeService>();
            return services;
        }
    }
}
