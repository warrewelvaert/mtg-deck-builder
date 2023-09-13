using AutoMapper;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Mappings
{
    public class RarityProfile : Profile
    {
        public RarityProfile()
        {
            CreateMap<Rarity, RarityReadDTO>()
                .ForMember(dto => dto.Id,
                            opt => opt.MapFrom(b => b.Id))
                .ForMember(dto => dto.Name,
                            opt => opt.MapFrom(b => b.Name))
                .ForMember(dto => dto.Code,
                            opt => opt.MapFrom(b => b.Code));
        }
    }
}
