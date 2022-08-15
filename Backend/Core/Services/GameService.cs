using Core.Dtos.User;
using Core.Features.Get.User;
using Core.Interfaces.Services;
using MediatR;

namespace Core.Services
{
    public class GameService : IGameService
    {
        private readonly IMediator _mediator;

        public GameService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<UserDto> NextTurn(int userId, int x, int y)
        {

            return await _mediator.Send(new GetUserByIdQuery(userId));
        }
    }
}