using Domain.Bases;

namespace Infrastructure.Bases
{
    public abstract class BaseRepositoryMapper
    {
        protected void Map<T>(T source, T dest) where T : BaseEntity
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.Name.Equals(nameof(BaseEntity.Id)))
                    continue;

                typeof(T).GetProperty(property.Name)
                    .SetValue(dest, property.GetValue(source));
            }
        }
    }
}