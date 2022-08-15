using AutoMapper;
using Core.Bases;
using Core.Dtos.User;
using Core.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Core.Features.Get.User
{
    public record GetUserByIdQuery(int Id) : IRequest<UserDto>;

    public class GetUserByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetUserByIdQuery, UserDto>
    {
        public GetUserByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) =>
            await GetElement<UserEntity, UserDto>(x => x.Id.Equals(request.Id));
    }
}