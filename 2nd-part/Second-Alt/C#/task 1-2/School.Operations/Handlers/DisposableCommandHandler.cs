using System;
using Autofac.Features.OwnedInstances;
using School.Operations.Interfaces;

namespace School.Operations.Handlers
{
    internal sealed class DisposableCommandHandler<T> : IHandler<T> where T : ICommand, IDisposable
    {
        private readonly Owned<T> _command;

        public DisposableCommandHandler(Owned<T> command)
        {
            _command = command;
        }

        public void Handle()
        {
            try
            {
                _command.Value.Execute();
            }
            finally
            {
                _command.Dispose();
            }
        }
    }
}
