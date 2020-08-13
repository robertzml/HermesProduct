using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    using HermesProduct.Base.System;
    using HermesProduct.Models;
    using HermesProduct.Core.Facade;
    using HermesProduct.Core.BL;
    using Microsoft.OpenApi.Models;  

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hermes Product API",
                    Description = "产品模块 ASP.NET Core Web API"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                var coreXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.Core.xml";
                var coreXmlPath = Path.Combine(AppContext.BaseDirectory, coreXmlFile);
                c.IncludeXmlComments(coreXmlPath);
            });

            services.AddTransient(typeof(ICategoryBusiness), typeof(CategoryBusiness));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hermes Product API V1");
            });

            app.UseReDoc(c =>
            {
                c.SpecUrl("/swagger/v1/swagger.json");
                c.DocumentTitle = "Hermes Product API V1";
            });

            app.UseRouting();

            app.UseAuthorization();

            // 注册到consul
            app.RegisterConsul(lifetime, LoadConsulService(), LoadHermesService());

            app.UseJwtAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // 配置连接字符串
            string cs = Configuration["ConnectionString:Base"];
            Cache.Instance.Add("ConnectionString", cs);
        }

        /// <summary>
        /// 载入consul 客户端配置
        /// </summary>
        /// <returns></returns>
        private ConsulService LoadConsulService()
        {
            ConsulService consulService = new ConsulService
            {
                Address = Configuration["Consul:Address"],
                DataCenter = Configuration["Consul:DataCenter"]
            };

            return consulService;
        }

        /// <summary>
        /// 载入本服务相关配置
        /// </summary>
        /// <returns></returns>
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
