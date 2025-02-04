using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanDesign.Core.Data.Repositories;
using CleanDesign.Core.Services.Implementations;
using CleanDesign.Data.Repositories;

namespace CleanDesign.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, string connectionString) 
        {
            services.AddScoped<IDbConnection>(s => new SqlConnection(connectionString));
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
