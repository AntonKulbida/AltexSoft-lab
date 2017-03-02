using System;
using School.Operations.Attributes;
using School.Operations.Interfaces;

namespace School.Operations
{
    internal sealed class CommandInfo : ICommandInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Type CommandType { get; set; }

        internal CommandInfo(Type commandType, CommandNameAttribute nameAttribute,
            CommandDescriptionAttribute descriptionAttribute = null)
        {
            if (commandType == null)
                throw new ArgumentNullException("commandType");

            CommandType = commandType;

            Name = nameAttribute.Name;

            Description = descriptionAttribute != null
                ? descriptionAttribute.Description
                : String.Empty;
        }
    }
}
