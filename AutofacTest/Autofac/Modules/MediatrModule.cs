using System;
using Autofac;
using MediatR;
using MediatR.Pipeline;

namespace AutofacTest.Autofac.Modules
{
    public class MediatrModule : Module
    {
        private static readonly Type[] _mediatorTypes = new[]
        {
            typeof(IRequestHandler<,>),
            typeof(IRequestExceptionHandler<,>),
            typeof(IRequestExceptionAction<,>),
            typeof(INotificationHandler<>)
        };
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });


            foreach (Type type in _mediatorTypes)
            {
                // Registers requests, handlers and behaviors
                builder.RegisterAssemblyTypes(typeof(Startup).Assembly)
                    .AsClosedTypesOf(type).AsImplementedInterfaces();
            }
        }
    }
}
