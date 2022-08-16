using Core.Dtos.Bases;
using Core.Dtos.User;

namespace Core.Interfaces.Services
{
    public interface IShootService
    {
        Task<UserDto> Shoot(int userId, BasePositionDto position = null);
    }
}