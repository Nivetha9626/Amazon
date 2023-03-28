using Microsoft.Extensions.DependencyInjection;

namespace Amazon.Infrastructure
{
    public static class InfrastructureDI
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            //services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString)); 

            //di
            services.AddScoped(typeof(IApplicationDbContextFactory), (dbContext) =>
            {
                var abc = new DbContextFactory(connectionString);
                return abc;
            });

            //services.AddScoped(typeof(IApplicationDbContextFactory), (dbContext) =>
            //{
            //    return new xmlContextFactory(connectionString); //xml,file,json
            //});
            return services;
        }
    }
}