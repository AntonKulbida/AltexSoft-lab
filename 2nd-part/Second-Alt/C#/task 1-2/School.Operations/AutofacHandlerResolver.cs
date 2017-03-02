using System;
using Autofac;
using Autofac.Features.Indexed;
using School.Operations.Enum;
using School.Operations.Interfaces;

namespace School.Operations
{
    internal sealed class AutofacHandlerResolver : IHandlerResolver
    {
        private readonly IComponentContext _context;

        public AutofacHandlerResolver(IComponentContext context)
        {
            _context = context;
        }

        public IHandler<T> Resolve<T>() where T : ICommand
        {
            var handlerType = GetCommandHandlerType<T>();
            var handlerIndex = _context.ResolveOptional<IIndex<CommandHandlerType, IHandler<T>>>();
            return handlerIndex[handlerType];
        }

        private CommandHandlerType GetCommandHandlerType<T>()
        {
            return typeof (IDisposable).IsAssignableFrom(typeof (T))
                ? CommandHandlerType.Disposable
                : CommandHandlerType.Regular;
        }
    }
}
