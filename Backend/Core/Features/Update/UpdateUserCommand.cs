using AutoMapper;
using Core.Bases;
using Core.Dtos.User;
using Core.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Core.Features.Update
{
    public record UpdateUserCommand(int Id, UserInputDto Dto) : IRequest<UserDto>;

    public class UpdateUserCommandHandler : BaseRequestHandler, IRequestHandler<UpdateUserCommand, UserDto>
    {
        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken) =>
            await Update<UserEntity, UserDto>(request.Id, request.Dto);
    }
}