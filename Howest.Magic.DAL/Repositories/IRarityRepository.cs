using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories
{
    # nullable enable
    public interface IRarityRepository
    {
        IQueryable<Rarity> GetAllRarities();
        Rarity? GetRarityById(int id);
    }
}
