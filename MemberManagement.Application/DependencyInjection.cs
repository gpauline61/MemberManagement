using MemberManagement.Application.Interface;
using MemberManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MemberManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        { 
            //Add Service classes to service collection
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<HomeService>();
            services.AddScoped<IBranchService, BranchService>();
            return services;
        }
    }
}
