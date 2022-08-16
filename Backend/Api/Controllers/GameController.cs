using Api.Bases;
using Core.Dtos.Bases;
using Core.Dtos.User;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class GameController : BaseApiController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("NewGame")]
        public async Task<ActionResult<UserDto>> NewGame(string userName)
        {
            var result = await _gameService.Start(userName);
            return Ok(result);
        }

        [HttpPost("NextTurn/{userId}")]
        public async Task<ActionResult<UserDto>> NextTurn([FromRoute] int userId, [FromBody] BasePositionDto dto)
        {
            var result = await _gameService.NextTurn(userId, dto);
            return Ok(result);
        }
    }
}