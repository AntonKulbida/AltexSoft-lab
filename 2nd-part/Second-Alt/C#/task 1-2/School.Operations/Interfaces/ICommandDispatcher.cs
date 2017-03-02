using System;

namespace School.Operations.Interfaces
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>() where T : ICommand;

        void Dispatch(Type commandType);
    }
}
