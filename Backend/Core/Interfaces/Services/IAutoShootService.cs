using Core.Dtos.User;

namespace Core.Interfaces.Services
{
    public interface IAutoShootService
    {
        Task<UserDto> Shoot(int userId);
    }
}