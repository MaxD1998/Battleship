using Core.Dtos.Position;

namespace Core.Dtos.Ship
{
    public class ShipDto : ShipInputDto
    {
        public new List<PositionDto> Positions;

        public int Id { get; set; }
    }
}