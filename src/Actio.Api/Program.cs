using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Events;
using Actio.Common.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Actio.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * Service hos will try to grab the EventHandler from ServicesCollection (SubscribeToEvent method)
             * defined in Actio.Api.Startup and will try to take it, subscribe to it and eventually
             * invoke the event handler if it's found.
             */

            ServiceHost.Create<Startup>(args)
                .UserRabbitMq()
                .SubscribeToEvent<ActivityCreated>()
                .Build()
                .Run();
        }
    }
}
