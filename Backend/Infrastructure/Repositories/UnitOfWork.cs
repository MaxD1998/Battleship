using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBaseRepository Base => new BaseRepository();
    }
}