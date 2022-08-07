namespace Core.Dtos.Position
{
    public class PositionBaseDto : IEquatable<PositionBaseDto>
    {
        public int X { get; set; }

        public int Y { get; set; }

        public virtual bool Equals(PositionBaseDto other) =>
                    X == other.X && Y == other.Y;

        public virtual PositionBaseDto ShallowCopy() =>
            (PositionBaseDto)MemberwiseClone();
    }
}