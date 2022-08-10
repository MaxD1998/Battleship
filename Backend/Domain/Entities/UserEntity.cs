using Domain.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("User")]
    public class UserEntity : BaseEntity
    {
        public List<AttackEntity> Attacks { get; set; }

        public string Name { get; set; }

        public List<ShipEntity> Ships { get; set; }
    }
}