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

        public List<ShipDto> CreateFleet(bool isConmputer)
        {
            var result = new List<ShipDto>()
            {
                CreateCarrierDto(isConmputer),
                CreateBattleshipDto(isConmputer),
                CreateDestroyerDto(isConmputer),
                CreateSubmarineDto(isConmputer),
                CreatePatrolBoatDto(isConmputer),
            };

            _rpgService.ClearLockedLocation();

            return result;
        }

        private ShipDto CreateBattleshipDto(bool isComputer) =>
                            CreateShip("Battleship", ShipSizeConst.Battleship, isComputer);

        private ShipDto CreateCarrierDto(bool isComputer) =>
            CreateShip("Carrier", ShipSizeConst.Carrier, isComputer);

        private ShipDto CreateDestroyerDto(bool isComputer) =>
            CreateShip("Destroyer", ShipSizeConst.Destroyer, isComputer);

        private ShipDto CreatePatrolBoatDto(bool isComputer) =>
            CreateShip("Patrol boat", ShipSizeConst.PatrolBoat, isComputer);

        private ShipDto CreateShip(string name, int shipSize, bool isComputer)
        {
            var isVertical = Convert.ToBoolean(_rpgService.GenerateNumber(0, 2));

            return new ShipDto()
            {
                IsComputerPlayer = isComputer,
                IsVertical = isVertical,
                Name = name,
                Positions = _rpgService.GenerateShipPositions(shipSize, isVertical)
            };
        }

        private ShipDto CreateSubmarineDto(bool isComputer) =>
                    CreateShip("Submarine", ShipSizeConst.Submarine, isComputer);
    }
}