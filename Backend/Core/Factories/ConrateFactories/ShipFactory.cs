using Core.Constants;
using Core.Dtos.AbstractDtos;
using Core.Dtos.Position;
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

        public IShipDto CreateBattleshipDto() =>
            CreateShip("Battleship", ShipSizeConst.Battleship);

        public IShipDto CreateCarrierDto() =>
            CreateShip("Carrier", ShipSizeConst.Carrier);

        public IShipDto CreateDestroyerDto() =>
            CreateShip("Destroyer", ShipSizeConst.Destroyer);

        public IShipDto CreatePatrolBoatDto() =>
            CreateShip("Patrol boat", ShipSizeConst.PatrolBoat);

        public IShipDto CreateSubmarineDto() =>
            CreateShip("Submarine", ShipSizeConst.Submarine);

        private IShipDto CreateShip(string name, int shipSize)
        {
            var result = new ShipInputDto()
            {
                Name = name,
            };

            for (int i = 0; i < shipSize; i++)
            {
                result.Positions.Add(new PositionDto()
                {
                    X = _rpgService.GeneratePosition(),
                    Y = _rpgService.GeneratePosition()
                });
            }

            return result;
        }
    }
}