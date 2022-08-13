using AutoMapper;
using Core.Bases;
using Core.Dtos.Ship;
using Core.Interfaces.Repositories;
using Domain.Entities;
using MediatR;

namespace Core.Features.Create
{
    public record CreateShipCommand(ShipInputDto Dto) : IRequest<ShipDto>;

    public class CreateShipCommandHandler : BaseRequestHandler, IRequestHandler<CreateShipCommand, ShipDto>
    {
        public CreateShipCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public Task<ShipDto> Handle(CreateShipCommand request, CancellationToken cancellationToken) =>
            Create<ShipEntity, ShipDto>(request.Dto);
    }
}