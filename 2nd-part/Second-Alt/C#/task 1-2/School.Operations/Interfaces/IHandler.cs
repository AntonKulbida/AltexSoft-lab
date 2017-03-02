namespace School.Operations.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        void Handle();
    }
}
