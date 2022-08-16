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
            builder.OwnsMany(x => x.Attacks, prop =>
            {
                prop.HasKey(x => x.Id);
                prop.WithOwner(x => x.User)
                    .HasForeignKey(x => x.UserId);
                prop.HasIndex(x => new { x.IsComputerPlayer, x.UserId, x.X, x.Y })
                    .IsUnique();
            });
            builder.SetProperty(x => x.Name, 25, true);

            builder.Navigation(x => x.Attacks)
                .AutoInclude();
            builder.Navigation(x => x.Ships)
                .AutoInclude();
        }
    }
}