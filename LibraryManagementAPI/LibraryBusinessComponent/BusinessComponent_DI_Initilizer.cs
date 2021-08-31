
using LibraryDataAccess.Abstract;
using LibraryDataAccess.Concrete;
using LibraryDataAccess.DataEntityModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LibraryBusinessComponents
{
     
    public static class BusinessComponent_DI_Initilizer
    {
        public static void InjectBusinessComponentServices(this IServiceCollection services, IConfiguration configuration)
        {
            string cnctnString = configuration["ConnectionStrings:LibraryDBConnection"];
            //services.AddDbContext<LibraryDBContext>(
            //    options => options.UseSqlServer("Data Source=DESKTOP-AKL9PPB\\SQLEXPRESS;Initial Catalog=LibraryDB;User ID=sa;Password=1234;MultipleActiveResultSets=true")
            //    );
            services.AddDbContext<LibraryDBContext>(
                options => options.UseSqlServer(cnctnString)
                );

            services.AddScoped<IBookRepository, BookRepository>();
            //services.AddScoped<IEmailFacades, SendGridEmailFacades>();//Any Other Service injection we can assign here
        }
    }
}
