using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application;
using Product.Application.Interfaces;
using Product.Application.Services;
using Product.Domain.Interfaces;
using Product.Infra.Repositories;

namespace Product.Infra
{
    public static class InversionControl
    {
        public static void AddInfraestructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(
                context => context.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            serviceCollection.AddAutoMapper(typeof(AutoMapperConfiguration));

            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
