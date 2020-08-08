using NUnit.Framework;
using System.Net;
using System.Linq;
using System;
using System.Net.Sockets;

namespace HermesProduct.Test.Utility
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IPHostEntry myEntry = Dns.GetHostEntry(Dns.GetHostName());

            var list = myEntry.AddressList;

            var ip = myEntry.AddressList.FirstOrDefault<IPAddress>(e => e.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !IPAddress.IsLoopback(e));

            Console.WriteLine(ip.ToString());
            Assert.Pass();
        }
    }
}