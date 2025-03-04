using DemoCRUD.Domain.RepositoryInterface;
using DemoCRUD.Infrastructure.DatabaseContext;
using DemoCRUD.Infrastructure.RepositoryImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService
            (this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(config.GetConnectionString("Default"))
            );
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
