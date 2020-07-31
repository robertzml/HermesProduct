using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HermesProduct.Models
{
    /// <summary>
    /// Hermes 服务
    /// </summary>
    public class HermesService
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public string HealthCheck { get; set; }
    }
}
