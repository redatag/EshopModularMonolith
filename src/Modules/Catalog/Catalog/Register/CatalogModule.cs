using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Register
{
    //make static class because we develop an extension method
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(IServiceCollection services, IConfiguration configuration)
        {

            return services;
        }
    }
}
