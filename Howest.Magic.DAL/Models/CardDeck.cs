namespace Howest.MagicCards.DAL.Models
{
    public partial class CardDeck
    {
        public CardDeck(long id, string name, string manaCost)
        {
            Id = id;
            Name = name;
            ManaCost = manaCost;
        }
        public long Id { get; init; }
        public string Name { get; init; }
        public string ManaCost { get; init; }
    }
}
