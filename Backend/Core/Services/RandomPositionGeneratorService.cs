using Core.Interfaces.Services;

namespace Core.Services
{
    public class RandomPositionGeneratorService : IRandomPositionGeneratorService
    {
        public int GeneratePosition()
        {
            var random = new Random();

            return random.Next(1, 10);
        }
    }
}