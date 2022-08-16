using Core.Dtos.Bases;
using Core.Dtos.User;

namespace Core.Interfaces.Services
{
    public interface IGameService
    {
        Task<UserDto> NextTurn(int userId, BasePositionDto dto);

        Task<UserDto> Start(string name);
    }
}