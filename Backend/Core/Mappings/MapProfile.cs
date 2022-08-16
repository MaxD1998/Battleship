using AutoMapper;
using Core.Dtos.Attack;
using Core.Dtos.Bases;
using Core.Dtos.Position;
using Core.Dtos.Ship;
using Core.Dtos.User;
using Domain.Entities;

namespace Core.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AttackEntity, BasePositionDto>().ReverseMap();
            CreateMap<AttackEntity, AttackDto>().ReverseMap();
            CreateMap<PositionEntity, PositionDto>().ReverseMap();
            CreateMap<ShipEntity, ShipDto>().ReverseMap();
            CreateMap<ShipEntity, ShipInputDto>().ReverseMap();
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserEntity, UserInputDto>().ReverseMap();
        }
    }
}