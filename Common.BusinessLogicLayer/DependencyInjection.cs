
using Common.BusinessLogicLayer.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BusinessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDBL(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IRPLServices, RPLServices>();
            services.AddTransient<IPurchaseSaleService, PurchaseSaleService>();
            return services;
        }
    }
}
