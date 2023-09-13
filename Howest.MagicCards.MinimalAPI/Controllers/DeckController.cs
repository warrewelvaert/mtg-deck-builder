using Howest.MagicCards.DAL.Repositories;
using Howest.MagicCards.Shared.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Howest.MagicCards.MinimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.5")]
    public class DeckController : Controller
    {
        private readonly string _deckPath = "..\\Howest.MagicCards.Shared\\Decks\\CardDeck.json";

        [HttpGet]
        public async Task<ActionResult> GetAllDecksAsync()
        {
            JsonDeckRepository decks = await GetJsonDeck();
            return (decks.GetAllDecks().Count != 0 && decks.GetAllDecks() is List<DeckRepository> allDecks)
                ? Ok(allDecks)
                : NotFound("No decks found.");
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetDeckByIdAsync(int id)
        {
            JsonDeckRepository decks = await GetJsonDeck();
            return (decks.GetDeckById(id) is DeckRepository deck)
                ? Ok(deck)
                : NotFound("Deck not found.");
        }

        [HttpPost]
        public async Task<ActionResult> CreateDeckAsync(DeckRepository deck)
        {
            if (!IsDeckValid(deck))
            {
                return BadRequest("Request body is not valid.");
            }
            JsonDeckRepository decks = await GetJsonDeck();
            deck.Id = decks.GetAllDecks().Any() ? decks.GetAllDecks().Last().Id + 1 : 0;
            decks.AddDeck(deck);
            await UpdateJsonAsync(decks);
            return Created("api/deck/{decks.Decks.Count}", deck);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateDeckAsync(int id, DeckRepository deck)
        {
            if (!IsDeckValid(deck))
            {
                return BadRequest("Request body is not valid.");
            }
            JsonDeckRepository decks = await GetJsonDeck();
            DeckRepository oldDeck = decks.GetDeckById(id);
            if (oldDeck != null)
            {
                decks.RemoveDeck(oldDeck);
                decks.AddDeck(deck);
            }
            await UpdateJsonAsync(decks);
            return (oldDeck != null)
                ? Ok("Deck successfully updated.")
                : NotFound("Deck not found.");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteDeckAsync(int id)
        {
            JsonDeckRepository decks = await GetJsonDeck();
            DeckRepository deckToRemove = decks.GetDeckById(id);
            if (deckToRemove != null)
            {
                decks.RemoveDeck(deckToRemove);
            }
            await UpdateJsonAsync(decks);
            return (deckToRemove != null)
                ? Ok("Deck successfully deleted.")
                : NotFound("Deck not found.");
        }

        private async Task<JsonDeckRepository> GetJsonDeck()
        {
            string deckJson = await System.IO.File.ReadAllTextAsync(_deckPath);
            JsonDeckRepository decks = JsonSerializer.Deserialize<JsonDeckRepository>(deckJson);
            return decks;
        }

        private static bool IsDeckValid(DeckRepository deck)
        {
            DeckValidator validator = new();
            return (validator.Validate(deck).IsValid);
        }

        private async Task UpdateJsonAsync(JsonDeckRepository decks)
        {
            string updatedDeckJson = JsonSerializer.Serialize(decks);
            await System.IO.File.WriteAllTextAsync(_deckPath, updatedDeckJson);
        }
    }
}
