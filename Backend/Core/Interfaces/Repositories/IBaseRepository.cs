using Domain.Bases;
using System.Linq.Expressions;

namespace Core.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        Task<T> Create<T>(T entity) where T : BaseEntity;

        Task<IEnumerable<T>> CreateRange<T>(IEnumerable<T> entities) where T : BaseEntity;

        Task Delete<T>(int id) where T : BaseEntity;

        Task<T> GetElement<T>(Expression<Func<T, bool>> expression, bool disableAutoInclude = false) where T : BaseEntity;

        Task<T> Update<T>(int id, T entity) where T : BaseEntity;
    }
}