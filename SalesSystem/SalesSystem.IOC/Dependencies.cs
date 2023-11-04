using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SalesSystem.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
//using SalesSystem.DAL.Interfaces;
//using SalesSystem.DAL.Implementations;
//using SalesSystem.BLL.Implementations;
//using SalesSystem.BLL.Interfaces;






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
        }
    }
}
