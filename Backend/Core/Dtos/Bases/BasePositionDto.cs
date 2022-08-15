namespace Core.Dtos.Bases
{
    public class BasePositionDto : IEquatable<BasePositionDto>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public virtual bool Equals(BasePositionDto other) =>
            X == other.X && Y == other.Y;

        public override int GetHashCode() =>
            HashCode.Combine(X, Y);

        public virtual BasePositionDto ShallowCopy() =>
            (BasePositionDto)MemberwiseClone();
    }
}