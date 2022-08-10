using Domain.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Attack")]
    public class AttackEntity : BasePositionEntity
    {
        public bool IsComputerPlayer { get; set; }

        public UserEntity User { get; set; }
    }
}