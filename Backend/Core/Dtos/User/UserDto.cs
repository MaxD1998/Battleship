using Core.Dtos.Attack;
using Core.Dtos.Ship;

namespace Core.Dtos.User
{
    public class UserDto
    {
        public List<AttackDto> EnemyAttack { get; set; }

        public List<ShipDto> EnemyShips { get; set; }

        public int Id { get; set; }

        public List<AttackDto> MyAttack { get; set; }

        public List<ShipDto> MyShips { get; set; }
    }
}