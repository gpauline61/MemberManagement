<<<<<<< HEAD
﻿using MemberManagement.Application.Interface;
using MemberManagement.Application.Services;
=======
﻿using MemberManagement.Application.Services;
using MemberManagement.Application.Interface;
>>>>>>> feature/membership
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
<<<<<<< HEAD
            services.AddScoped<IBranchService, BranchService>();
=======

            services.AddScoped<IMembershipService, MembershipService>();
>>>>>>> feature/membership
            return services;
        }
    }
}
