using AutoMapper;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;

namespace Howest.MagicCards.Shared.Mappings
{
    public class CardProfile: Profile
    {

        public CardProfile()
        {
            CreateMap<Card, CardReadDTO>()
                .ForMember(dto => dto.Id,
                            opt => opt.MapFrom(b => b.Id))
                .ForMember(dto => dto.Name,
                            opt => opt.MapFrom(b => b.Name))
                .ForMember(dto => dto.Rarity,
                            opt => opt.MapFrom(b => b.RarityCodeNavigation.Name))
                .ForMember(dto => dto.Set,
                            opt => opt.MapFrom(b => b.SetCodeNavigation.Name))
                .ForMember(dto => dto.Artist,
                            opt => opt.MapFrom(b => b.Artist.FullName))
                .ForMember(dto => dto.Text,
                            opt => opt.MapFrom(b => b.Text))
                .ForMember(dto => dto.OriginalImageUrl,
                            opt => opt.MapFrom(b => b.OriginalImageUrl))
                .ForMember(dto => dto.Type,
                            opt => opt.MapFrom(b => b.Type))
                .ForMember(dto => dto.ManaCost,
                            opt => opt.MapFrom(b => b.ManaCost));

            CreateMap<Card, CardDetailReadDTO>()
                .ForMember(dto => dto.Id,
                            opt => opt.MapFrom(b => b.Id))
                .ForMember(dto => dto.Name,
                            opt => opt.MapFrom(b => b.Name))
                .ForMember(dto => dto.Rarity,
                            opt => opt.MapFrom(b => b.RarityCode))
                .ForMember(dto => dto.Set,
                            opt => opt.MapFrom(b => b.SetCode))
                .ForMember(dto => dto.Text,
                            opt => opt.MapFrom(b => b.Text))
                .ForMember(dto => dto.OriginalImageUrl,
                            opt => opt.MapFrom(b => b.OriginalImageUrl))
                .ForMember(dto => dto.Type,
                            opt => opt.MapFrom(b => b.Type))
                .ForMember(dto => dto.ManaCost,
                            opt => opt.MapFrom(b => b.ManaCost))
                .ForMember(dto => dto.ConvertedManaCost,
                            opt => opt.MapFrom(b => b.ConvertedManaCost));
        }
        
    }
}
