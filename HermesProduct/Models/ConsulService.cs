using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HermesProduct.Models
{
    /// <summary>
    /// Consul 服务端
    /// </summary>
    public class ConsulService
    {
        /// <summary>
        /// Consul地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Consul数据中心
        /// </summary>
        public string DataCenter { get; set; }
    }
}
