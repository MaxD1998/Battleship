using Core.Dtos.Ship;

namespace Core.Interfaces.Services
{
    public interface IShipGeneratorService
    {
        ShipInputDto CreateBattleshipDto(bool autoposition);

        ShipInputDto CreateCarrierDto(bool autoposition);

        ShipInputDto CreateDestroyerDto(bool autoposition);

        ShipInputDto CreatePatrolBoatDto(bool autoposition);

        ShipInputDto CreateSubmarineDto(bool autoposition);
    }
}