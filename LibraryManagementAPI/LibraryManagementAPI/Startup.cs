using LibraryManagementAPI.Auth.Abstract;
using LibraryManagementAPI.Auth.Concrete;
using LibraryManagementAPI.Middleware;
using LibraryManagementAPI.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
            //    .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));
            services.AddControllers();


            #region :: Section for Token based Authentication
            //https://dotnetcorecentral.com/blog/authentication-handler-in-asp-net-core/
            //https://www.youtube.com/watch?v=vWkPdurauaA 

            var tokenKey = "azFUTnuipOzvloeLV2vBsB3i4cNDKdOBR8p2t56uwp6o52iO9opnbxohWR8FB7cj";// Configuration.GetValue<string>("TokenKey");
            var key = Encoding.ASCII.GetBytes(tokenKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(tokenKey, Configuration));//Dependency Injection
            #endregion


            #region :: Injection of Services
            services.InjectComponentServices(Configuration); //Written in customized mode
            #endregion




            services.AddCors(func =>
            {
                func.AddDefaultPolicy(obj =>
                {
                    obj.AllowAnyMethod()
                        .AllowAnyOrigin()
                        .WithOrigins("https://localhost:4400");
                });
            });

        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(); //For CORS Apply

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();//Added for  Token based Authentication
          // app.UseMiddleware<ErrorWrappingMiddleware>(); // < -custom middleware
           
            
            app.UseMiddleware<CustomExceptionMiddleware>(); // < -custom middleware
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
