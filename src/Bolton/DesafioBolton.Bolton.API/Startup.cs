using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBolton.Bolton.Cross.IoC;
using DesafioBolton.Bolton.Infrastructure.Arquivei.SqlServer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace DesafioBolton.Bolton.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            Bootstrap.RegisterAllServiceS(services);

            services.AddDbContext<BoltonContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Bolton"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(3)));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Bolton API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bolton API");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            UpdateDatabase(app);
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            try
            {
                using (var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetService<BoltonContext>())
                    {
                        if (context.Database.is)
                        context.Database.Migrate();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
