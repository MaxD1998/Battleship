using Core.Dtos.Bases;
using Core.Dtos.Position;
using Core.Interfaces.Services;

namespace Core.Services
{
    public class RandomPositionGeneratorService : IRandomPositionGeneratorService
    {
        private List<BasePositionDto> _lockedPositions = new();

        public List<PositionDto> GeneratePositions(int shipSize, bool autoposition)
        {
            var isVertical = Convert.ToBoolean(GenerateNumber(0, 2));
            var positions = new List<PositionDto>();
            var position = GeneratePosition(isVertical, shipSize);

            if (!autoposition)
                return positions;

            positions.Add(new PositionDto()
            {
                X = position.X,
                Y = position.Y,
            });

            for (int i = 1; i < shipSize; i++)
            {
                if (isVertical)
                    positions.Add(new PositionDto()
                    {
                        X = position.X,
                        Y = position.Y + i,
                    });
                else
                    positions.Add(new PositionDto()
                    {
                        X = position.X + i,
                        Y = position.Y,
                    });
            }

            AddLockedPositions(positions);

            return positions;
        }

        private void AddLockedPositions(IEnumerable<BasePositionDto> positions)
        {
            foreach (var position in positions)
            {
                var x = position.X - 1 > 0 ? position.X - 1 : position.X;
                var y = position.Y - 1 > 0 ? position.Y - 1 : position.Y;
                var endX = position.X + 1 > 10 ? position.X : position.X + 1;
                var endY = position.Y + 1 > 10 ? position.Y : position.Y + 1;

                for (int i = x; i <= endX; i++)
                {
                    for (int j = y; j <= endY; j++)
                    {
                        var lockedPosition = new BasePositionDto()
                        {
                            X = i,
                            Y = j,
                        };

                        if (_lockedPositions.Contains(lockedPosition))
                            continue;

                        _lockedPositions.Add(lockedPosition);
                    }
                }
            }
        }

        private BasePositionDto CreatePosition()
        {
            return new BasePositionDto()
            {
                X = GenerateNumber(1, 11),
                Y = GenerateNumber(1, 11),
            };
        }

        private int GenerateNumber(int start, int end)
        {
            var random = new Random();

            return random.Next(start, end);
        }

        private BasePositionDto GeneratePosition(bool isVertical, int shipSize)
        {
            var position = CreatePosition();
            var decrementShipSize = shipSize - 1;
            var endPositon = position.ShallowCopy();

            if (isVertical)
                endPositon.Y += decrementShipSize;
            else
                endPositon.X += decrementShipSize;

            if (_lockedPositions.Contains(position)
                || _lockedPositions.Contains(endPositon)
                || endPositon.X > 10
                || endPositon.Y > 10)
                return GeneratePosition(isVertical, shipSize);

            return position;
        }
    }
}