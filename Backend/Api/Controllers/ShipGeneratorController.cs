using Api.Bases;
using Core.Dtos.AbstractDtos;
using Core.Factories.AbstractFactories;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ShipGeneratorController : BaseApiController
    {
        private readonly IShipFactory _shipFactory;

        public ShipGeneratorController(IShipFactory shipFactory)
        {
            _shipFactory = shipFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IShipDto>>> GetGeneratedShip()
        {
            return await Task.Run(() =>
            {
                return Ok(new List<IShipDto>()
                {
                    _shipFactory.CreateCarrierDto(true),
                    _shipFactory.CreateBattleshipDto(true),
                    _shipFactory.CreateDestroyerDto(true),
                    _shipFactory.CreateSubmarineDto(true),
                    _shipFactory.CreatePatrolBoatDto(true),
                });
            });
        }
    }
}