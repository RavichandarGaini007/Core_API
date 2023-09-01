using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataAccessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration Configuration)
        { 
            services.AddTransient<IDBConnection, DBConnection>();
            services.AddTransient<IDAL, DAL>();
            return services;
        }
    }
}
