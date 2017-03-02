using System;
using School.Common.Core;
using School.Operations.Attributes;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("clear")]
    [CommandDescription("clear", typeof(Strings))]
    public sealed class ClearConsoleCommand : ICommand
    {
        public void Execute()
        {
            Console.Clear();
        }
    }
}
