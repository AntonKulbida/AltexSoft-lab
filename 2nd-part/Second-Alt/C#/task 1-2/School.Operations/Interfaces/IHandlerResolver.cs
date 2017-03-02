namespace School.Operations.Interfaces
{
    public interface IHandlerResolver
    {
        IHandler<T> Resolve<T>() where T : ICommand;
    }
}
