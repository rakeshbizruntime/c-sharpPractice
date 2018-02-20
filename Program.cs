using System;
using System.Diagnostics;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Runtime;
using System.Diagnostics.Tracing;
using EventListenerpkg;
using System.Configuration;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Discovery.Tcp;
using Apache.Ignite.Core.Discovery.Tcp.Static;
using Apache.Ignite.Core.Events;
using Apache.Ignite.Core.PersistentStore;

namespace CollaborationFabric
{
    internal static class Program
    {

        public static IIgnite ignite = null;
        private static void Main()
        {
            try
            {
                ServiceRuntime.RegisterServiceAsync("CollaborationFabricType",
                    context => new CollaborationFabric(context)).GetAwaiter().GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(CollaborationFabric).Name);
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception ex)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(ex.ToString());
            }
        }
    }
}
