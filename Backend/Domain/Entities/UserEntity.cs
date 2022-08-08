using Domain.Bases;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public List<AttackEntity> EnemyAttack { get; set; }

        public List<ShipEntity> EnemyShips { get; set; }

        public List<AttackEntity> MyAttack { get; set; }

        public List<ShipEntity> MyShips { get; set; }

        public string Name { get; set; }
    }
}