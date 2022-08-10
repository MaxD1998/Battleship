using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ShipConfig : IEntityTypeConfiguration<ShipEntity>
    {
        public void Configure(EntityTypeBuilder<ShipEntity> builder)
        {
            builder.OwnsMany(x => x.Positions, prop =>
            {
                prop.WithOwner(x => x.Ship)
                    .HasForeignKey(x => x.ShipId);
            });
            builder.SetProperty(x => x.IsSunk)
                .HasDefaultValue(false);
            builder.HasIndex(x => new { x.UserId, x.Name, x.IsComputerPlayer })
                .IsUnique();
        }
    }
}