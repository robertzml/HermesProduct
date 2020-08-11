using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace HermesProduct
{
    using Consul;
    using HermesProduct.Middlewares;
    using HermesProduct.Models;

    public static class AppBuilderExtension
    {
        /// <summary>
        /// 注册到consul
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, ConsulService consulService, HermesService hermesService)
        {
            var consulClient = new ConsulClient(x =>
                {
                    x.Address = new Uri(consulService.Address);
                    x.Datacenter = consulService.DataCenter;
                }
            );

            var httpCheck = new AgentServiceCheck
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                HTTP = hermesService.HealthCheck,
                Interval = TimeSpan.FromSeconds(10),
                Timeout = TimeSpan.FromSeconds(5)
            };

            var registration = new AgentServiceRegistration
            {
                Address = hermesService.Address,
                Port = hermesService.Port,
                ID = hermesService.Name + "-" + hermesService.Address,
                Name = hermesService.Name,
                Check = httpCheck
            };

            consulClient.Agent.ServiceRegister(registration).Wait();

            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }

        /// <summary>
        /// 采用Jwt认证
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseJwtAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}
