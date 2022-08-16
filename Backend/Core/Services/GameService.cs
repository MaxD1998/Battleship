using Core.Dtos.Bases;
using Core.Dtos.User;
using Core.Features.Create;
using Core.Features.Get.User;
using Core.Interfaces.Services;
using MediatR;

namespace Core.Services
{
    public class GameService : IGameService
    {
        private readonly IMediator _mediator;
        private readonly IShipGeneratorService _shipGeneratorService;
        private readonly IEnumerable<IShootService> _shootServices;

        public GameService(IMediator mediator,
            IShipGeneratorService shipGeneratorService,
            IEnumerable<IShootService> shootServices)
        {
            _mediator = mediator;
            _shipGeneratorService = shipGeneratorService;
            _shootServices = shootServices;
        }

        public async Task<UserDto> NextTurn(int userId, BasePositionDto dto)
        {
            var shootService = _shootServices.FirstOrDefault(x => x is UserShootService);

            await shootService.Shoot(userId, dto);

            shootService = _shootServices.FirstOrDefault(x => x is AutoShootService);

            await shootService.Shoot(userId, dto);

            return await _mediator.Send(new GetUserByIdQuery(userId));
        }

        public async Task<UserDto> Start(string name)
        {
            var user = new UserInputDto()
            {
                Name = name,
                Attacks = new(),
                Ships = new()
            };

            user.Ships.AddRange(_shipGeneratorService.CreateFleet(true));
            user.Ships.AddRange(_shipGeneratorService.CreateFleet(false));

            return await _mediator.Send(new CreateUserCommand(user));
        }
    }
}