using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Core;
using Core.Logger;
using Core.Swagger;
using Facebook.Marketing.Api.Application.Services;
using Facebook.Marketing.Api.Application.Services.Impl;
using FaceBook.Marketing.SDK;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Facebook.Marketing.Api
{
    public class Startup : CommonStartup
    {
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void CommonServices(IServiceCollection services)
        {
            services.AddDbContext<FacebookContext>(options =>
            {
                options.UseMySql(Configuration.GetSection("Zeus:Connection").Value, sql => sql.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
            });

            services.Configure<Appsettings>(Configuration.GetSection("Appsettings"));
            var settings = services.BuildServiceProvider().GetService<IOptions<Appsettings>>().Value;
            var client = new HttpClient();
            services.AddSingleton(new FaceBookClient(client, settings.Facebook.ClientId, settings.Facebook.ClientSecret,settings.Facebook.RedirectUri));

            #region  ToDo ����ע��Services
            services.Scan(scan => scan
                    .FromAssemblyOf<Startup>()
                    .AddClasses()
                    .AsMatchingInterface()
                   .WithTransientLifetime()
             );

            var list = services.Where(x => x.ServiceType.Namespace.Equals("Facebook.Marketing.Api", StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Lifetime},{item.ImplementationType},{item.ServiceType}");
            }
            #endregion

            services.AddCoreSwagger()
                        .AddCoreSeriLog();
        }

        public override void CommonConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app .UseCoreSwagger();
        }
    }
}
