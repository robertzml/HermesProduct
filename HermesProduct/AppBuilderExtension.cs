using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace HermesProduct
{
    using HermesProduct.Models;

    public static class AppBuilderExtension
    {
        /// <summary>
        /// 注册到consul
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, ConsulService consulService)
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
                HTTP = "http://172.24.0.22:5000/api/Health/check",
                Interval = TimeSpan.FromSeconds(10),
                Timeout = TimeSpan.FromSeconds(5)
            };

            var registration = new AgentServiceRegistration
            {
                Address = "192.168.1.175",
                Port = 50791,
                ID = Guid.NewGuid().ToString(),
                Name = "TestDiscovery",
                Check = httpCheck
            };

            consulClient.Agent.ServiceRegister(registration).Wait();

            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }
    }
}
