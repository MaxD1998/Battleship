using Core.Dtos.Position;

namespace Core.Interfaces.Services
{
    public interface IRandomPositionGeneratorService
    {
        List<PositionDto> GeneratePositions(int shipSize, bool autoPosition);
    }
}