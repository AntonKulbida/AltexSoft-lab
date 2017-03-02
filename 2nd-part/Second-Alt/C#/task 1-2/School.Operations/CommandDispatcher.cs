using System;
using System.Linq;
using School.Operations.Interfaces;

namespace School.Operations
{
    internal sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IHandlerResolver _resolver;

        public CommandDispatcher(IHandlerResolver resolver)
        {
            _resolver = resolver;
        }

        public void Dispatch<T>() where T : ICommand
        {
            var handler = _resolver.Resolve<T>();
            if (handler != null)
            {
                handler.Handle();
            }
        }

        public void Dispatch(Type commandType)
        {
            typeof(ICommandDispatcher)
                .GetMethods()
                .First(m => m.Name == "Dispatch" && m.ContainsGenericParameters)
                .MakeGenericMethod(commandType)
                .Invoke(this, new object[0]);
        }
    }
}
