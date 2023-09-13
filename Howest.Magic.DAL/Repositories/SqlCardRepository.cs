using Howest.MagicCards.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable
    public class SqlCardRepository : ICardRepository
    {
        private readonly MtgV1Context _db;

        public SqlCardRepository(MtgV1Context mtgV1Context)
        {
            _db = mtgV1Context;
        }

        public IQueryable<Card> GetAllCards()
        {
            IQueryable<Card> allCards = _db.Cards
                                  .Include(c => c.RarityCodeNavigation)
                                  .Include(c => c.SetCodeNavigation)
                                  .Include(c => c.Artist)
                                  .Select(a => a);
            return allCards;
        }

        public Card? GetCardById(int id)
        {
            Card? singleCard = _db.Cards
                        .SingleOrDefault(a => a.Id == id);

            return singleCard;
        }

        public async Task<IQueryable<Card>> GetAllCardsAsync()
        {
            IQueryable<Card> allCards = _db.Cards
                .Select(a => a);

            return await Task.FromResult(allCards);
        }

        public async Task<Card?> GetCardByIdAsync(int id)
        {
            Card? singleCard = await _db.Cards
                .SingleOrDefaultAsync(a => a.Id == id);

            return singleCard;
        }
    }
}
