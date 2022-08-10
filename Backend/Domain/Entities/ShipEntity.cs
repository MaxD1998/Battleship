using Domain.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Ship")]
    public class ShipEntity : BaseEntity
    {
        public bool IsComputerPlayer { get; set; }

        public bool IsSunk { get; set; }

        public string Name { get; set; }

        public List<PositionEntity> Positions { get; set; }

        public UserEntity User { get; set; }

        public int UserId { get; set; }
    }
}