using AutoMapper;
using Howest.MagicCards.Shared.DTO;
using Type = Howest.MagicCards.DAL.Models.Type;

namespace Howest.MagicCards.Shared.Mappings
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<Type, TypeReadDTO>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(b => b.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(b => b.Name))
                .ForMember(dto => dto.Type1,
                    opt => opt.MapFrom(b => b.Type1));
        }
    }
}
