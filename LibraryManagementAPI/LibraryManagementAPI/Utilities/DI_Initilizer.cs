using LibraryBusinessComponents;
using LibraryBusinessComponents.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Utilities
{
    public static class DI_Initilizer
    {
        public static void InjectComponentServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.InjectBusinessComponentServices(configuration); //This is the layer of Business Component's dependent layers' Dependency injection

            services.AddScoped<IBookBusinessComponent, BookBusinessComponent>();
        }
    }
}
