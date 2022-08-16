using Core.Dtos.Attack;
using Core.Dtos.Bases;
using Core.Dtos.Position;

namespace Core.Interfaces.Services
{
    public interface IRandomPositionGeneratorService
    {
        void AddLockedPositions<T>(IEnumerable<BasePositionDto> positions, List<T> lockedPositions) where T : BasePositionDto, new();

        void ClearLockedLocation();

        int GenerateNumber(int start, int end);

        List<PositionDto> GenerateShipPositions(int shipSize, bool isVertical);

        BasePositionDto GenerateShootPosition(IEnumerable<AttackDto> positions);
    }
}