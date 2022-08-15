using Core.Dtos.Position;

namespace Core.Dtos.Ship
{
    public class ShipInputDto
    {
        public bool IsComputerPlayer { get; set; }

        public bool IsSunk => IsShipSunk();

        public bool IsVertical { get; set; }

        public string Name { get; set; }

        public List<PositionDto> Positions { get; set; } = new();

        private bool IsShipSunk()
        {
            if (Positions is null || Positions.Count < 2)
                return false;

            return !Positions.Any(x => !x.IsHit);
        }
    }
}