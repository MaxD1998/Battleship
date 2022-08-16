using Core.Dtos.Attack;
using Core.Dtos.Ship;

namespace Core.Dtos.User
{
    public class UserInputDto
    {
        public List<AttackDto> Attacks { get; set; } = new();

        public string Name { get; set; }

        public List<ShipDto> Ships { get; set; } = new();
    }
}