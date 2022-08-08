using Core.Dtos.Bases;

namespace Core.Dtos.Position
{
    public class PositionInputDto : BasePositionDto
    {
        public bool IsHit { get; set; } = false;
    }
}