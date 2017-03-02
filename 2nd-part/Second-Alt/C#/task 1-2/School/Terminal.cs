using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using School.Common.Core;
using School.Common.Utils.Extensions;
using School.Interfaces;
using School.Operations.Extensions;
using School.Operations.Interfaces;

namespace School
{
    public sealed class Terminal : ITerminal
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IEnumerable<ICommandInfo> _commands;

        public Terminal(ICommandDispatcher commandDispatcher, IComponentContext context)
        {
            _commandDispatcher = commandDispatcher;
            _commands = context.GetCommands();
        }

        public void Run()
        {
            var suffix = Assembly.GetExecutingAssembly().GetName().Name + '>';
            while (true)
            {
                Console.Write(suffix);
                var command = Console.ReadLine();
                RunCommand(command);
            }
        }

        public void RunCommand(string command)
        {
            if (String.IsNullOrWhiteSpace(command))
                return;

            var commandInfo = _commands
                .FirstOrDefault(c => c.Name.Equals(command.Trim(), StringComparison.CurrentCultureIgnoreCase));

            if (commandInfo == null)
            {
                Console.WriteLine(Strings.CommandDoesNotExist);
                return;
            }

            RunCommandSafe(commandInfo);
        }

        private void RunCommandSafe(ICommandInfo commandInfo)
        {
            try
            {
                _commandDispatcher.Dispatch(commandInfo.CommandType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetInnerException().Message);
#if DEBUG
                throw;
#endif
            }
        }
    }
}
