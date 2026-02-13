using MemberManagement.Domain.Interfaces;
using MemberManagement.Infrastracture.Data;
using MemberManagement.Infrastracture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MemberManagement.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastractureDI(this IServiceCollection services, IConfiguration configuration)
        {
            //Add the connection string to connect to the server and database
            //Connection string is in appsetting.json file
            services.AddDbContext<MemberManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MemberManagementConnection"));
            });

            //Add the Interfaces and its Repository to service collection for building
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            return services;
        }
    }
}
