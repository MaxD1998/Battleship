using Core.Dtos.Attack;
using Core.Dtos.Bases;
using Core.Dtos.User;
using Core.Features.Get.User;
using Core.Features.Update;
using Core.Interfaces.Services;
using MediatR;

namespace Core.Services
{
    public class AutoShootService : IShootService
    {
        private readonly IMediator _mediator;
        private readonly IRandomPositionGeneratorService _randomPosition;

        public AutoShootService(IMediator mediator, IRandomPositionGeneratorService randomPosition)
        {
            _mediator = mediator;
            _randomPosition = randomPosition;
        }

        public async Task<UserDto> Shoot(int userId, BasePositionDto position = null)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(userId));
            var computerAttack = user.Attacks.Where(x => x.IsComputerPlayer);
            var userShips = user.Ships.Where(x => !x.IsComputerPlayer && !x.IsSunk);
            var userShipPositions = userShips.SelectMany(x => x.Positions);

            if (userShipPositions.Any(x => x.IsHit))
            {
                var damagedShip = userShips.FirstOrDefault(x => x.Positions.Any(x => x.IsHit));
                var damagedShipPositions = damagedShip?.Positions.Where(x => x.IsHit);

                if (damagedShipPositions.Count() > 1)
                {
                    var attackPosition = damagedShip.Positions.FirstOrDefault(x => !x.IsHit);
                    attackPosition.IsHit = true;
                    user.Attacks.Add(AttackDto.CopyTo(attackPosition));

                    if (damagedShip.Positions.All(x => x.IsHit))
                    {
                        var lockedPositions = new List<AttackDto>();

                        _randomPosition.AddLockedPositions(damagedShip.Positions, lockedPositions);
                        lockedPositions.ForEach(x => x.IsComputerPlayer = true);

                        var exceptLockedPositions = lockedPositions.Except(user.Attacks);

                        user.Attacks.AddRange(exceptLockedPositions);
                    }

                    return await _mediator.Send(new UpdateUserCommand(userId, user));
                }
            }

            var attack = _randomPosition.GenerateShootPosition(computerAttack);
            user.Attacks.Add(AttackDto.CopyTo(attack));

            return await _mediator.Send(new UpdateUserCommand(userId, user));
        }
    }
}