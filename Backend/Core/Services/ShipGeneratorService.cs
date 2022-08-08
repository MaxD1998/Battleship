using Core.Constants;
using Core.Dtos.Ship;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class ShipGeneratorService : IShipGeneratorService
    {
        private readonly IRandomPositionGeneratorService _rpgService;

        public ShipGeneratorService(IRandomPositionGeneratorService rpgService)
        {
            _rpgService = rpgService;
        }

        public ShipInputDto CreateBattleshipDto(bool autoposition) =>
            CreateShip("Battleship", ShipSizeConst.Battleship, autoposition);

        public ShipInputDto CreateCarrierDto(bool autoposition) =>
            CreateShip("Carrier", ShipSizeConst.Carrier, autoposition);

        public ShipInputDto CreateDestroyerDto(bool autoposition) =>
            CreateShip("Destroyer", ShipSizeConst.Destroyer, autoposition);

        public ShipInputDto CreatePatrolBoatDto(bool autoposition) =>
            CreateShip("Patrol boat", ShipSizeConst.PatrolBoat, autoposition);

        public ShipInputDto CreateSubmarineDto(bool autoposition) =>
            CreateShip("Submarine", ShipSizeConst.Submarine, autoposition);

        private ShipInputDto CreateShip(string name, int shipSize, bool autoposition)
        {
            return new ShipInputDto()
            {
                Name = name,
                Positions = _rpgService.GeneratePositions(shipSize, autoposition)
            };
        }
    }
}