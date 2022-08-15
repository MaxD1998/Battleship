using Core.Dtos.Bases;

namespace Core.Dtos.Attack
{
    public class AttackDto : BasePositionDto
    {
        public int Id { get; set; }

        public bool IsComputerPlayer { get; set; } = true;

        public static AttackDto CopyTo(BasePositionDto dto) =>
            new AttackDto()
            {
                X = dto.X,
                Y = dto.Y
            };
    }
}