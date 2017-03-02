using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using School.Common.Utils.Extensions;
using School.Operations.Attributes;
using School.Operations.Interfaces;

namespace School.Operations.Extensions
{
    public static class ComponentContextExtensions
    {
        public static IEnumerable<ICommandInfo> GetCommands(this IComponentContext context)
        {
            return context.ComponentRegistry.Registrations
                .SelectMany(r => r.Services)
                .OfType<IServiceWithType>()
                .Select(s => s.ServiceType)
                .Where(t => typeof (ICommand).IsAssignableFrom(t))
                .Select(t => new {Type = t, NameAttribute = t.GetAttribute<CommandNameAttribute>()})
                .Where(c => c.NameAttribute != null)
                .Select(c => new CommandInfo(c.Type, c.NameAttribute, c.Type.GetAttribute<CommandDescriptionAttribute>()))
                .OrderBy(c => c.Name)
                .ToArray();
        }
    }
}
