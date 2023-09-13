using Howest.MagicCards.DAL.Models;

namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable
    public class SqlSetRepository : ISetRepository
    {
        private readonly MtgV1Context _db;

        public SqlSetRepository(MtgV1Context mtgV1Context)
        {
            _db = mtgV1Context;
        }

        public IQueryable<Set> GetAllSets()
        {
            IQueryable<Set> allSets = _db.Sets
                                  .Select(a => a);
            return allSets;
        }

        public Set? GetSetById(int id)
        {
            Set? singleSet = _db.Sets
                        .SingleOrDefault(a => a.Id == id);

            return singleSet;
        }
    }
}
