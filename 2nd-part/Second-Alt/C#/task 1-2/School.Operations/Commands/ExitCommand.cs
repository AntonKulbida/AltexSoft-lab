using System;
using School.Common.Core;
using School.Operations.Attributes;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("exit")]
    [CommandDescription("exit", typeof(Strings))]
    public sealed class ExitCommand : ICommand
    {
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
