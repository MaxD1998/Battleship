using Core.Dtos.Attack;
using Core.Dtos.Bases;
using Core.Dtos.User;
using Core.Exceptions;
using Core.Features.Get.User;
using Core.Features.Update;
using Core.Interfaces.Services;
using Core.Resources;
using MediatR;

namespace Core.Services
{
    public class UserShootService : IShootService
    {
        private readonly IMediator _mediator;
        private readonly IRandomPositionGeneratorService _randomPosition;

        public UserShootService(IMediator mediator, IRandomPositionGeneratorService randomPosition)
        {
            _mediator = mediator;
            _randomPosition = randomPosition;
        }

        public async Task<UserDto> Shoot(int userId, int x = 0, int y = 0)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(userId));
            var userAttacks = user?.Attack.Where(x => !x.IsComputerPlayer);
            var position = new BasePositionDto()
            {
                X = x,
                Y = y,
            };

            if (userAttacks.Contains(position))
                throw new BadRequestException(ErrorMessages.ThisFieldWasAttacked);

            var computerShips = user?.Ships.Where(x => x.IsComputerPlayer && !x.IsSunk);
            var computerShipPositions = computerShips.SelectMany(x => x.Positions);

            if (computerShipPositions.Contains(position))
            {
                var attackPosition = computerShipPositions.FirstOrDefault(x => x.Equals(position));
                var computerShip = computerShips.FirstOrDefault(x => x.Positions.Contains(position));

                attackPosition.IsHit = true;

                if (computerShipPositions.All(x => x.IsHit))
                {
                    var lockedPositions = new List<AttackDto>();

                    _randomPosition.AddLockedPositions(computerShip.Positions, lockedPositions);
                    lockedPositions.ForEach(x => x.IsComputerPlayer = false);

                    var exceptLockedPositions = lockedPositions.Except(user.Attack);

                    user.Attack.AddRange(exceptLockedPositions);
                }
            }

            user.Attack.Add(AttackDto.CopyTo(position));

            return await _mediator.Send(new UpdateUserCommand(userId, user));
        }
    }
}