using Domain.Bases;

namespace Domain.Entities
{
    public class ShipEntity : BaseEntity
    {
        public bool IsSunk { get; set; }

        public string Name { get; set; }

        public List<PositionEntity> Positions { get; set; }
    }
}