using Core.Dtos.AbstractDtos;

namespace Core.Factories.AbstractFactories
{
    public interface IShipFactory
    {
        IShipDto CreateBattleshipDto(bool autoposition);

        IShipDto CreateCarrierDto(bool autoposition);

        IShipDto CreateDestroyerDto(bool autoposition);

        IShipDto CreatePatrolBoatDto(bool autoposition);

        IShipDto CreateSubmarineDto(bool autoposition);
    }
}