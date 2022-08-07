using Core.Constants;
using Core.Dtos.AbstractDtos;
using Core.Dtos.Ship;
using Core.Factories.AbstractFactories;
using Core.Interfaces.Services;

namespace Core.Factories.ConrateFactories
{
    public class ShipFactory : IShipFactory
    {
        private readonly IRandomPositionGeneratorService _rpgService;

        public ShipFactory(IRandomPositionGeneratorService rpgService)
        {
            _rpgService = rpgService;
        }

        public IShipDto CreateBattleshipDto(bool autoposition) =>
            CreateShip("Battleship", ShipSizeConst.Battleship, autoposition);

        public IShipDto CreateCarrierDto(bool autoposition) =>
            CreateShip("Carrier", ShipSizeConst.Carrier, autoposition);

        public IShipDto CreateDestroyerDto(bool autoposition) =>
            CreateShip("Destroyer", ShipSizeConst.Destroyer, autoposition);

        public IShipDto CreatePatrolBoatDto(bool autoposition) =>
            CreateShip("Patrol boat", ShipSizeConst.PatrolBoat, autoposition);

        public IShipDto CreateSubmarineDto(bool autoposition) =>
            CreateShip("Submarine", ShipSizeConst.Submarine, autoposition);

        private IShipDto CreateShip(string name, int shipSize, bool autoposition)
        {
            var result = new ShipInputDto()
            {
                Name = name,
                Positions = _rpgService.GeneratePositions(shipSize, autoposition)
            };

            return result;
        }
    }
}