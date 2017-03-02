using Autofac;
using School.Operations.Enum;
using School.Operations.Handlers;
using School.Operations.Interfaces;

namespace School.Operations
{
    public sealed class OperationsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(DisposableCommandHandler<>))
                .Keyed(CommandHandlerType.Disposable, typeof(IHandler<>));
            builder.RegisterGeneric(typeof(CommandHandler<>))
                .Keyed(CommandHandlerType.Regular, typeof(IHandler<>));
            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => typeof(ICommand).IsAssignableFrom(t));
            builder.RegisterType<AutofacHandlerResolver>()
                .As<IHandlerResolver>();
            builder.RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>();
        }
    }
}
