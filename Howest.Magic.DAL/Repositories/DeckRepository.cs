using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories
{
    public class DeckRepository
    {

        public DeckRepository(long id, string name, List<CardDeck> cards)
        {
            Id = id;
            Name = name;
            Cards = cards;
        }

        public long Id { get; set; }
        public string Name { get; init; }
        public List<CardDeck> Cards { get; init; } = new List<CardDeck>();
        public List<CardDeck> GetAllCards()
        {
            return Cards;
        }
    }
}