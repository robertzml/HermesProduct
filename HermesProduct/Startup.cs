using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HermesProduct
{
    using HermesProduct.Models;

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
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // ע�ᵽconsul
            app.RegisterConsul(lifetime, LoadConsulService());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private ConsulService LoadConsulService()
        {
            ConsulService consulService = new ConsulService
            {
                Address = Configuration["Consul:Address"],
                DataCenter = Configuration["Consul:DataCenter"]
            };

            return consulService;
        }

        private HermesService LoadHermesService()
        {
            HermesService hermesService = new HermesService
            {
                Name = Configuration["Service:Name"],
                Address = Configuration["Service:Address"],
                Port = Convert.ToInt32(Configuration["Service:Port"]),
                HealthCheck = Configuration["Service:HealthCheck"]
            };

            return hermesService;
        }
    }
}
