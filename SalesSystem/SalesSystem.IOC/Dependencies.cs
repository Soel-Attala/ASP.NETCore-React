using Microsoft.Extensions.DependencyInjection;
using SalesSystem.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SalesSystem.DAL.Interfaces;
using SalesSystem.DAL.Implementations;
using SalesSystem.BLL.Interfaces;
using SalesSystem.BLL.Implementations;
using SalesSystem.BLL.Interfaces;






namespace SalesSystem.IOC
{
    public static class Dependencies
    {
        public static void DependenciesInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SALESDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLChain"));

            });


            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISalesRepository, SalesRepository>();

            services.AddScoped<IMailServices, MailServices>();
            services.AddScoped<IFirebaseServices, FirebaseServices>();

            services.AddScoped<IUtilityServices, UtilityServices>();
            services.AddScoped<IRoleServices, RoleServices>();
        }
    }
}
