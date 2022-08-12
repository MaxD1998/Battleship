using Core.Exceptions;
using Core.Extensions;
using Core.Interfaces.Repositories;
using Core.Resources;
using Domain.Bases;
using Infrastructure.Bases;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class BaseRepository : BaseRepositoryMapper, IBaseRepository
    {
        public async Task<T> Create<T>(T entity) where T : BaseEntity
        {
            using (var context = new DataContext())
            {
                var result = await context.Set<T>()
                    .AddAsync(entity);

                await context.SaveChangesAsync();

                return await context.Set<T>()
                    .FirstOrDefaultAsync(x => x.Id.Equals(result.Entity.Id));
            }
        }

        public async Task<T> GetElement<T>(Expression<Func<T, bool>> expression,
            bool disableAutoInclude = false) where T : BaseEntity
        {
            using (var context = new DataContext())
            {
                var query = context.Set<T>()
                    .AsNoTracking();

                if (disableAutoInclude)
                    query = query.IgnoreAutoIncludes();

                return await query.FirstOrDefaultAsync(expression);
            }
        }

        public async Task<T> Update<T>(int id, T entity) where T : BaseEntity
        {
            using (var context = new DataContext())
            {
                var record = await context.Set<T>()
                    .IgnoreAutoIncludes()
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));

                record.ThrowIfNull(new NotFoundException(ErrorMessages.NoDataToUpdate));
                Map(entity, record);

                var result = context.Set<T>()
                    .Update(record);

                await context.SaveChangesAsync();

                return await context.Set<T>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id.Equals(result.Entity.Id));
            }
        }
    }
}