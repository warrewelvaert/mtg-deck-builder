using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable
    public interface ICardRepository
    {
        IQueryable<Card> GetAllCards();
        Card? GetCardById(int id);
        Task<IQueryable<Card>> GetAllCardsAsync();
        Task<Card?> GetCardByIdAsync(int id);
    }
}
