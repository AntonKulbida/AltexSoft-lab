using System;
using System.Collections.Generic;
using System.Globalization;
using Autofac;
using School.Common.Core;
using School.Common.Utils.Extensions;
using School.Operations.Attributes;
using School.Operations.Extensions;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("help")]
    [CommandDescription("help", typeof(Strings))]
    public sealed class HelpCommand : ICommand
    {
        private readonly IEnumerable<ICommandInfo> _commands;

        public HelpCommand(IComponentContext context)
        {
            _commands = context.GetCommands();
        }

        public void Execute()
        {
            _commands.ForEach(ci => Console.WriteLine(Strings.CommandFormat, ci.Name, ci.Description.ToUpper(CultureInfo.CurrentCulture)));
        }
    }
}
