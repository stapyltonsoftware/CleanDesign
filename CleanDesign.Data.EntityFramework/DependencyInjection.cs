using CleanDesign.Core.Data.Repositories;
using CleanDesign.Data.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanDesign.Data.EntityFramework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEFDataLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BooksDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
