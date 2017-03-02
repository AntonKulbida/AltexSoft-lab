using System;

namespace School.Operations.Interfaces
{
    public interface ICommandInfo
    {
        string Name { get; set; }
        string Description { get; set; }
        Type CommandType { get; set; }
    }
}
