using Core.Dtos.Ship;

namespace Core.Interfaces.Services
{
    public interface IShipGeneratorService
    {
        List<ShipDto> CreateFleet(bool isConmputer);
    }
}