namespace School.Data.Interfaces
{
    public interface IEntity<T> where T : struct
    {
        T Id { get; set; }
    }
}
