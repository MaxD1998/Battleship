using Core.Dtos.User;

namespace Core.Interfaces.Services
{
    public interface IShootService
    {
        Task<UserDto> Shoot(int userId, int x = 0, int y = 0);
    }
}