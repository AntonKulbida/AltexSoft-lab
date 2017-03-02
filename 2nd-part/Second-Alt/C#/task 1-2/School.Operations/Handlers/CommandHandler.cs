using School.Operations.Interfaces;

namespace School.Operations.Handlers
{
    internal sealed class CommandHandler<T> : IHandler<T> where T : ICommand
    {
        private readonly T _command;

        public CommandHandler(T command)
        {
            _command = command;
        }

        public void Handle()
        {
            _command.Execute();
        }
    }
}
