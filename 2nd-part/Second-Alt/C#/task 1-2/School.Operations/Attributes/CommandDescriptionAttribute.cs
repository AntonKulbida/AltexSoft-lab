using System;
using School.Common.Utils.Extensions;

namespace School.Operations.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class CommandDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public CommandDescriptionAttribute(string description)
        {
            Description = description;
        }

        public CommandDescriptionAttribute(string commandName, Type resourceSource)
        {
            if (String.IsNullOrWhiteSpace(commandName))
            {
                Description = String.Empty;
                return;
            }

            var resourceKey = "CommandDescription_" + commandName.ToCamelCase();

            Description = resourceKey.GetStringByKey(resourceSource) ?? commandName;
        }
    }
}
