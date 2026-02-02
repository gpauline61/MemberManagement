using MemberManagement.Domain.Interfaces;
using MemberManagement.Infrastracture.Data;
using MemberManagement.Infrastracture.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastractureDI(this IServiceCollection services)
        {
            services.AddDbContext<MemberManagementDbContext>(options =>
            {
                options.UseSqlServer("Data Source=ARDCI-PC\\SQLEXPRESS;Initial Catalog=MMSDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
            });
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IHomeRepository, HomeRepository>();
            return services;
        }
    }
}
