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
    using HermesProduct.Base.System;
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

            // 注册到consul
            app.RegisterConsul(lifetime, LoadConsulService(), LoadHermesService());

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

        //private string GetLocalIP()
        //{
        //    var networks = NetworkInterface.GetAllNetworkInterfaces()
        //        .Select(p => p.GetIPProperties())
        //        .SelectMany(p => p.UnicastAddresses);

        //    string localIP = NetworkInterface.GetAllNetworkInterfaces()
        //        .Select(p => p.GetIPProperties())
        //        .SelectMany(p => p.UnicastAddresses)
        //        .FirstOrDefault(p => p.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(p.Address))?.Address.ToString();

        //    return localIP;
        //}
    }
}
