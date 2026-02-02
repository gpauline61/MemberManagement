using MemberManagement.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemberManagement.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDI(this IServiceCollection services)
        {
            return services;
        }
    }
}
