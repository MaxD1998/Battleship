using Core.Dtos.AbstractDtos;
using Core.Dtos.Position;

namespace Core.Dtos.BaseDtos
{
    public abstract class BaseShipDto : IShipDto
    {
        public bool IsSunk { get; set; }

        public string Name { get; set; }

        public List<PositionDto> Positions { get; set; }
    }
}