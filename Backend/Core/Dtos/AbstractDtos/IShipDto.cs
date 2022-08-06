using Core.Dtos.Position;

namespace Core.Dtos.AbstractDtos
{
    public interface IShipDto
    {
        bool IsSunk { get; set; }

        string Name { get; set; }

        public List<PositionDto> Positions { get; set; }
    }
}