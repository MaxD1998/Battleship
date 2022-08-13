using AutoMapper;
using Core.Bases;
using Core.Dtos.User;
using Core.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Core.Features.Create
{
    public record CreateUserCommand(UserInputDto Dto) : IRequest<UserDto>;

    public class CreateUserCommandHandler : BaseRequestHandler, IRequestHandler<CreateUserCommand, UserDto>
    {
        public CreateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken) =>
            await Create<UserEntity, UserDto>(request.Dto);
    }
}