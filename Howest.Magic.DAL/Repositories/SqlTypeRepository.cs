using Howest.MagicCards.DAL.Models;
using Type = Howest.MagicCards.DAL.Models.Type;

namespace Howest.MagicCards.DAL.Repositories
{
    #nullable enable
    public class SqlTypeRepository : ITypeRepository
    {
        private readonly MtgV1Context _db;

        public SqlTypeRepository(MtgV1Context mtgV1Context)
        {
            _db = mtgV1Context;
        }

        public IQueryable<Type> GetAllTypes()
        {
            IQueryable<Type> allTypes = _db.Types
                                  .Select(a => a);
            return allTypes;
        }

        public Type? GetTypeById(int id)
        {
            Type? singleType = _db.Types
                        .SingleOrDefault(a => a.Id == id);

            return singleType;
        }


    }
}
