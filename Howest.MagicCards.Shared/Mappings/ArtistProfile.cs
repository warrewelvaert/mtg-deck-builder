using AutoMapper;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Mappings
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile() 
        {
            CreateMap<Artist, ArtistReadDTO>()
                .ForMember(dto => dto.Id,
                            opt => opt.MapFrom(b => b.Id))
                .ForMember(dto => dto.FullName,
                            opt => opt.MapFrom(b => b.FullName));
        }
    }
}
