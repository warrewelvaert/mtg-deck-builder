using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable
    public class SqlRarityRepository : IRarityRepository
    {
        private readonly MtgV1Context _db;

        public SqlRarityRepository(MtgV1Context mtgV1Context)
        {
            _db = mtgV1Context;
        }

        public IQueryable<Rarity> GetAllRarities()
        {
            IQueryable<Rarity> allRarities = _db.Rarities
                                  .Select(a => a);
            return allRarities;
        }

        public Rarity? GetRarityById(int id)
        {
            Rarity? singleRarity = _db.Rarities
                        .SingleOrDefault(a => a.Id == id);

            return singleRarity;
        }
    }
}
