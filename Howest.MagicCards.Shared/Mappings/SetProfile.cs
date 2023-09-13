using AutoMapper;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Mappings
{
    public class SetProfile : Profile
    {
        public SetProfile() 
        {
            CreateMap<Set, SetReadDTO>()
                .ForMember(dto => dto.Id,
                            opt => opt.MapFrom(b => b.Id))
                .ForMember(dto => dto.Name,
                            opt => opt.MapFrom(b => b.Name))
                .ForMember(dto => dto.Code,
                            opt => opt.MapFrom(b => b.Code));
        }
    }
}
