using Api.Bases;
using Core.Dtos.Ship;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class ShipGeneratorController : BaseApiController
    {
        private readonly IShipGeneratorService _shipGeneratorService;

        public ShipGeneratorController(IShipGeneratorService shipGeneratorService)
        {
            _shipGeneratorService = shipGeneratorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipInputDto>>> GetGeneratedShip()
        {
            return await Task.Run(() =>
            {
                return Ok(new List<ShipInputDto>()
                {
                    _shipGeneratorService.CreateCarrierDto(true),
                    _shipGeneratorService.CreateBattleshipDto(true),
                    _shipGeneratorService.CreateDestroyerDto(true),
                    _shipGeneratorService.CreateSubmarineDto(true),
                    _shipGeneratorService.CreatePatrolBoatDto(true),
                });
            });
        }
    }
}