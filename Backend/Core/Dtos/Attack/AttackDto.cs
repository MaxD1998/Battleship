using Core.Dtos.Bases;

namespace Core.Dtos.Attack
{
    public class AttackDto : BasePositionDto, IEquatable<AttackDto>
    {
        public int Id { get; set; }

        public bool IsComputerPlayer { get; set; } = true;

        public static AttackDto CopyTo(BasePositionDto dto) =>
            new AttackDto()
            {
                X = dto.X,
                Y = dto.Y
            };

        public bool Equals(AttackDto other) =>
            X == other.X && Y == other.Y && IsComputerPlayer == other.IsComputerPlayer;

        public override int GetHashCode() => HashCode.Combine(X, Y, IsComputerPlayer);
    }
}