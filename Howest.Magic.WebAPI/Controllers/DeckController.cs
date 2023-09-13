using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.Response;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Howest.MagicCards.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.5")]
    public class DeckController : Controller
    {
        private readonly string _deckPath = "..\\Howest.MagicCards.Shared\\Decks\\CardDeck.json";

        [HttpGet("v1.5")]
        public async Task<ActionResult<List<DeckRepository>>> GetDecks()
        {
            string deckJson = await System.IO.File.ReadAllTextAsync(_deckPath);
            JsonDeckRepository decks = JsonSerializer.Deserialize<JsonDeckRepository>(deckJson);
            return (decks.GetAllDecks().Count != 0 && decks.GetAllDecks() is List<DeckRepository> allDecks)
                ? Ok(new DeckResponse<List<DeckRepository>>() { Deck = allDecks } )
                : Ok(new DeckResponse<List<DeckRepository>>() { Deck = new List<DeckRepository>() } );
        }

        [HttpGet("v1.5/{id:int}")]
        public async Task<ActionResult<DeckRepository>> GetDeck(int id)
        {
            string deckJson = await System.IO.File.ReadAllTextAsync(_deckPath);
            JsonDeckRepository decks = JsonSerializer.Deserialize<JsonDeckRepository>(deckJson);
            return (decks.GetAllDecks().FirstOrDefault(d => d.Id == id) is DeckRepository deck)
                ? Ok(new DeckResponse<DeckRepository>() { Deck = deck })
                : NotFound(new DeckResponse<DeckRepository>() { Message = "Deck not found." });
        }
    }
}
