using Core.Dtos.AbstractDtos;
using Core.Factories.AbstractFactories;

namespace Core.Factories.ConrateFactories
{
    public class ShipFactory : IShipFactory
    {
        public IShipDto CreateBattleshipDto()
        {
            throw new NotImplementedException();
        }

        public IShipDto CreateCarrierDto()
        {
            throw new NotImplementedException();
        }

        public IShipDto CreateDestroyerDto()
        {
            throw new NotImplementedException();
        }

        public IShipDto CreatePatrolBoatDto()
        {
            throw new NotImplementedException();
        }

        public IShipDto CreateSubmarineDto()
        {
            throw new NotImplementedException();
        }
    }
}