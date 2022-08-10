using Domain.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Position")]
    public class PositionEntity : BasePositionEntity
    {
        public bool IsHit { get; set; }

        public ShipEntity Ship { get; set; }

        public int ShipId { get; set; }
    }
}