using AutoMapper;
using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.DAL.Models;
using Howest.MagicCards.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Caching.Memory;
using Howest.MagicCards.Shared.Filters;
using Howest.MagicCards.Shared.ExtensionMethods;
using Howest.MagicCards.Shared.Response;

namespace Howest.MagicCards.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : Controller
    {
        private readonly ICardRepository _cardRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public CardController(ICardRepository cardRepo, IMapper mapper, IMemoryCache cache)
        {
            _cardRepo = cardRepo;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet("v1.5")]
        [ApiVersion("1.5")]
        [MapToApiVersion("1.5")]
        public async Task<ActionResult<IEnumerable<CardReadDTO>>> GetCardsV1_5([FromQuery] CardFilterParameters filterParams)
        {
            string cacheKey = GenerateCacheKey(filterParams);
            int pageSize = (filterParams.PageSize < 150 && filterParams.PageSize > 0) ? filterParams.PageSize : 150;

            if (_cache.TryGetValue(cacheKey, out List<CardReadDTO> cachedCards))
            {
                return Ok(
                    new MagicCardsResponse()
                    {
                        Page = filterParams.PageNumber,
                        PageSize = pageSize,
                        Cards = cachedCards
                    }
                );
            }

            IQueryable<Card> allCards = await _cardRepo.GetAllCardsAsync();

            allCards = allCards.ApplyFilters(filterParams);
            allCards = allCards.ApplyOrder(filterParams);

            List<CardReadDTO> cards = allCards
                .Skip((filterParams.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CardReadDTO>(_mapper.ConfigurationProvider)
                .ToList();

            if (!allCards.Any())
            {
                return NotFound( new MagicCardsResponse(){ Message = "No cards found" } );
            }

            _cache.Set(cacheKey, cards, TimeSpan.FromMinutes(5));
            return Ok(
                new MagicCardsResponse()
                {
                    Page = filterParams.PageNumber,
                    PageSize = pageSize,
                    Cards = cards
                }      
            );
        }

        [HttpGet("v1.1")]
        [ApiVersion("1.1")]
        [MapToApiVersion("1.1")]
        public async Task<ActionResult<IEnumerable<CardReadDTO>>> GetCardsV1_1([FromQuery] CardFilterParametersV1_1 filterParams)
        {
            string cacheKey = GenerateCacheKeyV1_1(filterParams);
            int pageSize = (filterParams.PageSize < 150 && filterParams.PageSize > 0) ? filterParams.PageSize : 150;

            if (_cache.TryGetValue(cacheKey, out List<CardReadDTO> cachedCards))
            {
                return Ok(
                    new MagicCardsResponse()
                    {
                        Page = filterParams.PageNumber,
                        PageSize = pageSize,
                        Cards = cachedCards
                    }
                );
            }

            IQueryable<Card> allCards = await _cardRepo.GetAllCardsAsync();
            allCards = allCards.ApplyFiltersV1_1(filterParams);

            List<CardReadDTO> cards = allCards
                .Skip((filterParams.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<CardReadDTO>(_mapper.ConfigurationProvider)
                .ToList();

            if (!allCards.Any())
            {
                return NotFound(new MagicCardsResponse() { Message = "No cards found" });
            }

            _cache.Set(cacheKey, cards, TimeSpan.FromMinutes(5));
            return Ok(
                new MagicCardsResponse()
                {
                    Page = filterParams.PageNumber,
                    PageSize = pageSize,
                    Cards = cards
                }
            );
        }

        [HttpGet("v1.5/{id:int}")]
        [ApiVersion("1.5")]
        [MapToApiVersion("1.5")]
        public async Task<ActionResult<CardDetailReadDTO>> GetCard(int id)
        {
            return (await _cardRepo.GetCardByIdAsync(id) is Card foundCard)
                ? Ok( new CardDetailResponse()
                {
                    Message = "Success",
                    CardDetail = _mapper.Map<CardDetailReadDTO>(foundCard)
                })
                : NotFound(new CardDetailResponse() { Message = $"No card found with id {id}" });
        }

        private static string GenerateCacheKey(CardFilterParameters filterParams)
        {
            return $"AllCards_{filterParams.Name}_" +
                $"{filterParams.Text}_{filterParams.Artist}_{filterParams.Type}" +
                $"_{filterParams.Rarity}_{filterParams.Set}_{filterParams.SortOrder}" +
                $"_{filterParams.PageNumber}_{filterParams.PageSize}";
        }

        private static string GenerateCacheKeyV1_1(CardFilterParametersV1_1 filterParams)
        {
            return $"AllCards_{filterParams.Name}_" +
                $"{filterParams.Text}_{filterParams.Artist}_{filterParams.Type}" +
                $"_{filterParams.Rarity}_{filterParams.Set}" +
                $"_{filterParams.PageNumber}_{filterParams.PageSize}";
        }
    }
}