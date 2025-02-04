using CleanDesign.Core.ThirdPartyServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.ISBNService
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddISBNProvider(this IServiceCollection services)
        {
            services.AddScoped<IISBNSearchService, Service>();

            return services;
        }
    }
}
