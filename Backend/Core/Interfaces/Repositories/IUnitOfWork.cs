namespace Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IBaseRepository Base { get; }
    }
}