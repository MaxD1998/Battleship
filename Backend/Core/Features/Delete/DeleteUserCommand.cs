using AutoMapper;
using Core.Bases;
using Core.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Core.Features.Delete
{
    public record DeleteUserCommand(int Id) : IRequest;

    public class DeleteUserCommandHandler : BaseRequestHandler, IRequestHandler<DeleteUserCommand>
    {
        public DeleteUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await Delete<UserEntity>(request.Id);

            return Unit.Value;
        }
    }
}