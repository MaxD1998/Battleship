using Core.Dtos.AbstractDtos;

namespace Core.Factories.AbstractFactories
{
    public interface IShipFactory
    {
        IShipDto CreateBattleshipDto();

        IShipDto CreateCarrierDto();

        IShipDto CreateDestroyerDto();

        IShipDto CreatePatrolBoatDto();

        IShipDto CreateSubmarineDto();
    }
}