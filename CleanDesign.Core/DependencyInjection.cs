using CleanDesign.Core.Mapping;
using CleanDesign.Core.Services;
using CleanDesign.Core.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDesign.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreLayer(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(CoreMappingProfile));
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
