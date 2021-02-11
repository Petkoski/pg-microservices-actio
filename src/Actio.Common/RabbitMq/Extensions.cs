using Actio.Common.Commands;
using Actio.Common.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using RawRabbit.Pipe.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.RabbitMq
{
    public static class Extensions
    {
        //RawRabbit version="2.0.0-beta8"
        //public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
        //    ICommandHandler<TCommand> handler) where TCommand : ICommand
        //    => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
        //        ctx => ctx.UseConsumerConfiguration(cfg => 
        //        cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        //RawRabbit version="2.0.0-rc5"
        //Source: https://github.com/PacktPublishing/.NET-Core-Microservices/issues/2
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg =>
                cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        //RawRabbit version="2.0.0-beta8"
        //public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
        //    IEventHandler<TEvent> handler) where TEvent : IEvent
        //    => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
        //        ctx => ctx.UseConsumerConfiguration(cfg =>
        //        cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        //RawRabbit version="2.0.0-rc5"
        //Source: https://github.com/PacktPublishing/.NET-Core-Microservices/issues/2
        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                ctx => ctx.UseSubscribeConfiguration(cfg =>
                cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

        public static void AddRabbitMq(this IServiceCollection service, IConfiguration configuration)
        {
            var options = new RabbitMqOptions();
            var section = configuration.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            service.AddSingleton<IBusClient>(_ => client);
        }
    }
}
