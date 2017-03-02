using System;

namespace School.Operations.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    internal sealed class CommandNameAttribute : Attribute
    {
        public string Name { get; private set; }

        /// <param name="name">Command name. Maximum length 14</param>
        public CommandNameAttribute(string name)
        {
            if(String.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name", "Command name is required");

            if (name.Length > 14)
                throw new ArgumentOutOfRangeException("name", name, "Command name maximum length exceeded");

            Name = name;
        }
    }
}
