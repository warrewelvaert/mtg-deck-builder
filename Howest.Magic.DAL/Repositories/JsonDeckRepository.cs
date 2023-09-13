namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable
    public class JsonDeckRepository
    {
        public List<DeckRepository> Decks { get; init; } = new List<DeckRepository>();

        public List<DeckRepository> GetAllDecks()
        {
            return Decks;
        }

        public DeckRepository? GetDeckById(int id)
        {
            DeckRepository? singleDeck = Decks.FirstOrDefault(d => d.Id == id);
            return singleDeck;
        }

        public void RemoveDeck(DeckRepository deck) { Decks.Remove(deck); }

        public void AddDeck(DeckRepository deck) { Decks.Add(deck); }
    }
}
