using Core.Dtos.Position;

namespace Core.Dtos.AbstractDtos
{
    public interface IShipDto
    {
        bool IsSunk { get; }

        string Name { get; set; }

        List<PositionDto> Positions { get; set; }
    }
}