using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.OwnsMany(x => x.Attacks);
            builder.SetProperty(x => x.Name, 25, true);

            builder.Navigation(x => x.Ships)
                .AutoInclude();
        }
    }
}